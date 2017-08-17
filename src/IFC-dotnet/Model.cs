using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using System;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Transactions;
using System.Collections.Generic;

namespace IFC4
{
	/// <summary>
	/// Model provides a container for instances of BaseIfc.
	/// </summary>
	public class Model
	{
		private Dictionary<Guid,BaseIfc> instances = new Dictionary<Guid,BaseIfc>();

		public Model(){}

		/// <summary>
		/// Finds an instance in the model, given its unique identifier.
		/// </summary>
		/// <param name="id">The unique id of the instance to find.</param>
		public BaseIfc GetInstanceById(Guid id)
		{
			if(instances.ContainsKey(id))
			{
				return instances[id];
			}
			
			return null;
		}

		/// <summary>
		/// Add an instance to the model.
		/// </summary>
		/// <param name="instance">The instance to add to the Model.</param>
		public void AddInstance(BaseIfc instance)
		{
			if(instances.ContainsKey(instance.Id))
			{
				throw new DuplicateInstanceException(instance.Id);
			}

			instances.Add(instance.Id, instance);
		}

		/// <summary>
		/// Remove an instance from the model.
		/// </summary>
		/// <param name="id"></param>
		public void RemoveInstance(Guid id)
		{
			if(!instances.ContainsKey(id))
			{
				throw new InstanceNotFoundException(id);
			}

			instances.Remove(id);
		}

		/// <summary>
		/// Create a Model given a STEP file.
		/// </summary>
		/// <param name="filePath">The path to the STEP file.</param>
		/// <returns>A Model.</returns>
		public static Model FromSTEP(string filePath)
		{
			if(!File.Exists(filePath))
			{
				throw new FileNotFoundException($"The specified IFC STEP file does not exist: {filePath}.");
			}
			
			Model model = new Model();

			using (FileStream fs = new FileStream(filePath, FileMode.Open))
			{
				var input = new AntlrInputStream(fs);
				var lexer = new STEP.STEPLexer(input);
				var tokens = new CommonTokenStream(lexer);

				var parser = new STEP.STEPParser(tokens);
				parser.BuildParseTree = true;

				var tree = parser.file();
				var walker = new ParseTreeWalker();
				
				var listener = new STEP.STEPListener();
				walker.Walk(listener, tree);

				foreach(var data in listener.InstanceData.Values)
				{
					if(data.ConstructedGuid != null && model.GetInstanceById(data.ConstructedGuid) != null)
					{
						// Instance may have been previously constructed as the result
						// of another construction.
						continue;
					}
					var instance = ConstructRecursive(data, listener.InstanceData, model);
					model.AddInstance(instance);
				}
			}

			return model;
		}

		/// <summary>
		/// Recursively construct instances provided instance data.
		/// Construction is recursive because the instance data my include other
		/// instance data or id references to instances which have not yet been
		/// constructed.
		/// </summary>
		/// <param name="data">The instance data from which to construct the instance.</param>
		/// <param name="instanceDataMap">The dictionary containing instance data gathered from the parser.</param>
		/// <param name="model">The Model in which constructed instances will be stored.</param>
		/// <returns></returns>
		private static BaseIfc ConstructRecursive(STEP.InstanceData data, Dictionary<int,STEP.InstanceData> instanceDataMap, Model model)
		{		
			Console.WriteLine($"{data.Id} : Constructing type {data.Type.Name} with parameters [{string.Join(",",data.Parameters)}]");
	
			for(var i=data.Parameters.Count()-1; i>=0; i--)
			{
				var instData = data.Parameters[i] as STEP.InstanceData;
				if(instData != null)
				{
					var subInstance = ConstructRecursive(instData, instanceDataMap, model);
					data.Parameters[i] = subInstance;
					continue;
				}

				var stepId = data.Parameters[i] as STEP.STEPId;
				if(stepId != null)
				{
					var id = stepId.Value;
					var guid = instanceDataMap[id].ConstructedGuid;
					if(guid != null)
					{
						var existingInst = model.GetInstanceById(guid);
						if(existingInst != null)
						{
							Console.WriteLine($"Using existing instance with id, {id}, in {data.Id}");
							data.Parameters[i] = existingInst;
							continue;
						}
					}

					var subInstance = ConstructRecursive(instanceDataMap[id], instanceDataMap, model);
					data.Parameters[i] = subInstance;
					continue;
				}

				var list = data.Parameters[i] as List<object>;
				if(list != null)
				{
					// The parameters will have been stored in a List<object> during parsing.
					// We need to create a List<T> where T is the type expected by the constructor
					// in the STEP file.
					var listType = typeof(List<>);
					var instanceType = data.Constructor.GetParameters()[i].ParameterType.GetGenericArguments()[0];
					var constructedListType = listType.MakeGenericType(instanceType);
					var subInstances = (IList)Activator.CreateInstance(constructedListType);

					if(!list.Any())
					{
						// Return our newly type empty list.
						data.Parameters[i] = subInstances;
						continue;
					}

					foreach(var item in list)
					{
						var id = item as STEP.STEPId;
						if(id != null)
						{
							var subInstance = ConstructRecursive(instanceDataMap[id.Value], instanceDataMap, model);

							// The object must be converted to the type expected in the list
							// for Select types, this will be a recursive build of the base select type.
							var convert = Convert(instanceType, subInstance);
							subInstances.Add(convert);
						}
						else
						{
							var subInstance = item;
							var convert = Convert(instanceType, subInstance);
							subInstances.Add(convert);
						}
					}
					// Replace the list of STEPId with a list of instance references.
					data.Parameters[i] = subInstances;
				}
			}

			// Do one final pass on all parameters to ensure
			// that they are of the correct type.
			for(var i=data.Parameters.Count-1; i>=0; i--)
			{
				if(data.Parameters[i] == null)
				{
					continue;
				}
				
				var pType = data.Parameters[i].GetType();
				var expectedType = data.Constructor.GetParameters()[i].ParameterType;
				
				data.Parameters[i] = Convert(expectedType, data.Parameters[i]);
			}

			// Construct the instance, assuming that all required sub-instances
			// have already been constructed.
			var instance = (BaseIfc)data.Constructor.Invoke(data.Parameters.ToArray());
			
			if(instanceDataMap.ContainsKey(data.Id))
			{
				// We'll only get here if the instance is not being constructed
				// as a sub-instance.
				instanceDataMap[data.Id].ConstructedGuid = instance.Id;
			}
			
			Console.WriteLine($"{data.Id} : Constructed type {data.Type.Name} with parameters [{string.Join(",",data.Parameters)}]");

			return instance;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="expectedType"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		private static object Convert(Type expectedType, object value)
		{
			// Bail out immediately if a direct cast is available.
			if(expectedType.IsAssignableFrom(value.GetType()))
			{
				return value;
			}

			var converter = TypeDescriptor.GetConverter(expectedType);
			if(converter != null && converter.CanConvertFrom(value.GetType()))
			{
				return converter.ConvertFrom(value);
			}
			else
			{
				throw new Exception($"There was no type converter available to convert from {value.GetType()} to {expectedType}.");
			}
		}
	}
}
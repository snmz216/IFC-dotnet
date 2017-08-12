//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.7
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from STEP.g4 by ANTLR 4.7

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace STEP {
using Antlr4.Runtime.Misc;
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="STEPParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7")]
[System.CLSCompliant(false)]
public interface ISTEPListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="STEPParser.author"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAuthor([NotNull] STEPParser.AuthorContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="STEPParser.author"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAuthor([NotNull] STEPParser.AuthorContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="STEPParser.authorisation"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAuthorisation([NotNull] STEPParser.AuthorisationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="STEPParser.authorisation"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAuthorisation([NotNull] STEPParser.AuthorisationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="STEPParser.collection"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCollection([NotNull] STEPParser.CollectionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="STEPParser.collection"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCollection([NotNull] STEPParser.CollectionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="STEPParser.collectionValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCollectionValue([NotNull] STEPParser.CollectionValueContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="STEPParser.collectionValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCollectionValue([NotNull] STEPParser.CollectionValueContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="STEPParser.constructor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterConstructor([NotNull] STEPParser.ConstructorContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="STEPParser.constructor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitConstructor([NotNull] STEPParser.ConstructorContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="STEPParser.data"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterData([NotNull] STEPParser.DataContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="STEPParser.data"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitData([NotNull] STEPParser.DataContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="STEPParser.description"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDescription([NotNull] STEPParser.DescriptionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="STEPParser.description"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDescription([NotNull] STEPParser.DescriptionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="STEPParser.file"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFile([NotNull] STEPParser.FileContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="STEPParser.file"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFile([NotNull] STEPParser.FileContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="STEPParser.fileDescription"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFileDescription([NotNull] STEPParser.FileDescriptionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="STEPParser.fileDescription"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFileDescription([NotNull] STEPParser.FileDescriptionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="STEPParser.fileName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFileName([NotNull] STEPParser.FileNameContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="STEPParser.fileName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFileName([NotNull] STEPParser.FileNameContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="STEPParser.filePath"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFilePath([NotNull] STEPParser.FilePathContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="STEPParser.filePath"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFilePath([NotNull] STEPParser.FilePathContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="STEPParser.fileSchema"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFileSchema([NotNull] STEPParser.FileSchemaContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="STEPParser.fileSchema"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFileSchema([NotNull] STEPParser.FileSchemaContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="STEPParser.header"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterHeader([NotNull] STEPParser.HeaderContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="STEPParser.header"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitHeader([NotNull] STEPParser.HeaderContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="STEPParser.implementation"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterImplementation([NotNull] STEPParser.ImplementationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="STEPParser.implementation"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitImplementation([NotNull] STEPParser.ImplementationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="STEPParser.instance"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterInstance([NotNull] STEPParser.InstanceContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="STEPParser.instance"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitInstance([NotNull] STEPParser.InstanceContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="STEPParser.name"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterName([NotNull] STEPParser.NameContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="STEPParser.name"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitName([NotNull] STEPParser.NameContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="STEPParser.originating_system"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterOriginating_system([NotNull] STEPParser.Originating_systemContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="STEPParser.originating_system"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitOriginating_system([NotNull] STEPParser.Originating_systemContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="STEPParser.organization"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterOrganization([NotNull] STEPParser.OrganizationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="STEPParser.organization"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitOrganization([NotNull] STEPParser.OrganizationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="STEPParser.parameter"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterParameter([NotNull] STEPParser.ParameterContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="STEPParser.parameter"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitParameter([NotNull] STEPParser.ParameterContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="STEPParser.preprocessor_version"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPreprocessor_version([NotNull] STEPParser.Preprocessor_versionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="STEPParser.preprocessor_version"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPreprocessor_version([NotNull] STEPParser.Preprocessor_versionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="STEPParser.timeStamp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTimeStamp([NotNull] STEPParser.TimeStampContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="STEPParser.timeStamp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTimeStamp([NotNull] STEPParser.TimeStampContext context);
}
} // namespace STEP

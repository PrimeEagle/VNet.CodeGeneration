namespace VNet.CodeGeneration.Writers.CodeWriter
{
    public interface IProgrammingLanguageSyntaxSettings
    {
        string NamespaceKeyword { get; }
        string ClassKeyword { get; }
        string StructKeyword { get; }
        string EnumKeyword { get; }
        string InterfaceKeyword { get; }
        string DelegateKeyword { get; }
        string StatementEnd { get; }
        string MethodKeyword { get; }
        string PropertyKeyword { get; }
        string ConstructorKeyword { get; }
        string OpenScopeCharacter { get; }
        string CloseScopeCharacter { get; }
        string UseStatementKeyword { get; }
        string StaticKeyword { get; }
        string GetCommentSyntax(string comment, CommentType commentType);
        string GetAttributeSyntax(string attributeName, params string[] args);
        string GetAccessModifier(AccessModifier modifier);
        string EnumSeparatorCharacter { get; }
        bool ValidNaming(string name);
    }
}
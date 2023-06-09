namespace VNet.Scientific.CodeGen.Writers
{
    public interface ILanguageSettings
    {
        string NamespaceKeyword { get; }
        string ClassKeyword { get; }
        string EnumKeyword { get; }
        string GetAccessModifier(AccessModifier modifier);
        string OpenScope { get; }
        string CloseScope { get; }
        string StatementEnd { get; }
        string PropertySetterGetter { get; }
        string GetIndent();
        int IndentLevel { get; set; }
        BraceStyle BraceStyle { get; }
        string GetGenericType(string typeName, params string[] typeArguments);
    }
}
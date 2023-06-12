using Microsoft.CSharp;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.CSharp
{
    public class CSharpSyntax : IProgrammingLanguageSyntax
    {
        public string UsingKeyword => "using";
        public string NamespaceKeyword => "namespace";
        public string ClassKeyword => "class";
        public string MethodKeyword => string.Empty;
        public string StaticKeyword => "static";
        public string ReadOnlyKeyword => "readonly";
        public string ConstantKeyword => "const";
        public string VolatileKeyword => "volatile";
        public string NewKeyword => "new";
        public string InterfaceKeyword => "interface";
        public string StructKeyword => "struct";
        public string EnumKeyword => "enum";
        public string DelegateKeyword => "delegate";
        public string StatementEnd => ";";
        public string OpenScopeCharacter => "{";
        public string CloseScopeCharacter => "}";
        public string PropertyKeyword => string.Empty;
        public string ConstructorKeyword => string.Empty;
        public string GenericStart => "<";
        public string GenericEnd => ">";
        public string PropertySetterGetter => "{ get; set; }";
        public string GetKeyword => "get";
        public string SetKeyword => "set";
        public string EnumValueSeparatorCharacter => "=";
        public string EnumMemberSeparatorCharacter => ",";
        public string SingleLineCommentCharacter => "//";
        public string MultilineCommentOpenScopeCharacter => "/*";
        public string MultilineCommentCloseScopeCharacter => "*/";
        public string DocumentationCommentCharacter => "///";
        public string DocumentationCommentOpenScopeCharacter => "/// <summary>";
        public string DocumentationCommentCloseScopeCharacter => "/// </summary>";
        public CaseConversionStyle AccessModifierCaseStyle => CaseConversionStyle.AllLower;

        public bool IsValidNaming(string name)
        {
            return new CSharpCodeProvider().IsValidIdentifier(name);
        }
    }
}
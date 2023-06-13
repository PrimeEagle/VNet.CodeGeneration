﻿namespace VNet.CodeGeneration.Writers.CodeWriter
{
    public interface IProgrammingLanguageSyntax
    {
        string UsingKeyword { get; }
        string NamespaceKeyword { get; }
        string ClassKeyword { get; }
        string MethodKeyword { get; }
        string StaticKeyword { get; }
        string ReadOnlyKeyword { get; }
        string ConstantKeyword { get; }
        string VolatileKeyword { get; }
        string NewKeyword { get; }
        string PublicKeyword { get; }
        string InterfaceKeyword { get; }
        string StructKeyword { get; }
        string EnumKeyword { get; }
        string DelegateKeyword { get; }
        string StatementEnd { get; }
        string OpenScopeCharacter { get; }
        string CloseScopeCharacter { get; }
        string RegionOpenScopeCharacter { get; }
        string RegionCloseScopeCharacter { get; }
        string PropertyKeyword { get; }
        string ConstructorKeyword { get; }
        string GenericStart { get; }
        string GenericEnd { get; }
        string PropertySetterGetter { get; }
        string GetKeyword { get; }
        string SetKeyword { get; }
        string EnumValueSeparatorCharacter { get; }
        string EnumMemberSeparatorCharacter { get; }
        string SingleLineCommentCharacter { get; }
        string MultilineCommentOpenScopeCharacter { get; }
        string MultilineCommentCloseScopeCharacter { get; }
        string DocumentationCommentCharacter { get; }
        string DocumentationCommentOpenScopeCharacter { get; }
        string DocumentationCommentCloseScopeCharacter { get; }
        CaseConversionStyle AccessModifierCaseStyle { get; }
        bool IsValidNaming(string name);
    }
}
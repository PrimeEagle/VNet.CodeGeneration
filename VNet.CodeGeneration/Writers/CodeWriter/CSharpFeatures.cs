namespace VNet.CodeGeneration.Writers.CodeWriter
{
    public class CSharpFeatures : ILanguageFeaturesSettings
    {
        public bool SupportsNestedClasses => true;
        public bool SupportsNamespaces => true;
        public bool SupportsClasses => true;
        public bool SupportsProperties => true;
        public bool SupportsMethods => true;
        public bool SupportsDelegates => true;
        public bool SupportsInterfaces => true;
        public bool SupportsStructs => true;
        public bool SupportsEnums => true;
        public bool SupportsConstructors => true;
        public bool SupportsUsingStatements => true;
    }
}
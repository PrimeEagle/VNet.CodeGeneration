namespace VNet.CodeGeneration.Writers
{
    public interface ILanguageFeaturesSettings
    {
        bool SupportsNamespaces { get; }
        bool SupportsClasses { get; }
        bool SupportsProperties { get; }
        bool SupportsMethods { get; }
        bool SupportsStructs { get; }
        bool SupportsEnums { get; }
        bool SupportsInterfaces { get; }
        bool SupportsDelegates { get; }
        bool SupportsConstructors { get; }
        bool SupportsUsingStatements { get; }
    }
}
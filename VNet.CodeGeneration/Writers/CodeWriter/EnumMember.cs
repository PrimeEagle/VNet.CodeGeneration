namespace VNet.CodeGeneration.Writers.CodeWriter
{
    public class EnumMember
    {
        public string Name { get; }
        public string Value { get; }

        public EnumMember(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }
}
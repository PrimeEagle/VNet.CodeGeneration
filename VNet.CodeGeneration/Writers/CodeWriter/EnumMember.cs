namespace VNet.CodeGeneration.Writers.CodeWriter
{
    public class EnumMember
    {
        public string Name { get; }
        public int? Value { get; }

        public EnumMember(string name, int? value = null)
        {
            Name = name;
            Value = value;
        }
    }
}
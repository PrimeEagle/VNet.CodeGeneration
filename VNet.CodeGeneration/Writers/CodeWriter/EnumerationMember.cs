namespace VNet.CodeGeneration.Writers.CodeWriter
{
    public class EnumerationMember
    {
        public string Name { get; }
        public int? Value { get; }

        public EnumerationMember(string name, int? value = null)
        {
            Name = name;
            Value = value;
        }
    }
}
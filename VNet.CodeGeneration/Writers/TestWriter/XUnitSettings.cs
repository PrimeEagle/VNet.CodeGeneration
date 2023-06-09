namespace VNet.Scientific.CodeGen.Writers.TestWriter
{
    public class XUnitSettings : ITestSettings
    {
        public string GetIndent(int indentLevel)
        {
            return new string(' ', indentLevel * 4);
        }

        public string GetTestMethodAttribute()
        {
            return "[Fact]";
        }

        public string GetTestClassAttribute(string className)
        {
            return $"public class {className}";
        }

        public string GetAssertEqual(string expected, string actual)
        {
            return $"Assert.Equal({expected}, {actual});";
        }
    }
}
namespace VNet.Scientific.CodeGen.Writers.TestWriter
{
    public class NUnitSettings : ITestSettings
    {
        public string GetIndent(int indentLevel)
        {
            return new string(' ', indentLevel * 4);
        }

        public string GetTestMethodAttribute()
        {
            return "[Test]";
        }

        public string GetTestClassAttribute(string className)
        {
            return $"[TestFixture]\npublic class {className}";
        }

        public string GetAssertEqual(string expected, string actual)
        {
            return $"Assert.AreEqual({expected}, {actual});";
        }
    }
}
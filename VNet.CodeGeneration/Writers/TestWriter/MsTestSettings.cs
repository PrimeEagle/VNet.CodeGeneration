namespace VNet.Scientific.CodeGen.Writers.TestWriter
{
    public class MsTestSettings : ITestSettings
    {
        public string GetIndent(int indentLevel)
        {
            return new string(' ', indentLevel * 4);
        }

        public string GetTestMethodAttribute()
        {
            return "[TestMethod]";
        }

        public string GetTestClassAttribute(string className)
        {
            return $"[TestClass]\npublic class {className}";
        }

        public string GetAssertEqual(string expected, string actual)
        {
            return $"Assert.AreEqual({expected}, {actual});";
        }
    }
}
namespace VNet.CodeGeneration.Writers.TestWriter
{
    public interface ITestSettings
    {
        string GetIndent(int indentLevel);
        string GetTestMethodAttribute();
        string GetTestClassAttribute(string className);
        string GetAssertEqual(string expected, string actual);
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace VNet.Scientific.CodeGen.Writers.TestWriter
{
    public class TestWriter
    {
        private readonly ITestSettings _settings;
        private readonly StringBuilder _sb;
        private int _indentLevel;

        public TestWriter(ITestSettings settings)
        {
            _settings = settings;
            _sb = new StringBuilder();
            _indentLevel = 0;
        }

        public void WriteRaw(string str = null)
        {
            if (str != null)
                _sb.Append(str);
        }

        public void Write(string str = null)
        {
            if (str != null)
            {
                _sb.Append(_settings.GetIndent(_indentLevel));
                _sb.Append(str);
            }
        }

        public void WriteLine(string str = null)
        {
            if (str != null)
            {
                _sb.Append(_settings.GetIndent(_indentLevel));
                _sb.AppendLine(str);
            }
            else
            {
                _sb.AppendLine();
            }
        }

        public void Indent()
        {
            _indentLevel++;
        }

        public void Unindent()
        {
            if (_indentLevel > 0)
                _indentLevel--;
        }

        public void WriteInitializer(string typeName, Dictionary<string, string> values)
        {
            Write($"{typeName} = new {typeName}");
            Write("{");
            Indent();

            var isFirst = true;
            foreach (var kvp in values)
            {
                var name = kvp.Key;
                var value = kvp.Value;

                if (!isFirst)
                    WriteLine(",");

                Write($"{name} = {value}");
                isFirst = false;
            }

            Unindent();
            WriteLine();
            Write("}");
            WriteLine(";");
        }

        public void WriteTestMethod(string methodName, Action<TestWriter> testMethodAction)
        {
            WriteLine(_settings.GetTestMethodAttribute());
            Write("public void ");
            Write(methodName);
            Write("()");
            WriteLine();
            WriteLine("{");
            Indent();
            testMethodAction.Invoke(this);
            Unindent();
            WriteLine("}");
        }

        public void WriteTestClass(string className, Action<TestWriter> testClassAction)
        {
            WriteLine(_settings.GetTestClassAttribute(className));
            WriteLine("{");
            Indent();
            testClassAction.Invoke(this);
            Unindent();
            WriteLine("}");
        }

        public void WriteFinalizer(string className, Action<TestWriter> finalizerAction)
        {
            WriteLine($"~{className}()");
            WriteLine("{");
            Indent();
            finalizerAction.Invoke(this);
            Unindent();
            WriteLine("}");
        }

        public override string ToString()
        {
            return _sb.ToString();
        }
    }
}
using System.Text;

namespace VNet.CodeGeneration.Writers.SqlWriter
{
    public class SqlWriter
    {
        private readonly ISqlSettings _settings;
        private readonly StringBuilder _sb;
        private int _indentLevel;
        private bool _previousLineWasGo;

        public SqlWriter(ISqlSettings settings)
        {
            _settings = settings;
            _sb = new StringBuilder();
            _indentLevel = 0;
            _previousLineWasGo = false;
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
                _previousLineWasGo = false;
            }
        }

        public void WriteLine(string str = null)
        {
            if (str != null)
            {
                _sb.Append(_settings.GetIndent(_indentLevel));
                _sb.AppendLine(str);
                _previousLineWasGo = false;
            }
            else
            {
                _sb.AppendLine();
                _previousLineWasGo = false;
            }
        }

        public void WriteBatchSeparator()
        {
            if (!_previousLineWasGo)
            {
                _sb.AppendLine(_settings.BatchSeparator);
                _previousLineWasGo = true;
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

        public override string ToString()
        {
            return _sb.ToString();
        }
    }
}
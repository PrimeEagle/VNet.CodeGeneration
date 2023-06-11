// ReSharper disable NotAccessedField.Local
#pragma warning disable IDE0052

namespace VNet.CodeGeneration.Writers.CodeWriter
{
    public class IndentationManager
    {
        private int _indentLevel;

        public IndentationManager()
        {
            _indentLevel = 0;
        }

        public void Increase()
        {
            _indentLevel++;
        }

        public void Decrease()
        {
            _indentLevel--;
        }
    }
}
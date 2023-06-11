// ReSharper disable NotAccessedField.Local

namespace VNet.CodeGeneration.Writers.CodeWriter
{
    public class IndentationManager
    {
        public int Current { get; private set; }


        public IndentationManager()
        {
            Current = 0;
        }

        public void Increase()
        {
            Current++;
        }

        public void Decrease()
        {
            Current--;
        }
    }
}
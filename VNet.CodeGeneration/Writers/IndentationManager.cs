// ReSharper disable NotAccessedField.Local

namespace VNet.CodeGeneration.Writers
{
    public class IndentationManager
    {
        public int Current { get; internal set; }


        public IndentationManager()
        {
            Current = 0;
        }

        public IndentationManager(int initialLevel)
        {
            Current = initialLevel;
        }

        public void Increase()
        {
            Current++;
        }

        public void Decrease()
        {
            Current--;
            if (Current < 0) Current = 0;
        }
    }
}
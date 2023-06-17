using System;
using System.IO;
// ReSharper disable MemberCanBePrivate.Global

namespace VNet.CodeGeneration.Log
{
    public class Logger
    {
        private string _logFile;

        public void Initialize(string logFile)
        {
            _logFile = logFile;

            if (!File.Exists(_logFile))
            {
                var fs = File.Create(logFile);
                fs.Close();
            }
        }

        public void WriteLine(string message)
        {
            File.AppendAllText(_logFile, $"{DateTime.Now}\t\t{message}\r\n");
        }

        public void Clear()
        {
            File.Delete(_logFile);
            Initialize(_logFile);
        }
    }
}
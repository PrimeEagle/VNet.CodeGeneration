﻿using System.IO;

namespace VNet.CodeGeneration.FileComparer
{
    public class FileComparerEntry
    {
        public string FileName { get; set; }
        public string FullPath { get; set; }
        public string Hash { get; set; }
        public bool Deleted { get; set; }
        public bool Updated { get; set; }


        public string GetJson()
        {
            string json;

            using (var reader = new StreamReader(FullPath))
            {
                json = reader.ReadToEnd();
            }

            return json;
        }
    }
}
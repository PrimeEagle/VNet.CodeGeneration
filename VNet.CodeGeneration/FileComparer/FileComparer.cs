using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;


// ReSharper disable NotAccessedField.Local
// ReSharper disable MemberCanBePrivate.Global

namespace VNet.CodeGeneration.FileComparer
{
    public class FileComparer
    {
        private readonly string _fileName;
        private readonly string _directory;

        public List<FileComparerEntry> Entries { get; set; }

        public FileComparer(string fileName)
        {
            _fileName = fileName;
            _directory = Path.GetDirectoryName(_fileName);

            if (!File.Exists(_fileName))
            {
                var fs = File.Create(_fileName);
                fs.Close();
            }

            string json;
            using (var reader = new StreamReader(_fileName))
            {
                json = reader.ReadToEnd();
                reader.Close();
            }

            Entries = string.IsNullOrEmpty(json) ? new List<FileComparerEntry>() : VNet.CodeGeneration.Json.Json.Deserialize<List<FileComparerEntry>>(json);
            foreach (var e in Entries)
            {
                e.FullPath = Path.Combine(_directory, e.FileName);
            }
        }

        public IEnumerable<FileComparerEntry> GetUpdatedEntries()
        {
            return Entries.Where(e => e.Updated);
        }

        public void Update()
        {
            foreach (var entry in Entries)
            {
                // deleted files
                if (!File.Exists(entry.FullPath))
                {
                    entry.Deleted = true;
                    continue;
                }

                // updated files
                if (entry.Hash != GetFileHash(entry.FullPath))
                {
                    entry.Updated = true;
                }
            }

            Entries.RemoveAll(e => e.Deleted);

            // new files
            var files = Directory.GetFiles(_directory, "*.json").Where(f => !Path.GetFileName(f).StartsWith("_"));


            foreach (var file in files)
            {
                if (Entries.All(e => e.FullPath != file))
                {
                    var newEntry = new FileComparerEntry()
                    {
                        FileName = Path.GetFileName(file),
                        FullPath = file,
                        Hash = GetFileHash(file),
                        Updated = true,
                        Deleted = false
                    };
                    Entries.Add(newEntry);
                }
            }
        }

        private static string GetFileHash(string fileName)
        {
            var sha256 = SHA256.Create();
            var stream = File.OpenRead(fileName);
            var buffer = new byte[8192]; // 8KB chunks
            int bytesRead;

            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0) sha256.TransformBlock(buffer, 0, bytesRead, null, 0);
            sha256.TransformFinalBlock(buffer, 0, 0);

            var builder = new StringBuilder();
            foreach (var t in sha256.Hash)
                builder.Append(t.ToString("x2"));

            stream.Dispose();
            sha256.Dispose();

            return builder.ToString().Replace("-", "").ToLowerInvariant();
        }

        public void Save()
        {
            var results = Entries.Where(e => !e.Deleted).Select(e => new FileComparerEntry() { FileName = e.FileName, Hash = e.Hash }).ToList<FileComparerEntry>();
            var json = VNet.CodeGeneration.Json.Json.Serialize(results);
            using (var writer = new StreamWriter(_fileName))
            {
                writer.Write(json);
                writer.Close();
            }
        }
    }
}
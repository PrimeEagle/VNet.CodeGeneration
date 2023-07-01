using System;
using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers
{
    public static class ListExtensions
    {
        public static void AppendToLastElement(this List<string> source, string text)
        {
            if (source == null || source.Count == 0) return;

            source[source.Count - 1] = $"{source[source.Count - 1]}{text}";
        }

        public static void InsertRange<T>(this List<T> source, int index, List<T> list)
        {
            if (index > source.Count) throw new ArgumentOutOfRangeException(nameof(index));

            for (var i = list.Count - 1; i >= 0; i--)
            {
                source.Insert(index, list[i]);
            }
        }
    }
}
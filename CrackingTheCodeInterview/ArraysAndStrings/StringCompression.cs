using System.Collections.Generic;

namespace CrackingTheCodeInterview.ArraysAndStrings
{
    internal class StringCompression
    {
        public static string Compress(string str)
        {
            var hash = new Dictionary<char, int>();

            foreach (var c in str)
            {
                if (!hash.ContainsKey(c))
                    hash.Add(c, 0);
                
                hash[c]++;
            }
            char[] compressed = new char[hash.Count * 2];
            int compressedIndex = 0;
            foreach (var item in hash)
            {
                compressed[compressedIndex++] = item.Key;
                
                if (item.Value > 1)
                    compressed[compressedIndex++] = item.Value.ToString()[0];
                else
                    compressed[compressedIndex++] = item.Key;
            }
            return new string(compressed);
        }

        public static void TestSolution()
        {
            string test = "aa";
            string compressed = Compress(test);
        }
    }
}
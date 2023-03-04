using System;
using System.Collections.Generic;

namespace CrackingTheCodeInterview.ArraysAndStrings
{
    internal class StringRotation
    {
        public static bool IsSubstring(string s1, string s2)
            => s1.Contains(s2);

        public static bool IsRotation(string s1, string s2)
        {
            if (s1.Length == s2.Length) 
                return (s1 + s1).Contains(s2);
            return false;
        }

        public static void TestSolution()
        {
            var pairs = new Dictionary<string, string>{ { "apple", "pleap" }, { "waterbottle", "erbottlewat" }, { "camera", "macera" } };
            
            foreach(var pair in pairs)
            {
                var word1 = pair.Key;
                var word2 = pair.Value;
                bool isRotation = IsRotation(word1, word2);
                Console.WriteLine($"word1 = {word1} word2 = {word2}, isRotation = {isRotation}");
            }
        }
    }
}
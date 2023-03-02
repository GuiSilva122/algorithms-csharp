using System;
using System.Collections.Generic;

namespace CrackingTheCodeInterview.ArraysAndStrings
{
    internal class OneWay
    {
        // O(n) time, O(n) space
        public static bool IsOneEditAway(string originalPhrase, string editedPhrase)
        {
            Dictionary<char, int> hash = new Dictionary<char, int>();

            foreach (char c in originalPhrase)
            {
                if (hash.ContainsKey(c))
                    hash[c]++;
                else
                    hash[c] = 1;
            }

            foreach (char c in editedPhrase)
            {
                if (hash.ContainsKey(c))
                    hash[c]++;
                else
                    hash[c] = 1;
            }

            int numberOfDifferences = 0;
            foreach (var item in hash.Values)
            {
                if (numberOfDifferences > 1)                    
                    return false;

                if (item % 2 != 0)
                    numberOfDifferences++;
            }

            return true;
        }

        public static bool IsOneEditAway2(string first, string second)
        {
            if (first.Length == second.Length)
                return OneEditReplace(first, second);
            else if (first.Length + 1 == second.Length)
                return OneEditInsert(first, second);
            else if (first.Length - 1 == second.Length)
                return OneEditInsert(second, first);
            
            return false;
        }

        public static bool IsOneEditAway3(string first, string second)
        {
            if (Math.Abs(first.Length - second.Length) > 1)
                return false;

            string s1 = first.Length < second.Length ? first : second;
            string s2 = first.Length < second.Length ? second : first;

            int index1 = 0;
            int index2 = 0;
            bool foundDifference = false;
            while (index2 < s2.Length && index1 < s1.Length)
            {
                if (s1[index1] != s2[index2])
                {
                    if (foundDifference) 
                        return false;
                    foundDifference = true;

                    if (s1.Length == s2.Length)
                        index1++;
                }
                else
                    index1++;
                
                index2++;
            }
            return true;
        }

        private static bool OneEditReplace(string s1, string s2)
        {
            bool foundDifference = false;
            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] != s2[i])
                {
                    if (foundDifference)
                        return false;
                    foundDifference = true;
                }
            }
            return true;
        }

        // Check if you can insert a character into s1 to make s2.
        private static bool OneEditInsert(string s1, string s2)
        {
            int index1 = 0;
            int index2 = 0;
            while (index2 < s2.Length && index1 < s1.Length)
            {
                if (s1[index1] != s2[index2])
                {
                    if (index1 != index2)
                        return false;
                    index2++;
                }
                else
                {
                    index1++;
                    index2++;
                }
            }
            return true;
        }

        public static void TestSolution()
        {
            string originalPhrase1 = "pale";
            string editedPhrase1 = "ple";
            var result1 = IsOneEditAway(originalPhrase1, editedPhrase1);

            string originalPhrase2 = "pales";
            string editedPhrase2 = "pale";
            var result2 = IsOneEditAway(originalPhrase2, editedPhrase2);

            string originalPhrase3 = "pale";
            string editedPhrase3 = "bale";
            var result3 = IsOneEditAway(originalPhrase3, editedPhrase3);

            string originalPhrase4 = "pale";
            string editedPhrase4 = "bake";
            var result4 = IsOneEditAway(originalPhrase4, editedPhrase4);
        }
    }
}

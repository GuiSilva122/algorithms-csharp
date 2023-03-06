using System;
using System.Linq;

namespace CrackingTheCodeInterview.ArraysAndStrings
{
    public class CheckPermutation
    {
        public static Boolean IsPermutation(String s, String t)
        {
            var sCharArray = s.ToCharArray();
            var tCharArray = t.ToCharArray();

            Array.Sort(sCharArray);
            Array.Sort(tCharArray);

            return Enumerable.SequenceEqual(sCharArray, tCharArray);

        }

        public static Boolean IsPermutationV2(String s, String t)
        {
            if (s.Length != t.Length) return false;

            int[] letters = new int[128]; //ASCII assumption
            var sCharArray = s.ToCharArray();
            var tCharArray = t.ToCharArray();

            for (int i = 0; i < sCharArray.Length; i++)
                letters[sCharArray[i]]++;

            for (int i = 0; i < tCharArray.Length; i++)
            {
                int character = tCharArray[i];
                letters[character]--;
                if (letters[character] < 0)
                    return false;
            }
            return true;
        }

        public static void IsPermutationTest()
        {
            Console.WriteLine($"'abc', 'cba' IsPermutation = {IsPermutationV2("abc", "cba")}");
            Console.WriteLine($"'abc', 'bac' IsPermutation = {IsPermutationV2("abc", "bac")}");
            Console.WriteLine($"'abc', 'bacd' IsPermutation = {IsPermutationV2("abc", "bacd")}");
        }
    }
}

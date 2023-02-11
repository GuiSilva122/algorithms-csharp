using System;
using System.Collections.Generic;

namespace CrackingTheCodeInterview.ArraysAndStrings
{
    internal class PalindromePermutation
    {
        // O(n) time, O(n) space
        public static bool IsPalindromePermutation(string phrase)
        {
            Dictionary<char, int> hash = new Dictionary<char, int>();

            foreach (char letter in phrase)
            {
                if (!char.IsWhiteSpace(letter))
                {
                    var lowerLetter = char.ToLower(letter);
                    if (hash.ContainsKey(lowerLetter))
                        hash[lowerLetter]++;
                    else
                        hash.Add(lowerLetter, 1);
                }
            }

            int oddCount = 0;
            foreach (var item in hash)
            {
                if (oddCount > 1)
                    return false;

                if (item.Value % 2 != 0)
                    oddCount++;
            }
            return true;
        }

        public static bool IsPalindromePermutation2(string phrase)
        {
            int bitVector = CreateBitVectorFromString(phrase);
            return CheckAtMostOneBitSet(bitVector);
        }

        public static bool CheckAtMostOneBitSet(int bitVector)
            => (bitVector & (bitVector - 1)) == 0;

        private static int CreateBitVectorFromString(string phrase)
        {
            int bitVector = 0;
            foreach (char letter in phrase)
            {
                if (!char.IsWhiteSpace(letter))
                {
                    var lowerLetter = GetCharNumber(char.ToLower(letter));
                    bitVector = toggle(bitVector, lowerLetter);
                }
            }
            return bitVector;
        }

        private static int GetCharNumber(char c)
        {
            int a = 'a';
            int z = 'z';

            int val = c;
            if (a <= val && val <= z)
               return val - a;

            return -1;
        }

        public static int toggle(int bitVector, int index)
        {
            if (index < 0) 
                return bitVector;

            int mask = 1 << index;
            if ((bitVector & mask) == 0)
            {
                bitVector |= mask;
            }
            else
            {
                bitVector &= ~mask;
            }
            return bitVector;
        }

        public static void TestSolution()
        {
            String pali = "Rats live on no evil star";
            var result = IsPalindromePermutation2(pali);
        }
    }
}

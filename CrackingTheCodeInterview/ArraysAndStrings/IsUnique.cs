using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodeInterview.ArraysAndStrings
{
    public class IsUniqueQuestion
    {
        /*
        Implement an algorithm to determine if a string has all unique characters.
        What if you cannot use additional data structures?
        */

        //Time:  O(n) where n is the length of the string.
        //Space: O(1) because char_set is constant.
        public static bool IsUnique(string str)
        {
            if (str.Length > 128) return false;
            bool[] char_set = new bool[128];

            for (int i = 0; i < str.Length; i++)
            {
                int val = str[i];
                if (char_set[val]) return false;
                char_set[val] = true;
            }
            return true;
        }

        //Time:  O(n) where n is the length of the string.
        //Space: O(1)
        public static bool IsUniqueV2(string str)
        {
            if (str.Length > 26) return false;

            int checker = 0;
            for (int i = 0; i < str.Length; i++)
            {
                int val = str[i] - 'a';
                if ((checker & (1 << val)) > 0) 
                    return false;

                checker |= (1 << val);
            }
            return true;
        }

        public static void IsUniqueTest()
        {
            String[] words = { "abcde", "hello", "apple", "kite", "padle" };
            foreach (String word in words)
                Console.WriteLine(word + ": " + IsUniqueV2(word));
        }
    }
}

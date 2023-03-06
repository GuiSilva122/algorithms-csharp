using System;

namespace CrackingTheCodeInterview.ArraysAndStrings
{
    public static class URLify
    {
        public static void ReplaceSpaces(char[] str, int trueLength)
        {
            int spaceCount = 0;
            for(int i = 0; i < trueLength; i++)
                if (char.IsWhiteSpace(str[i]))
                    spaceCount++;

            // for each space that we find, we need another 2 characters
            // that's why the final index is added by spaceCount * 2
            int index = (trueLength + spaceCount * 2) - 1;
            
            if (trueLength < str.Length)
                str[trueLength] = '\0';

            for (int i = trueLength - 1; i >= 0; i--)
            {
                if (char.IsWhiteSpace(str[i]))
                {
                    str[index--] = '0';
                    str[index--] = '2';
                    str[index--] = '%';
                }
                else
                {
                    str[index--] = str[i];
                }
            }
        }

        public static int FindLastCharacter(char[] str)
        {
            for (int i = str.Length - 1; i >= 0; i--)
            {
                if (!char.IsWhiteSpace(str[i]))
                    return i;
            }
            return -1;
        }

        public static void TestSolution()
        {
            String str = "Mr John Smith    ";
            char[] arr = str.ToCharArray();
            int trueLength = FindLastCharacter(arr) + 1;

            Console.WriteLine($"Input = {str}");
            ReplaceSpaces(arr, trueLength);
            Console.WriteLine($"Outupt = {new string(arr)}");
        }
    }
}

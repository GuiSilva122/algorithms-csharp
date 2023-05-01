using System.Text;

namespace LeetCode._75
{
    public class Stack_DecodeString
    {
        public string DecodeStringV1(string s)
        {
            var stack = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ']')
                {
                    var decodedString = new List<char>();
                    while (stack.Peek() != '[')
                        decodedString.Add(stack.Pop());
                    
                    stack.Pop();
                    int baseNumber = 1;
                    int k = 0;

                    while (stack.Count > 0 && char.IsDigit(stack.Peek()))
                    {
                        k = k + (stack.Pop() - '0') * baseNumber;
                        baseNumber *= 10;
                    }
                    
                    while (k != 0)
                    {
                        for (int j = decodedString.Count - 1; j >= 0; j--)
                            stack.Push(decodedString[j]);
                        k--;
                    }
                }
                else
                    stack.Push(s[i]);
            }
            char[] result = new char[stack.Count];
            for (int i = result.Length - 1; i >= 0; i--)
                result[i] = stack.Pop();
            
            return new string(result);
        }

        // Assume, n is the length of the string s.
        // O(maxK * n) time, where max K is the maximum value of k
        // O(m + n) space, where m is the number of letters(a-z) and n is the number of digits(0-9) in string s
        public string DecodeStringV2(string s)
        {
            var countStack = new Stack<int>();
            var stringStack = new Stack<StringBuilder>();
            var currentString = new StringBuilder();
            int k = 0;
            foreach (char ch in s)
            {
                if (char.IsDigit(ch))
                {
                    k = k * 10 + ch - '0';
                }
                else if (ch == '[')
                {
                    countStack.Push(k);
                    stringStack.Push(currentString);
                    currentString = new StringBuilder();
                    k = 0;
                }
                else if (ch == ']')
                {
                    var decodedString = stringStack.Pop();
                    for (int currentK = countStack.Pop(); currentK > 0; currentK--)
                        decodedString.Append(currentString);
                    
                    currentString = decodedString;
                }
                else
                    currentString.Append(ch);
            }
            return currentString.ToString();
        }

        // Assume, n is the length of the string s.
        // O(maxK * n) time, where max K is the maximum value of k
        // O(m + n) space, where m is the number of letters(a-z) and n is the number of digits(0-9) in string s
        private static int index = 0;
        public static string DecodeStringV3(string s)
        {
            var result = new StringBuilder();
            while (index < s.Length && s[index] != ']')
            {
                if (!char.IsDigit(s[index]))
                    result.Append(s[index++]);
                else
                {
                    int k = 0;
                    while (index < s.Length && char.IsDigit(s[index]))
                        k = k * 10 + s[index++] - '0';   
                    index++; // ignore the closing bracket ']'
                    string decodedString = DecodeStringV3(s);
                    index++; // ignore the closing bracket ']'
                    while (k-- > 0)
                        result.Append(decodedString);
                }
            }
            return result.ToString();
        }
    }
}
using System.Text;

namespace LeetCode._75
{
    internal class String_LongestCommonPrefix
    {
        public string LongestCommonPrefix(string[] strs)
        {
            if (strs.Length == 1)
                return strs[0];
            int shortestLength = int.MaxValue;
            foreach (var str in strs)
                shortestLength = Math.Min(shortestLength, str.Length);

            var longestCommonPrefix = new StringBuilder();
            var first = strs[0];
            for (int i = 0; i < shortestLength; i++)
            {
                var currentChar = first[i];
                for (int j = 1; j < strs.Length; j++)
                {
                    if (strs[j][i] != currentChar)
                        return longestCommonPrefix.ToString();
                }
                longestCommonPrefix.Append(currentChar);
            }
            return longestCommonPrefix.ToString();
        }
    }
}
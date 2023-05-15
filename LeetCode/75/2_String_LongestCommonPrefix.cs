using System.Text;

namespace LeetCode._75
{
    internal class String_LongestCommonPrefix
    {
        // Vertical Scanning
        // O(S) time, where S is the sum of all characters in all strings.
        // O(1) space
        public string LongestCommonPrefix(string[] strs)
        {
            if (strs == null || strs.Length == 0)
                return string.Empty;
            for (int i = 0; i < strs[0].Length; i++)
            {
                char c = strs[0][i];
                for (int j = 1; j < strs.Length; j++)
                {
                    if (i == strs[j].Length || strs[j][i] != c)
                        return strs[0].Substring(0, i);
                }
            }
            return strs[0];
        }

        // Horizontal Scanning
        // O(S) time, where S is the sum of all characters in all strings.
        // O(1) space
        public string LongestCommonPrefixV2(string[] strs)
        {
            if (strs == null || strs.Length == 0)
                return string.Empty;
            string prefix = strs[0];
            for (int i = 1; i < strs.Length; i++)
            {
                while (strs[i].IndexOf(prefix) != 0)
                {
                    prefix = prefix.Substring(0, prefix.Length - 1);
                    if (string.IsNullOrEmpty(prefix))
                        return string.Empty;
                }
            }
            return prefix;
        }
    }
}
namespace LeetCode.Arrays
{
    internal class LongestCommonPrefix
    {
        // Time complexity : O(S),  where S is the sum of all characters in all strings.
        // Space complexity : O(1), We only used constant extra space.
        // Horizontal Scaling
        public static string GetLongestCommonPrefix(string[] strs)
        {
            if (strs == null || strs.Length == 0) return "";
            var prefix = strs[0];
            for (int i = 1; i < strs.Length; i++)
            {
                while (strs[i].IndexOf(prefix) != 0)
                {
                    prefix = prefix.Substring(0, prefix.Length - 1);

                    if (string.IsNullOrEmpty(prefix))
                        return "";
                }
            }
            return prefix;
        }

        // Time complexity : O(S),  where S is the sum of all characters in all strings.
        // Space complexity : O(1), We only used constant extra space.
        // Vertical Scaling
        public static string GetLongestCommonPrefixV2(string[] strs)
        {
            if (strs == null || strs.Length == 0) return "";
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

        // Divide and Conquer
        // Time complexity : O(S),  where S is the sum of all characters in all strings.
        // Space complexity : O(m log n),There are log⁡ n recursive calls, each store need m space to store the result
        public static string LongestCommonPrefixV3(string[] strs)
        {
            if (strs == null || strs.Length == 0) return "";
            return LongestCommonPrefixV3(strs, 0, strs.Length - 1);
        }

        private static string LongestCommonPrefixV3(string[] strs, int l, int r)
        {
            if (l == r) return strs[l];
            else
            {
                int mid = (l + r) / 2;
                string lcpLeft = LongestCommonPrefixV3(strs, l, mid);
                string lcpRight = LongestCommonPrefixV3(strs, mid + 1, r);
                return CommonPrefix(lcpLeft, lcpRight);
            }
        }

        private static string CommonPrefix(string left, string right)
        {
            int min = Math.Min(left.Length, right.Length);
            for (int i = 0; i < min; i++)
            {
                if (left[i] != right[i])
                    return left.Substring(0, i);
            }
            return left.Substring(0, min);
        }

        // Time complexity : O(S log⁡ m), where S is the sum of all characters in all strings.
        // The algorithm makes log ⁡m iterations, for each of them there are S = mn comparisons
        // Space complexity : O(1)
        // Binary Seach
        public static string LongestCommonPrefixV4(string[] strs)
        {
            if (strs == null || strs.Length == 0)
                return "";

            int minLen = int.MaxValue;

            foreach (var str in strs)
                minLen = Math.Min(minLen, str.Length);

            int low = 1;
            int high = minLen;

            while (low <= high)
            {
                int middle = (low + high) / 2;
                if (IsCommonPrefix(strs, middle))
                    low = middle + 1;
                else
                    high = middle - 1;
            }
            return strs[0].Substring(0, (low + high) / 2);
        }

        private static bool IsCommonPrefix(string[] strs, int len)
        {
            var str1 = strs[0].Substring(0, len);
            for (int i = 1; i < strs.Length; i++)
                if (!strs[i].StartsWith(str1))
                    return false;
            return true;
        }

        public static void TestSolution()
        {
            var strs = new string[] { "flower", "flow", "flight" };
            var result = LongestCommonPrefixV4(strs);

            strs = new string[] { "dog", "racecar", "car" };
            result = GetLongestCommonPrefix(strs);
        }
    }
}

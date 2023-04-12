namespace LeetCode._75
{
    public class IsSubSequence
    {
        private static string source;
        private static string target;
        private static int leftBound;
        private static int rightBound;

        private static bool RecIsSubsequence(int leftIndex, int rightIndex)
        {
            if (leftIndex == leftBound) return true;
            if (rightIndex == rightBound) return false;

            if (source[leftIndex] == target[rightIndex])
                ++leftIndex;
            
            ++rightIndex;

            return RecIsSubsequence(leftIndex, rightIndex);
        }

        // Divide and Conquer with Greedy
        // O(T) time, O(T) space, where T is the length of the target string
        public static bool IsSubsequenceV1(string s, string t)
        {
            source = s;
            target = t;
            leftBound = s.Length;
            rightBound = t.Length;

            return RecIsSubsequence(0, 0);
        }

        // Two pointers
        // O(T) time, O(1) space, where T is the length of the target string
        public static bool IsSubsequenceV2(string s, string t)
        {
            int leftBound = s.Length; 
            int rightBound = t.Length;
            int pLeft = 0;
            int pRight = 0;

            while (pLeft < leftBound && pRight < rightBound) 
            {
                if (s[pLeft] == t[pRight])
                    pLeft++;
                pRight++;
            }
            return pLeft == leftBound;
        }

        // O(S.T) time, O(S.T) space
        public static bool IsSubSequenceV3(string s, string t)
        {
            int sourceLen = s.Length;
            int targetLen = t.Length;
            
            if (sourceLen == 0) return true;

            int[,] dp = new int[sourceLen + 1,targetLen + 1];
            // DP calculation, we fill the matrix column by column, bottom up
            for (int col = 1; col <= targetLen; ++col)
            {
                for (int row = 1; row <= sourceLen; ++row)
                {
                    if (s[row - 1] == t[col - 1])
                        // find another match
                        dp[row,col] = dp[row - 1,col - 1] + 1;
                    else
                        // retrieve the maximal result from previous prefixes
                        dp[row,col] = Math.Max(dp[row,col - 1], dp[row - 1,col]);
                }
                // check if we can consume the entire source string,
                // with the current prefix of the target string.
                if (dp[sourceLen,col] == sourceLen)
                    return true;
            }

            // matching failure
            return false;
        }

        public static void TestSolution()
        {
            var s = "abc";
            var t = "ahbgdc";
            var result = IsSubSequenceV3(s, t);
        }
    }
}
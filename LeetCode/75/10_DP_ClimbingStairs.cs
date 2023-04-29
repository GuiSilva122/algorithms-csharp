namespace LeetCode._75
{
    public class DP_ClimbingStairs
    {
        // Recursive, top down
        // O(2^n) time, O(n) space
        public int ClimbStairsV1(int n)
        {
            if (n <= 2) return n;
            return ClimbStairsV1(n - 1) + ClimbStairsV1(n - 2);
        }

        // Memoization, top down
        // O(n) time, O(n) space
        public int ClimbStairsV2(int n)
        {
            var memo = new Dictionary<int, int>();
            return ClimbStairsHelper(n, memo);
        }
        public int ClimbStairsHelper(int n, Dictionary<int, int> memo)
        {
            if (n <= 2) return n;
            if (memo.ContainsKey(n)) return memo[n];
            memo.Add(n, ClimbStairsHelper(n - 1, memo) + ClimbStairsHelper(n - 2, memo));
            return memo[n];
        }

        // Tabulation, bottom up
        // O(n) time, O(n) space
        public int ClimbStairsV3(int n)
        {
            if (n <= 2) return n;
            var table = new int[n + 1];
            table[1] = 1;
            table[2] = 2;
            for (int i = 3; i <= n; i++)
            {
                table[i] = table[i - 1] + table[i - 2];
            }
            return table[n];
        }

        
        // Iterative, bottom up
        // O(n) time, O(1) space
        public int ClimbStairsV4(int n)
        {
            if (n <= 2) return n;
            int first = 1;
            int second = 2;
            for (int i = 3; i <= n; i++)
            {
                var temp = first + second;
                first = second;
                second = temp;
            }
            return second;
        }
    }
}
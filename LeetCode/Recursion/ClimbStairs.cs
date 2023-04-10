namespace LeetCode.Recursion
{
    public static class ClimbStairs
    {
        // V1 Brute Force
        // climbStairs(i, n) = (i+1,n)+climbStairs(i+2, n)
        // O(2^n) time, O(n) space
        public static int ClimbStairsV1(int n)
        {
            return ClimbStairsV1(n, 0);
        }

        private static int ClimbStairsV1(int totalSteps, int currentStep)
        {
            if (currentStep > totalSteps)
                return 0;

            if (currentStep == totalSteps)
                return 1;

            return ClimbStairsV1(totalSteps, currentStep + 1) + ClimbStairsV1(totalSteps, currentStep + 2);
        }

        // V2 Using memoization
        // climbStairs(i, n) = (i+1,n)+climbStairs(i+2, n)
        // O(n) time, O(n) space
        public static int ClimbStairsV2(int n)
        {
            var memo = new int[n + 1];
            return ClimbStairsV2(n, 0, memo);
        }

        private static int ClimbStairsV2(int totalSteps, int currentStep, int[] memo)
        {
            if (currentStep > totalSteps)
                return 0;

            if (currentStep == totalSteps)
                return 1;

            if (memo[currentStep] > 0)
                return memo[currentStep];

            memo[currentStep] = ClimbStairsV1(totalSteps, currentStep + 1) + ClimbStairsV1(totalSteps, currentStep + 2);
            return memo[currentStep];
        }

        // V3 Dynamic programming
        // O(n) time, O(n) space
        public static int ClimbStairsV3(int n)
        {
            if (n == 1) return 1;

            int[] dp = new int[n + 1];
            dp[1] = 1;
            dp[2] = 2;
            for (int i = 3; i <= n; i++)
                dp[i] = dp[i - 1] + dp[i - 2];

            return dp[n];
        }

        // V4 Fibonacci number
        // O(n) time, O(1) space
        public static int ClimbStairsV4(int n)
        {
            if (n == 1) return 1;
            if (n == 2) return 2;

            var fib = new int[2];
            fib[0] = 1;
            fib[1] = 2;
            for (int i = 3; i <= n; i++)
            {
                var next = fib[0] + fib[1];
                fib[0] = fib[1];
                fib[1] = next;
            }

            return fib[1];
        }
    }
}

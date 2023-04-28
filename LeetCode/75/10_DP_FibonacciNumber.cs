namespace LeetCode._75
{
    public class DP_FibonacciNumber
    {
        // Recursive
        // O(2^n) time, O(n) space
        public int Fib(int n)
        {
            if (n <= 1) return n;
            return Fib(n - 1) + Fib(n - 2);
        }

        // Memoization, Top-Down
        // O(n) time, O(n) space
        public int FibV2(int n, Dictionary<int, int> cache = null)
        {
            if (n <= 1)
                return n;
            if (cache.ContainsKey(n))
                return cache[n];

            cache.Add(n, FibV2(n - 1, cache) + FibV2(n - 2, cache));
            return cache[n];
        }

        // Tabulation, Bottom-Up
        // O(n) time, O(n) space
        public int FibV3(int N)
        {
            if (N <= 1) 
                return N;
            int[] cache = new int[N + 1];
            cache[1] = 1;
            for (int i = 2; i < cache.Length; i++)
                cache[i] = cache[i - 1] + cache[i - 2];
            return cache[N];
        }

        // Iterative, Bottom-Up
        // O(n) time, O(1) space
        public int FibV4(int n)
        {
            if (n <= 1)
                return n;
            int first = 0;
            int second = 1;
            for (int i = 2; i <= n; i++)
            {
                int temp = first + second;
                first = second;
                second = temp;
            }
            return second;
        }
    }
}

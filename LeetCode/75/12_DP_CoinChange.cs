namespace LeetCode._75
{
    public  class _12_DP_CoinChange
    {
        // Recursive brutal force
        // Where s is the amount and n is the number of coins
        // O (s^n) time, O(n) space
        public int CoinChangeV1(int[] coins, int amount)
        {
            return CoinChangeHelper(coins, amount);
        }
        public int CoinChangeHelper(int[] coins, int amount)
        {
            if (amount < 0) return -1;
            if (amount == 0) return 0;
            int minimumNumberOfCoins = int.MaxValue;
            foreach (var coin in coins)
            {
                var remainder = amount - coin;
                var remainderResult = CoinChangeHelper(coins, remainder);
                if (remainderResult == -1)
                    continue;
                minimumNumberOfCoins = Math.Min(minimumNumberOfCoins, remainderResult + 1);
            }
            return minimumNumberOfCoins == int.MaxValue ? -1 : minimumNumberOfCoins;
        }

        // Recursive With Memoization
        // Where s is the amount and n is the number of coins
        // O (sn) time, O(s) space
        public int CoinChangeV2(int[] coins, int amount)
        {
            var memo = new int[amount + 1];
            Array.Fill(memo, -2);
            return CoinChangeHelper(coins, amount, memo);
        }
        public int CoinChangeHelper(int[] coins, int amount, int[] memo)
        {
            if (amount < 0) return -1;
            if (amount == 0) return 0;
            if (memo[amount] != -2) return memo[amount];
            int minimumNumberOfCoins = int.MaxValue;
            foreach (var coin in coins)
            {
                var remainder = amount - coin;
                var remainderResult = CoinChangeHelper(coins, remainder, memo);
                if (remainderResult == -1)
                    continue;
                minimumNumberOfCoins = Math.Min(minimumNumberOfCoins, remainderResult + 1);
            }
            memo[amount] = minimumNumberOfCoins == int.MaxValue ? -1 : minimumNumberOfCoins;
            return memo[amount];
        }

        // Dynamic Programming tabulation bottom up
        // O (sn) time, O(s) space
        public int CoinChangeV3(int[] coins, int amount)
        {
            if (amount < 0) return -1;
            if (amount == 0) return 0;
            var table = new int[amount + 1];
            Array.Fill(table, amount + 1);
            table[0] = 0;
            for (int i = 1; i <= amount; i++)
            {
                foreach (var coin in coins)
                {
                    if (i - coin < 0)
                        continue;
                    table[i] = Math.Min(table[i], table[i - coin] + 1);
                }
            }
            return table[amount] == (amount + 1) ? -1 : table[amount];
        }
    }
}
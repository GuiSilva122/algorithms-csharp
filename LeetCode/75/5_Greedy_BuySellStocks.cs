namespace LeetCode._75
{
    public class Greedy_BuySellStocks
    {
        // O(n) time, O(1) space
        public int MaxProfit(int[] prices)
        {
            int minPrice = int.MaxValue;
            int maxProfit = 0;
            for (int i = 0; i < prices.Length; i++)
            {
                if (prices[i] < minPrice)
                    minPrice = prices[i];
                else if (prices[i] - minPrice > maxProfit)
                    maxProfit = prices[i] - minPrice;
            }
            return maxProfit;
        }
    }
}
namespace LeetCode._75
{
    public class DP_MinCostClimbingStairs
    {
        // Bottom-Up Dynamic Programming (Tabulation)
        // O(n) time, O(n) space
        public int MinCostClimbingStairsV1(int[] cost)
        {
            var minimumCost = new int[cost.Length + 1];
            for (int i = 2; i < minimumCost.Length; i++)
            {
                int takeOneStep = minimumCost[i - 1] + cost[i - 1];
                int takeTwoSteps = minimumCost[i - 2] + cost[i - 2];
                minimumCost[i] = Math.Min(takeOneStep, takeTwoSteps);
            }
            return minimumCost[minimumCost.Length - 1];
        }

        // Top-Down Dynamic Programming (Recursion + Memoization)
        // O(n) time, O(n) space
        public int MinCostClimbingStairsV2(int[] cost)
        {
            var memo = new Dictionary<int, int>();
            return MinCostClimbingStairsV2Helper(cost, cost.Length, memo);
        }

        public int MinCostClimbingStairsV2Helper(int[] cost, int step, Dictionary<int, int> memo)
        {
            if (step <= 1) return 0;
            if (!memo.ContainsKey(step))
            {
                int downOne = cost[step - 1] + MinCostClimbingStairsV2Helper(cost, step - 1, memo);
                int downTwo = cost[step - 2] + MinCostClimbingStairsV2Helper(cost, step - 2, memo);
                memo.Add(step, Math.Min(downOne, downTwo));
            }
            return memo[step];
        }

        // Bottom-Up Iterative Approach
        // O(n) time, O(1) space
        public int MinCostClimbingStairsV4(int[] cost)
        {
            var firstStep = 0;
            var secondStep = 0;
            for (int i = 2; i < cost.Length + 1; i++)
            {
                var temp = firstStep;
                firstStep = Math.Min(firstStep + cost[i - 1], secondStep + cost[i - 2]);
                secondStep = temp;
            }
            return firstStep;
        }
    }
}
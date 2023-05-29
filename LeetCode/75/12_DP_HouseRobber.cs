namespace LeetCode._75
{
    public class DP_HouseRobber
    {
        // Recursive bottom up
        // O(2^n) time, O(n) space
        public int RobV1(int[] nums)
        {
            return RobHelper(nums, 0);
        }
        public int RobHelper(int[] nums, int index)
        {
            if (index >= nums.Length)
                return 0;
            return Math.Max(RobHelper(nums, index + 1), RobHelper(nums, index + 2) + nums[index]);
        }

        // Recursive bottom up Memoization
        // O(2^n) time, O(n) space
        public int RobV2(int[] nums)
        {
            var memo = new Dictionary<int, int>();
            return RobHelper(nums, 0, memo);
        }
        public int RobHelper(int[] nums, int house, Dictionary<int, int> memo)
        {
            if (house >= nums.Length)
                return 0;
            if (memo.ContainsKey(house))
                return memo[house];
            memo.Add(house, Math.Max(RobHelper(nums, house + 1, memo), RobHelper(nums, house + 2, memo) + nums[house]));
            return memo[house];
        }

        // Tabulation top down
        // O(n) time, O(n) space
        public int RobV3(int[] nums)
        {
            int N = nums.Length;
            if (N == 0) return 0;
            var table = new int[N + 1];
            // The robber doesn't have any houses left to rob, thus zero profit.
            table[N] = 0;
            // because there is only one house to rob which is the last house.
            table[N - 1] = nums[N - 1];
            for (int i = N - 2; i >= 0; i--)
                table[i] = Math.Max(table[i + 1], table[i + 2] + nums[i]);
            return table[0];
        }

        // Tabulation top down, optmized space
        // O(n) time, O(1) space
        public int RobV4(int[] nums)
        {
            int N = nums.Length;
            if (N == 0) return 0;
            // The robber doesn't have any houses left to rob, thus zero profit.        
            // because there is only one house to rob which is the last house.
            int robNextPlusOne = 0;
            int robNext = nums[N - 1];
            for (int i = N - 2; i >= 0; i--)
            {
                int current = Math.Max(robNext, robNextPlusOne + nums[i]);
                robNextPlusOne = robNext;
                robNext = current;
            }
            return robNext;
        }
    }
}
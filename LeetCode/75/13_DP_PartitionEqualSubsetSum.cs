namespace LeetCode._75
{
    public class DP_PartitionEqualSubsetSum
    {
        // O(2^n) time, O(n) space
        public bool CanPartitionV1(int[] nums)
        {
            int totalSum = 0;
            foreach (var num in nums)
                totalSum += num;
            if (totalSum % 2 != 0)
                return false;
            return CanPartitionHelper(nums, 0, totalSum / 2);
        }
        public bool CanPartitionHelper(int[] nums, int index, int sum)
        {
            if (sum == 0) return true;
            if (sum < 0 || index == nums.Length) return false;
            return CanPartitionHelper(nums, index + 1, sum - nums[index]) || CanPartitionHelper(nums, index + 1, sum);
        }

        // O(mn) time, O(mn) space
        public bool CanPartitionV2(int[] nums)
        {
            int totalSum = 0;
            foreach (var num in nums)
                totalSum += num;
            if (totalSum % 2 != 0)
                return false;
            int subSetSum = totalSum / 2;
            int n = nums.Length;
            var memo = new bool?[n + 1, subSetSum + 1];
            return Dfs(nums, n - 1, subSetSum, memo);
        }
        public bool Dfs(int[] nums, int n, int subSetSum, bool?[,] memo)
        {
            if (subSetSum == 0)
                return true;
            if (n == 0 || subSetSum < 0)
                return false;
            if (memo[n, subSetSum] != null)
                return memo[n, subSetSum].Value;
            bool result = Dfs(nums, n - 1, subSetSum - nums[n - 1], memo) ||
                          Dfs(nums, n - 1, subSetSum, memo);
            memo[n, subSetSum] = result;
            return result;
        }

        // O(mn) time, O(mn) space
        public bool CanPartitionV3(int[] nums)
        {
            int totalSum = 0;
            foreach (var num in nums)
                totalSum += num;
            if (totalSum % 2 != 0) return false;
            int subSetSum = totalSum / 2;
            int n = nums.Length;
            var dp = new bool[n + 1, subSetSum + 1];
            dp[0, 0] = true;
            for (int i = 1; i <= n; i++)
            {
                int curr = nums[i - 1];
                for (int j = 0; j <= subSetSum; j++)
                {
                    if (j < curr)
                        dp[i, j] = dp[i - 1, j];
                    else
                        dp[i, j] = dp[i - 1, j] || (dp[i - 1, j - curr]);
                }
            }
            return dp[n, subSetSum];
        }

        // O(mn) time, O(m) space
        public bool CanPartitionV4(int[] nums)
        {
            if (nums.Length == 0) return false;
            int totalSum = 0;
            foreach (int num in nums) totalSum += num;
            if (totalSum % 2 != 0) return false;
            int subSetSum = totalSum / 2;
            var dp = new bool[subSetSum + 1];
            dp[0] = true;
            foreach (int curr in nums)
            {
                for (int j = subSetSum; j >= curr; j--)
                {
                    dp[j] |= dp[j - curr];
                }
            }
            return dp[subSetSum];
        }
    }
}
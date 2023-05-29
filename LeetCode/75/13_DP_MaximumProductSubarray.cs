namespace LeetCode._75
{
    public class DP_MaximumProductSubarray
    {
        // Brute Force
        // O(N^2) time, O(1) space
        public int MaxProductV1(int[] nums)
        {
            if (nums.Length == 0) return 0;
            int result = nums[0];
            for (int i = 0; i < nums.Length; i++)
            {
                int accu = 1;
                for (int j = i; j < nums.Length; j++)
                {
                    accu *= nums[j];
                    result = Math.Max(result, accu);
                }
            }
            return result;
        }

        // Dynamic Programming
        // O(N) time, O(1) space
        public int MaxProduct(int[] nums)
        {
            if (nums.Length == 0)
                return 0;
            int maxSoFar = nums[0];
            int minSoFar = nums[0];
            int answer = maxSoFar;
            for (int i = 1; i < nums.Length; i++)
            {
                int current = nums[i];
                int tempMax = Math.Max(current, Math.Max(maxSoFar * current, minSoFar * current));
                minSoFar = Math.Min(current, Math.Min(maxSoFar * current, minSoFar * current));
                maxSoFar = tempMax;
                answer = Math.Max(maxSoFar, answer);
            }
            return answer;
        }
    }
}
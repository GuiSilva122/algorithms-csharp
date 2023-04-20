namespace LeetCode._75
{
    public class RunningSums
    {
        public int[] RunningSum(int[] nums)
        {
            for (int i = 1; i < nums.Length; i++)
                nums[i] += nums[i - 1];
            return nums;
        }
    }
}

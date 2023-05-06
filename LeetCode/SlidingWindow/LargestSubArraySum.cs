namespace LeetCode.SlidingWindow
{
    public class LargestSubArraySum
    {
        public int FindBestSubarray(int[] nums, int k)
        {
            int curr = 0;
            for (int i = 0; i < k; i++)
                curr += nums[i];
            
            int answer = curr;
            for (int i = k; i < nums.Length; i++)
            {
                curr += nums[i] - nums[i - k];
                answer = Math.Max(answer, curr);
            }
            return answer;
        }
    }
}

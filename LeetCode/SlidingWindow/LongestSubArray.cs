namespace LeetCode.SlidingWindow
{
    public class LongestSubArray
    {
        public int GetLongestSubArray(int[] nums, int k)
        {
            int left = 0;
            int curr = 0;
            int answer = 0;
            for (int end = 0; end < nums.Length; end++)
            {
                curr += nums[end];
                while (curr > k)
                {
                    curr -= nums[left];
                    left++;
                }
                answer = Math.Max(answer, end - left + 1);
            }
            return answer;
        }
    }
}
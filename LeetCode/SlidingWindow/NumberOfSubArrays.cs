namespace LeetCode.SlidingWindow
{
    public class NumberOfSubArrays
    {
        public int GetNumberOfSubArrays(int[] nums, int k)
        {
            if (k <= 1) 
                return 0;

            int left = 0;
            int curr = 1;
            int answer = 0;
            for (int right = 0; right < nums.Length; right++)
            {
                curr *= nums[right];
                while (curr >= k)
                {
                    curr /= nums[left];
                    left++;
                }
                answer += right - left + 1;
            }
            return answer;
        }
    }
}
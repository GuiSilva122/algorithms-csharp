namespace LeetCode._75
{
    public class PivotIndex
    {
        public int FindPivotIndex(int[] nums)
        {
            var totalSum = 0;
            for (int i = 0; i < nums.Length; i++)
                totalSum += nums[i];

            var sumLeft = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                var sumRight = totalSum - sumLeft - nums[i];
                if (sumLeft == sumRight)
                    return i;
                sumLeft += nums[i];
            }
            return -1;
        }
    }
}

namespace LeetCode._75
{
    public class BitOperation_SingleNumber
    {
        public int SingleNumber(int[] nums)
        {
            var result = 0;
            for (int i = 0; i < nums.Length; i++)
                result ^= nums[i];
            return result;
        }
    }
}
namespace LeetCode
{
    public class RemoveElement
    {
        public static int RemoveElementFromArray(int[] nums, int val)
        {
            int i = 0;
            for (int j = 0; j < nums.Length; j++)
            {
                if (nums[j] != val)
                {
                    nums[i] = nums[j];
                    i++;
                }
            }
            return i;
        }

        public static void TestSolution()
        {
            var nums = new int[] { 3, 2, 2, 3};
            var result = RemoveElementFromArray(nums, 3);
        }
    }
}

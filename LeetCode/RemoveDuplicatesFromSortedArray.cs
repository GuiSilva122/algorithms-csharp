namespace LeetCode
{
    public static class RemoveDuplicatesFromSortedArray
    {
        public static int Remove(int[] nums)
        {
            int insertIndex = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i - 1] != nums[i])
                {
                    nums[insertIndex] = nums[i];
                    insertIndex++;
                }
            }
            return insertIndex;
        }


        public static void TestSolution()
        {
            var array = new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            var k = Remove(array);
        }
    }
}

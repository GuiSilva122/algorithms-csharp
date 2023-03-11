namespace LeetCode
{
    public static class SearchInsertPosition
    {
        public static int SearchInsert(int[] nums, int target)
        {
            int init = 0, end = nums.Length - 1;
            while (init <= end)
            {
                var mid = init + (end - init) / 2;
                if (target == nums[mid])
                    return mid;
                else if (target < nums[mid])
                    end = mid - 1;
                else
                    init = mid + 1;
            }
            return init;
        }

        public static void TestSolution()
        {
            var nums = new int[] { 1, 3, 5, 6 };
            var target = 5;
            var result = SearchInsert(nums, target);
            var expected = 2;
            Console.WriteLine($"Expected = {expected}, Result = {result}");

            target = 2;
            result = SearchInsert(nums, target);
            expected = 1;
            Console.WriteLine($"Expected = {expected}, Result = {result}");

            nums = new int[] { 1, 3, 5, 6 };
            target = 7;
            result = SearchInsert(nums, target);
            expected = 4;
            Console.WriteLine($"Expected = {expected}, Result = {result}");
        }
    }
}

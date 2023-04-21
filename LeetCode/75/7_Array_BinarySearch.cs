namespace LeetCode._75
{
    public class Array_BinarySearch
    {
        // O(log(n)) time, O(1) space
        public int Search(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;
            while (left <= right)
            {
                int pivot = left + (right - left) / 2;
                if (target == nums[pivot])
                    return pivot;
                else if (target < nums[pivot])
                    right = pivot - 1;
                else if (target > nums[pivot])
                    left = pivot + 1;
            }
            return -1;
        }
    }
}

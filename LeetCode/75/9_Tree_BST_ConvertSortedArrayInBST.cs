using LeetCode._75.Helper;

namespace LeetCode._75
{
    public class Tree_BST_ConvertSortedArrayInBST
    {
        public TreeNode SortedArrayToBST(int[] nums)
            => SortedArrayToBSTHelper(nums, 0, nums.Length - 1);

        private TreeNode SortedArrayToBSTHelper(int[] nums, int init, int end)
        {
            if (init > end)
                return null;
            int mid = init + (end - init) / 2;
            var left = SortedArrayToBSTHelper(nums, init, mid - 1);
            var right = SortedArrayToBSTHelper(nums, mid + 1, end);
            var node = new TreeNode(nums[mid], left, right);
            return node;
        }
    }
}
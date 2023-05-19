using LeetCode._75.Helper;

namespace LeetCode._75
{
    public class Tree_BST_KthSmallestInBST
    {
        // O(n) time, O(n) space
        public int KthSmallest(TreeNode root, int k)
        {
            var nums = new List<int>();
            InOrder(root, nums);
            return nums[k - 1];
        }
        private void InOrder(TreeNode root, List<int> nums)
        {
            if (root == null)
                return;
            InOrder(root.left, nums);
            nums.Add(root.val);
            InOrder(root.right, nums);
        }

        // O(h + k), O(h) space, where h is the height of the tree
        public int KthSmallestV2(TreeNode root, int k)
        {
            if (root == null)
                return 0;
            var stack = new Stack<TreeNode>();
            while (root != null || stack.Count > 0)
            {
                while (root != null)
                {
                    stack.Push(root);
                    root = root.left;
                }
                root = stack.Pop();
                if (--k == 0)
                    return root.val;
                root = root.right;
            }
            return -1;
        }
    }
}
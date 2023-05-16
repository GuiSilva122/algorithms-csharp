using LeetCode._75.Helper;

namespace LeetCode._75
{
    public class Tree_BalancedBinaryTree
    {
        // O(n logn) time, O(n) space
        public bool IsBalancedV1(TreeNode root)
        {
            if (root == null)
                return true;
            return Math.Abs(Height(root.left) - Height(root.right)) < 2
                   && IsBalancedV1(root.left) && IsBalancedV1(root.right);
        }
        private int Height(TreeNode root)
        {
            if (root == null) return -1;
            return 1 + Math.Max(Height(root.left), Height(root.right));
        }

        // O(n) time, O(n) space
        private record TreeInfo(int Height, bool Balanced);
        public bool IsBalancedV2(TreeNode root)
        {
            return IsBalancedTreeHelper(root).Balanced;
        }

        private TreeInfo IsBalancedTreeHelper(TreeNode root)
        {
            if (root == null)
                return new TreeInfo(-1, true);

            var left = IsBalancedTreeHelper(root.left);
            if (!left.Balanced)
                return new TreeInfo(-1, false);

            var right = IsBalancedTreeHelper(root.right);
            if (!right.Balanced)
                return new TreeInfo(-1, false);

            if (Math.Abs(left.Height - right.Height) < 2)
                return new TreeInfo(Math.Max(left.Height, right.Height) + 1, true);

            return new TreeInfo(-1, false);
        }
    }
}
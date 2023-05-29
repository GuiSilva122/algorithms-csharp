using LeetCode._75.Helper;

namespace LeetCode._75
{
    public class Tree_SymetricTree
    {
        public bool IsSymmetric(TreeNode root)
        {
            return IsMirror(root, root);
        }
        private bool IsMirror(TreeNode a, TreeNode b)
        {
            if (a == null && b == null) return true;
            if (a == null || b == null) return false;
            if (a.val != b.val) return false;
            return IsMirror(a.right, b.left) && IsMirror(a.left, b.right);
        }
    }
}
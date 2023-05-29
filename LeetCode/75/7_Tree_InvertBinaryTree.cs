using LeetCode._75.Helper;

namespace LeetCode._75
{
    public class _7_Tree_InvertBinaryTree
    {
        // O(n) time, O(n) space
        public TreeNode InvertTree(TreeNode root)
        {
            if (root != null)
            {
                InvertTree(root.left);
                InvertTree(root.right);
                (root.left, root.right) = (root.right, root.left);
            }
            return root;
        }
        // O(n) time, O(n) space
        public TreeNode InvertTreeV2(TreeNode root)
        {
            if (root == null)
                return null;
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                (current.left, current.right) = (current.right, current.left);
                if (current.left != null)
                    queue.Enqueue(current.left);
                if (current.right != null)
                    queue.Enqueue(current.right);
            }
            return root;
        }
    }
}

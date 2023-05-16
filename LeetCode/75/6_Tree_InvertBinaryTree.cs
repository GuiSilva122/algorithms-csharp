using LeetCode._75.Helper;

namespace LeetCode._75
{
    public class Tree_InvertBinaryTree
    {
        public TreeNode InvertTreeV1(TreeNode root)
        {
            if (root == null)
                return null;
            var right = InvertTreeV1(root.right);
            var left = InvertTreeV1(root.left);
            root.left = right;
            root.right = left;
            return root;
        }

        public TreeNode InvertTree(TreeNode root)
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

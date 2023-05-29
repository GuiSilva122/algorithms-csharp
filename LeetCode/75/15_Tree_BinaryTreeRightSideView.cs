using LeetCode._75.Helper;

namespace LeetCode._75
{
    public class Tree_BinaryTreeRightSideView
    {
        // O(n) time, O(d) space, where d is tree diameter
        public IList<int> RightSideView(TreeNode root)
        {
            var result = new List<int>();
            var queue = new Queue<(TreeNode, int)>();
            queue.Enqueue((root, 0));
            int lastLevel = -1;
            while (queue.Count > 0)
            {
                var (node, level) = queue.Dequeue();
                if (node != null)
                {
                    if (lastLevel != level)
                    {
                        result.Add(node.val);
                        lastLevel = level;
                    }
                    queue.Enqueue((node.right, level + 1));
                    queue.Enqueue((node.left, level + 1));
                }
            }
            return result;
        }

        // O(n) time, O(h) space, where h is the height of the tree
        public IList<int> RightSideViewV2(TreeNode root)
        {
            var result = new List<int>();
            if (root == null) return result;
            RightSideViewHelper(root, 0, result);
            return result;
        }
        private void RightSideViewHelper(TreeNode root, int level, List<int> result)
        {
            if (level == result.Count)
                result.Add(root.val);
            if (root.right != null)
                RightSideViewHelper(root.right, level + 1, result);
            if (root.left != null)
                RightSideViewHelper(root.left, level + 1, result);
        }
    }
}
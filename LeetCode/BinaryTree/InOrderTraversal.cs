using LeetCode.BinaryTree.Helper;

namespace LeetCode.BinaryTree
{
    public class InOrderTraversal
    {
        // Recursive approach
        // O(n) time, O(n) space
        public IList<int> InorderTraversalV1(TreeNode root)
        {
            var res = new List<int>();
            Helper(root, res);
            return res;
        }

        private void Helper(TreeNode root, List<int> res)
        {
            if (root != null)
            {
                Helper(root.left, res);
                res.Add(root.val);
                Helper(root.right, res);
            }
        }

        // Iterating method using Stack
        // O(n) time, O(n) space
        public List<int> InorderTraversalV2(TreeNode root)
        {
            var res = new List<int>();
            var stack = new Stack<TreeNode>();
            var curr = root;

            while (curr != null || stack.Count > 0)
            {
                while (curr != null)
                {
                    stack.Push(curr);
                    curr = curr.left;
                }
                curr = stack.Pop();
                res.Add(curr.val);
                curr = curr.right;
            }
            return res;
        }
    }
}
using LeetCode._75.Helper;

namespace LeetCode._75
{
    public class Tree_BST_BSTIterator
    {
        // O(n) time, O(n) space
        public class BSTIteratorV1
        {
            
            private List<int> sortedNodes;
            private int currentIndex;
            // O(n) time, O(n) space
            public BSTIteratorV1(TreeNode root)
            {
                currentIndex = -1;
                sortedNodes = new List<int>();
                InOrder(root);
            }
            private void InOrder(TreeNode root)
            {
                if (root == null)
                    return;
                InOrder(root.left);
                sortedNodes.Add(root.val);
                InOrder(root.right);
            }
            // O(1) time
            public int Next() => sortedNodes[++currentIndex];
            // O(1) time
            public bool HasNext() => currentIndex + 1 < sortedNodes.Count;
        }

        public class BSTIteratorV2
        {
            // O(1) time amortized, O(n) space
            private Stack<TreeNode> stack;
            public BSTIteratorV2(TreeNode root)
            {
                stack = new Stack<TreeNode>();
                leftmostInorder(root);
            }

            private void leftmostInorder(TreeNode root)
            {
                while (root != null)
                {
                    this.stack.Push(root);
                    root = root.left;
                }
            }
            // O(1) time amortized
            public int Next()
            {
                var next = stack.Pop();
                if (next.right != null)
                    leftmostInorder(next.right);
                return next.val;
            }
            // O(1) time
            public bool HasNext() => stack.Count > 0;
        }
    }
}

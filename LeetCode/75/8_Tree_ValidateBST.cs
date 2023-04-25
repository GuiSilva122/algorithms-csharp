namespace LeetCode._75
{
    public class _8_Tree_ValidateBST
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        public class Solution
        {
            public bool IsValidBSTV1(TreeNode root)
            {
                return IsValidBSTRecursion(root, null);
            }

            public bool IsValidBSTRecursion(TreeNode root, int? prev)
            {
                if (root == null) 
                    return true;

                if (!IsValidBSTRecursion(root.left, null))
                    return false;

                if (prev.HasValue && root.val <= prev.Value) 
                    return false;
                
                prev = root.val;
                return IsValidBSTRecursion(root.right, prev);
            }

            public bool IsValidBSTV2(TreeNode root)
            {
                if (root == null) 
                    return true;

                int? prev = null;
                var stack = new Stack<TreeNode>();
                while (stack.Count > 0 || root != null)
                {
                    while (root != null)
                    {
                        stack.Push(root);
                        root = root.left;
                    }
                    root = stack.Pop();
                    if (prev.HasValue && root.val <= prev.Value)
                        return false;
                    prev = root.val;
                    root = root.right;
                }
                return true;
            }
        }
    }
}
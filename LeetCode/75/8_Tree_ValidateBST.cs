namespace LeetCode._75
{
    public class Tree_ValidateBST
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

        public static bool IsValidBSTV2(TreeNode root)
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

        public static void TestSolution()
        {
            var left = new TreeNode(1);
            var right = new TreeNode(7, new TreeNode(5), new TreeNode(8));
            var root = new TreeNode(4, left, right);
            var result = IsValidBSTV2(root);
        }

        private bool IsPangram(string sentence)
        {
            int[] frequencyCount = new int[26];
            foreach (char c in sentence)
                frequencyCount[c - 'a']++;

            foreach (int count)
        }
    }
}
namespace LeetCode._75
{
    public class Tree_BSTLevelOrderTraversal
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

        // Recursive
        // O(n) time, O(n) space
        public IList<IList<int>> LevelOrderV1(TreeNode root)
        {
            IList<IList<int>> result = new List<IList<int>>();
            LevelOrderV1Recursive(root, 0, result);
            return result;
        }

        private void LevelOrderV1Recursive(TreeNode root, int level, IList<IList<int>> result)
        {
            if (root == null) return;

            if (result.Count == level)
                result.Add(new List<int>());
            
            result[level].Add(root.val);

            if (root.left != null) 
                LevelOrderV1Recursive(root.left, level + 1, result);
            if (root.right != null) 
                LevelOrderV1Recursive(root.right, level + 1, result);
        }

        // Iteration
        // O(n) time, O(n) space
        public IList<IList<int>> LevelOrderV2(TreeNode root)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (root == null) return result;

            var queue = new Queue<TreeNode>();
            int level = 0;
            while (queue.Count > 0)
            {
                result.Add(new List<int>());
                int levelLength = queue.Count;
                for (int i = 0; i < levelLength; i++)
                {
                    var node = queue.Dequeue();
                    result[level].Add(node.val);

                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                }
                level++;
            }
            return result;
        }
    }
}
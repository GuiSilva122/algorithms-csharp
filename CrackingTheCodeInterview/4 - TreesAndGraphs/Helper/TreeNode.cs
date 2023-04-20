namespace CrackingTheCodeInterview.TreesAndGraphs.Helper
{
    public class TreeNode
    {
        public int data;
        public TreeNode left;
        public TreeNode right;
        public TreeNode parent;
        public TreeNode(int d) => data = d;

        private void SetLeftChild(TreeNode left)
        {
            this.left = left;
            if (left != null)
                left.parent = this;
        }

        private void SetRightChild(TreeNode right)
        {
            this.right = right;
            if (right != null)
                right.parent = this;
        }

        private static TreeNode CreateMinimalBST(int[] arr, int start, int end)
        {
            if (end < start) return null;
            
            int mid = (start + end) / 2;
            
            var n = new TreeNode(arr[mid]);
            n.SetLeftChild(CreateMinimalBST(arr, start, mid - 1));
            n.SetRightChild(CreateMinimalBST(arr, mid + 1, end));
            
            return n;
        }

        public static TreeNode CreateMinimalBST(int[] array)
            => CreateMinimalBST(array, 0, array.Length - 1);
    }
}
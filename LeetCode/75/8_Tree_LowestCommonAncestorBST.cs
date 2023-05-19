using LeetCode._75.Helper;

namespace LeetCode._75
{
    public class Tree_LowestCommonAncestorBST
    {
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root.val < p.val && root.val < q.val)
                return LowestCommonAncestor(root.right, p, q);
            else if (root.val > p.val && root.val > q.val)
                return LowestCommonAncestor(root.left, p, q);
            return root;
        }

        public TreeNode LowestCommonAncestorV2(TreeNode root, TreeNode p, TreeNode q)
        {
            var node = root;
            while (node != null)
            {
                if (node.val < p.val && node.val < q.val)
                    node = node.right;
                else if (node.val > p.val && node.val > q.val)
                    node = node.left;
                else
                    return node;
            }
            return node;
        }
    }
}
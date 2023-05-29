using LeetCode._75.Helper;

namespace LeetCode._75
{
    public  class Tree_SameTree
    {
        // O(n) time, O(n) space
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
                return true;
            if (p == null || q == null)
                return false;
            if (p.val != q.val)
                return false;
            return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
        }

        // O(n) time, O(n) space
        public bool IsSameTreeV2(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
                return true;
            var queue = new Queue<(TreeNode, TreeNode)>();
            queue.Enqueue((p, q));
            while (queue.Count > 0)
            {
                var (currentP, currentQ) = queue.Dequeue();
                if (currentP == null && currentQ == null)
                {
                    if (queue.Count == 0)
                        return true;
                    else
                        continue;
                }
                if (currentP == null || currentQ == null)
                    return false;
                if (currentP.val != currentQ.val)
                    return false;
                queue.Enqueue((currentP.left, currentQ.left));
                queue.Enqueue((currentP.right, currentQ.right));
            }
            return true;
        }
    }
}
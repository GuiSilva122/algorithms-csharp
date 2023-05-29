using LeetCode._75.Helper;

namespace LeetCode._75
{
    public class Tree_PathSum
    {
        int count = 0;
        int k;
        Dictionary<long, int> h = new Dictionary<long, int>();
        public int PathSum(TreeNode root, int sum)
        {
            k = sum;
            h.Add(0, 1);
            Preorder(root, 0);
            return count;
        }
        public void Preorder(TreeNode node, long currSum)
        {
            if (node == null)
                return;

            currSum += node.val;
            count += h.GetValueOrDefault(currSum - k, 0);
            h[currSum] = h.GetValueOrDefault(currSum, 0) + 1;

            Preorder(node.left, currSum);
            Preorder(node.right, currSum);
            h[currSum]--;
        }
    }
}
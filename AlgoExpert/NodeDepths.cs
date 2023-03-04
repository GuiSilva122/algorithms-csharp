namespace AlgoExpert
{
    internal class NodeDepths
    {
        public class BinaryTree
        {
            public int value;
            public BinaryTree left;
            public BinaryTree right;

            public BinaryTree(int value)
            {
                this.value = value;
                left = null;
                right = null;
            }
        }

        public static int NodeDepthsCalc(BinaryTree root)
        {
            return NodeDepthsSum(root, 0);
        }

        private static int NodeDepthsSum(BinaryTree tree, int depth)
        {
            if (tree is null) return 0;
            return depth + NodeDepthsSum(tree.left, depth++) + NodeDepthsSum(tree.right, depth++);
        }

        private static int NodeDepthsCalcV2(BinaryTree root)
        {
            int depthsSum = 0;
            var queue = new Queue<(BinaryTree, int)>();
            queue.Enqueue((root, 0));
            
            while (queue.Count > 0)
            {
                var (node, depth) = queue.Dequeue();
                if (node is null) continue;
                depthsSum += depth;
                queue.Enqueue((node.left, depth++));
                queue.Enqueue((node.right, depth++));
            }
            return depthsSum;
        }
    }
}
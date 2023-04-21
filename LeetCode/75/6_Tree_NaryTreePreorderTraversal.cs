namespace LeetCode._75
{
    public class Tree_NaryTreePreorderTraversal
    {
        public class Node
        {
            public int val;
            public IList<Node> children;
            public Node() { }
            public Node(int _val) => val = _val;

            public Node(int _val, IList<Node> _children)
            {
                val = _val;
                children = _children;
            }
        }

        // Recursive
        // O(n) time, O(n) space, where n is the number of nodes of the Tree
        public IList<int> PreorderV1(Node root)
        {
            IList<int> result = new List<int>();
            PreorderV1(root, result);
            return result;
        }

        private void PreorderV1(Node root, IList<int> result)
        {
            if (root == null) return;
            result.Add(root.val);
            foreach (var child in root.children)
                PreorderV1(child, result);
        }

        // Iterative
        // O(n) time, O(n) space, where n is the number of nodes of the Tree
        public IList<int> PreorderV2(Node root)
        {
            IList<int> result = new List<int>();
            if (root == null) return result;

            var stack = new Stack<Node>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                var node = stack.Pop();
                result.Add(node.val);
                for (int i = node.children.Count - 1; i >= 0; i--)
                    stack.Push(node.children[i]);
            }
            return result;
        }
    }
}

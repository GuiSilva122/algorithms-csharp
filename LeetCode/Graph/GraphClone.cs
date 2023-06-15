namespace LeetCode.Graph
{
    public class Node
    {
        public int val;
        public IList<Node> neighbors;
        public Node() => (val, neighbors) = (0, new List<Node>());
        public Node(int _val) => (val, neighbors) = (_val, new List<Node>());
        public Node(int _val, List<Node> _neighbors) => (val, neighbors) = (_val, _neighbors);
    }

    public class GraphClone
    {
        private Dictionary<Node, Node> visited = new Dictionary<Node, Node>();
        public Node CloneGraph(Node node)
        {
            if (node == null)
                return node;

            if (visited.ContainsKey(node))
                return visited[node];

            var cloneNode = new Node(node.val, new List<Node>());
            visited.Add(node, cloneNode);

            foreach (var neighbor in node.neighbors)
                cloneNode.neighbors.Add(CloneGraph(neighbor));

            return cloneNode;
        }
    }
}

namespace LeetCode.Graph
{
    public class GraphValidTree
    {
        // Approach 1: Graph Theory + Iterative Depth-First Search
        // O(N + E) time, O(N + E) space
        public bool ValidTreeV1(int n, int[][] edges)
        {
            var adjacencyList = new List<List<int>>();
            for (int i = 0; i < n; i++)
            {
                adjacencyList.Add(new List<int>());
            }
            foreach (int[] edge in edges)
            {
                adjacencyList[edge[0]].Add(edge[1]);
                adjacencyList[edge[1]].Add(edge[0]);
            }
            var parent = new Dictionary<int, int>();
            parent.Add(0, -1);
            var stack = new Stack<int>();
            stack.Push(0);
            while (stack.Count > 0)
            {
                int node = stack.Pop();
                foreach (int neighbour in adjacencyList[node])
                {
                    if (parent.ContainsKey(node) && parent[node] == neighbour)
                        continue;
                    if (parent.ContainsKey(neighbour))
                        return false;
                    stack.Push(neighbour);
                    parent.Add(neighbour, node);
                }
            }
            return parent.Count == n;
        }

        // Approach 1: Graph Theory + Recursive Depth-First Search
        // O(N + E) time, O(N + E) space
        private List<List<int>> adjacencyList = new List<List<int>>();
        private HashSet<int> seen = new HashSet<int>();
        public bool ValidTreeV2(int n, int[][] edges)
        {
            for (int i = 0; i < n; i++)
                adjacencyList.Add(new List<int>());
            foreach (int[] edge in edges)
            {
                adjacencyList[edge[0]].Add(edge[1]);
                adjacencyList[edge[1]].Add(edge[0]);
            }
            return Dfs(0, -1) && seen.Count == n;
        }
        public bool Dfs(int node, int parent)
        {
            if (seen.Contains(node))
                return false;
            seen.Add(node);
            foreach (int neighbour in adjacencyList[node])
            {
                if (parent != neighbour)
                {
                    var result = Dfs(neighbour, node);
                    if (!result)
                        return false;
                }
            }
            return true;
        }

        // Approach 1: Graph Theory + Breadth-First Search
        // O(N + E) time, O(N + E) space
        public bool ValidTreeV3(int n, int[][] edges)
        {
            var adjacencyList = new List<List<int>>();
            for (int i = 0; i < n; i++)
                adjacencyList.Add(new List<int>());
            foreach (int[] edge in edges)
            {
                adjacencyList[edge[0]].Add(edge[1]);
                adjacencyList[edge[1]].Add(edge[0]);
            }
            var parent = new Dictionary<int, int>();
            parent.Add(0, -1);
            var queue = new Queue<int>();
            queue.Enqueue(0);
            while (queue.Count > 0)
            {
                int node = queue.Dequeue();
                foreach (int neighbour in adjacencyList[node])
                {
                    if (parent[node] == neighbour)
                        continue;
                    if (parent.ContainsKey(neighbour))
                        return false;
                    queue.Enqueue(neighbour);
                    parent.Add(neighbour, node);
                }
            }
            return parent.Count == n;
        }
        // For the graph to be a valid tree, it must have exactly n - 1 edges.
        // Any less, and it can't possibly be fully connected.
        // Any more, and it has to contain cycles.
        // Just returning false when edges != n - 1 will produce for the same algoritms before
        // O(n) time and O(n) space, because E = N

        // Approach 3: Advanced Graph Theory + Union Find
        // O(N a(N)) time, O(N) space, where a(N) is Inverse Ackermann Function.
        private class UnionFind
        {
            private int[] parent;
            private int[] size;
            public UnionFind(int sz)
            {
                parent = new int[sz];
                size = new int[sz];
                for (int i = 0; i < sz; i++)
                {
                    parent[i] = i;
                    size[i] = 1;
                }
            }
            public int Find(int x)
            {
                if (x == parent[x]) return x;
                return parent[x] = Find(parent[x]);
            }
            public bool Union(int a, int b)
            {
                int parentA = Find(a);
                int parentB = Find(b);
                if (parentA == parentB)
                    return false;
                else if (parentA != parentB)
                {
                    if (size[parentA] >= size[parentB])
                    {
                        parent[parentB] = parentA;
                        size[parentA] += size[parentB];
                    }
                    else
                    {
                        parent[parentA] = parentB;
                        size[parentB] += size[parentA];
                    }
                }
                return true;
            }
        }
        public bool ValidTree(int n, int[][] edges)
        {
            if (edges.Length != n - 1) return false;
            var unionFind = new UnionFind(n);
            foreach (var edge in edges)
            {
                int a = edge[0];
                int b = edge[1];
                if (!unionFind.Union(a, b))
                    return false;
            }
            return true;
        }
    }
}
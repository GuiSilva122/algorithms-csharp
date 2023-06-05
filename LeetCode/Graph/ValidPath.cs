namespace LeetCode.Graph
{
    public class ValidPath
    {
        // DFS Recursive
        // O(V + E) time, O(V + E) space
        public bool ValidPathV1(int n, int[][] edges, int source, int destination)
        {
            var graph = new Dictionary<int, List<int>>();
            var seen = new bool[n];
            foreach (var edge in edges)
            {
                int a = edge[0];
                int b = edge[1];
                if (!graph.ContainsKey(a)) graph.Add(a, new List<int>());
                if (!graph.ContainsKey(b)) graph.Add(b, new List<int>());
                graph[a].Add(b);
                graph[b].Add(a);
            }
            return Dfs(graph, seen, source, destination);
        }
        private bool Dfs(Dictionary<int, List<int>> graph, bool[] seen,
                         int currentNode, int destination)
        {
            if (currentNode == destination)
                return true;
            if (!seen[currentNode])
            {
                seen[currentNode] = true;
                foreach (int nextNode in graph[currentNode])
                {
                    if (Dfs(graph, seen, nextNode, destination))
                        return true;
                }
            }
            return false;
        }
        // DFS Iterative
        // O(V + E) time, O(V + E) space
        public bool ValidPathV2(int n, int[][] edges, int source, int destination)
        {
            var graph = new Dictionary<int, List<int>>();
            foreach (var edge in edges)
            {
                var (a, b) = (edge[0], edge[1]);
                if (!graph.ContainsKey(a)) graph.Add(a, new List<int>());
                if (!graph.ContainsKey(b)) graph.Add(b, new List<int>());
                graph[a].Add(b);
                graph[b].Add(a);
            }
            var seen = new bool[n];
            var stack = new Stack<int>();
            stack.Push(source);
            while (stack.Count > 0)
            {
                var currentNode = stack.Pop();
                if (currentNode == destination)
                    return true;
                if (!seen[currentNode])
                {
                    seen[currentNode] = true;
                    foreach (int nextNode in graph[currentNode])
                        stack.Push(nextNode);
                }
            }
            return false;
        }
        // BFS
        // O(V + E) time, O(V + E) space
        public bool ValidPathV3(int n, int[][] edges, int source, int destination)
        {
            var graph = new Dictionary<int, List<int>>();
            foreach (var edge in edges)
            {
                int a = edge[0];
                int b = edge[1];
                if (!graph.ContainsKey(a)) graph.Add(a, new List<int>());
                if (!graph.ContainsKey(b)) graph.Add(b, new List<int>());
                graph[a].Add(b);
                graph[b].Add(a);
            }
            var queue = new Queue<int>();
            var seen = new bool[n];
            queue.Enqueue(source);
            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();
                if (currentNode == destination)
                    return true;
                if (!seen[currentNode])
                {
                    seen[currentNode] = true;
                    foreach (int nextNode in graph[currentNode])
                        queue.Enqueue(nextNode);
                }
            }
            return false;
        }
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
                return parent[x] = Find(parent[x]); //Path Compression
            }
            public void Union(int a, int b)
            {
                int parentA = Find(a);
                int parentB = Find(b);
                if (parentA != parentB)
                {
                    if (size[parentA] >= size[parentB])
                    {
                        size[parentA] += size[parentB];
                        parent[parentB] = parentA;
                    }
                    else
                    {
                        size[parentB] += size[parentA];
                        parent[parentA] = parentB;
                    }
                }
            }
        }
        // Disjoint Set Union
        // Let n be the number of edges
        // O(n a(n)) time, O(n) space, where a is the inverse ackermann function
        public bool ValidPath4(int n, int[][] edges, int source, int destination)
        {
            var dsu = new UnionFind(n);
            foreach (var edge in edges)
                dsu.Union(edge[0], edge[1]);
            return dsu.Find(source) == dsu.Find(destination);
        }
    }
}

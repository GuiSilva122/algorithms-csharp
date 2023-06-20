namespace LeetCode.Graph.Algorithms
{
    public class TopologicalSortAlgorithm
    {
        public int[] TopologicalSort(Dictionary<int, List<Edge>> graph, int numNodes)
        {
            var ordering = new int[numNodes];
            var visited = new bool[numNodes];

            int i = numNodes - 1;
            for (int at = 0; at < numNodes; at++)
            {
                if (!visited[at])
                    i = Dfs(i, at, visited, ordering, graph);
            }
            return ordering;
        }
        private static int Dfs(int i, int at, bool[] visited, int[] ordering, Dictionary<int, List<Edge>> graph)
        {
            visited[at] = true;
            List<Edge> edges = graph[at];
            if (edges != null)
            {
                foreach (var edge in edges)
                {
                    if (!visited[edge.To])
                        i = Dfs(i, edge.To, visited, ordering, graph);
                }
            }
            ordering[i] = at;
            return i - 1;
        }
    }
}
namespace LeetCode.Graph
{
    public class AllPathsFromSourceLeadsToDestination
    {
        // O(V+E) time, O(V+E) space
        private enum Color 
        {
            WHITE,
            GRAY,
            BLACK
        };
        public static bool LeadsToDestination(int n, int[][] edges, int source, int destination)
        {
            var graph = new List<List<int>>(n);
            for (int i = 0; i < n; i++)
                graph.Add(new List<int>());
            foreach (var edge in edges)
                graph[edge[0]].Add(edge[1]);
            return Dfs(graph, source, destination, new Color[n]);

        }
        private static bool Dfs(List<List<int>> graph, int node, int dest, Color[] states)
        {
            // If the state is GRAY, this is a backward edge and hence, it creates a loop.
            if (states[node] != Color.WHITE)
                return states[node] == Color.BLACK;
            // If this is a leaf node, it should be equal to the destination.
            if (graph[node].Count == 0)
                return node == dest;
            // Now, we are processing this node. So we mark it as GRAY
            states[node] = Color.GRAY;
            foreach (var next in graph[node])
            {
                // If we get a false from any recursive call on the neighbors, we short circuit and return
                if (!Dfs(graph, next, dest, states))
                    return false;
            }
            // Recursive processing done for the node. We mark it BLACK
            states[node] = Color.BLACK;
            return true;
        }

        public static void TestSolution()
        {
            var n = 4;
            var edges = new int[][] { new int[] { 0, 1 }, new int[] { 0, 2 }, new int[] { 1, 3 }, new int[] { 2, 3 } };
            var source = 0;
            var destination = 3;
            var result = LeadsToDestination(n, edges, source, destination);
        }
    }
}
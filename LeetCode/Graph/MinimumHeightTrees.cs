namespace LeetCode.Graph
{
    public class MinimumHeightTrees
    {
        public static IList<int> FindMinHeightTrees(int n, int[][] edges)
        {
            // edge cases
            if (n < 2)
            {
                var centroids = new List<int>();
                for (int i = 0; i < n; i++)
                    centroids.Add(i);
                return centroids;
            }
            var graph = new Dictionary<int, List<int>>();
            foreach (var edge in edges)
            {
                var (from, to) = (edge[0], edge[1]);
                if (!graph.ContainsKey(from)) graph.Add(from, new List<int>());
                if (!graph.ContainsKey(to)) graph.Add(to, new List<int>());
                graph[from].Add(to);
                graph[to].Add(from);
            }
            var leaves = new List<int>();
            for (int i = 0; i < n; i++)
                if (graph[i].Count == 1)
                    leaves.Add(i);

            int remainingNodes = n;
            while (remainingNodes > 2)
            {
                remainingNodes -= leaves.Count();
                var newLeaves = new List<int>();
                // remove the current leaves along with the edges
                foreach (int leaf in leaves)
                {
                    // the only neighbor left for the leaf node
                    int neighbor = graph[leaf][0];
                    // remove the edge along with the leaf node
                    graph[neighbor].Remove(leaf);
                    if (graph[neighbor].Count == 1)
                        newLeaves.Add(neighbor);
                }
                // prepare for the next round
                leaves = newLeaves;
            }
            // The remaining nodes are the centroids of the graph
            return leaves;
        }

        public static void TestSolution()
        {
            int n = 4;
            var edges = new int[][] { new int[] { 1, 0 }, new int[] { 1, 2 }, new int[] { 1, 3 } };

            //int n = 6;
            //var edges = new int[][] { new int[] { 3, 0 }, new int[] { 3, 1 }, new int[] { 3, 2 }, new int[] { 3, 4 }, new int[] { 5, 4 } };

            var result = FindMinHeightTrees(n, edges);
        }
    }
}
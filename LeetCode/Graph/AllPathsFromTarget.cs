namespace LeetCode.Graph
{
    public class AllPathsFromTarget
    {
        // O(2^V.V) time, O(V) space, where V is the number of vertices
        public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
        {
            var result = new List<IList<int>>();
            var currentPath = new List<int> { 0 };
            Dfs(graph, result, currentPath, 0, graph.Length - 1);
            return result;
        }
        private void Dfs(int[][] graph, List<IList<int>> results, List<int> currentPath, int currentNode, int destination)
        {
            if (currentNode == destination)
            {
                results.Add(new List<int>(currentPath));
                return;
            }
            foreach (int nextNode in graph[currentNode])
            {
                currentPath.Add(nextNode);
                Dfs(graph, results, currentPath, nextNode, destination);
                currentPath.Remove(currentPath.Last());
            }
        }

        public static IList<IList<int>> AllPathsSourceTargetV2(int[][] graph)
        {
            IList<IList<int>> paths = new List<IList<int>>();
            if (graph == null || graph.Length == 0)
                return paths;
            var path = new List<int> { 0 };
            var queue = new Queue<List<int>>();
            queue.Enqueue(path);
            while (queue.Count > 0)
            {
                var currentPath = queue.Dequeue();
                int currentNode = currentPath.Last();
                foreach (var nextNode in graph[currentNode])
                {
                    var tempPath = new List<int>(currentPath) { nextNode };
                    if (nextNode == graph.Length - 1)
                        paths.Add(new List<int>(tempPath));
                    else                    
                        queue.Enqueue(new List<int>(tempPath));
                }
            }
            return paths;
        }

        public static void TestSolution()
        {
            var graph = new int[][] { new int[] { 1, 2 }, new int[] { 3 }, new int[] { 3 }, new int[] { }};
            var results = AllPathsSourceTargetV2(graph);
        }
    }
}
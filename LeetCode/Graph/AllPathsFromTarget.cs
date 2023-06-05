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
    }
}
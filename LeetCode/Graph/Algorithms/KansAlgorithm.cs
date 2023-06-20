namespace LeetCode.Graph.Algorithms
{
    // Topological Sort
    // (V + E) time, O(V + E) space
    public class KansAlgorithm
    {
        public int[] Kahns(List<List<int>> graph)
        {
            int n = graph.Count;
            int[] inDegree = new int[n];
            foreach (List<int> edges in graph)
            {
                foreach (int to in edges)
                    inDegree[to]++;
            }
            var queue = new Queue<int>();
            for (int i = 0; i < n; i++)
            {
                if (inDegree[i] == 0)
                    queue.Enqueue(i);
            }
            int index = 0;
            int[] order = new int[n];
            while (queue.Count > 0)
            {
                int at = queue.Dequeue();
                order[index++] = at;
                foreach (int to in graph[at])
                {
                    inDegree[to]--;
                    if (inDegree[to] == 0)
                        queue.Enqueue(to);
                }
            }
            // Graph is not acyclic! Detected a cycle.
            if (index != n) return null;            
            return order;
        }
    }
}
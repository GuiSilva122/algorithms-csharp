namespace LeetCode.Graph
{
    public class ParallelCourses
    {
        public static int MinimumSemesters(int n, int[][] relations)
        {
            var graph = new Dictionary<int, List<int>>();
            var indegree = new int[n + 1];
            foreach (var edge in relations)
            {
                var (from, to) = (edge[0], edge[1]);
                if (!graph.ContainsKey(from)) graph.Add(from, new List<int>());
                graph[from].Add(to);
                indegree[to]++;
            }
            var queue = new Queue<int>();
            for (int i = 1; i < indegree.Length; i++)
            {
                if (indegree[i] == 0)
                    queue.Enqueue(i);
            }
            int semesters = 0;
            int studiedCount = 0;
            while (queue.Count > 0)
            {
                semesters++;
                var nextQueue = new Queue<int>();
                while (queue.Count > 0)
                {
                    studiedCount++;
                    var node = queue.Dequeue();
                    if (graph.ContainsKey(node))
                    {
                        foreach (int endNode in graph[node])
                        {
                            indegree[endNode]--;
                            if (indegree[endNode] == 0)
                                nextQueue.Enqueue(endNode);
                        }
                    }
                }
                queue = nextQueue;
            }
            return studiedCount == n ? semesters : -1;
        }

        public static void TestSolution()
        {
            int n = 3;
            var relations = new int[][] { new int[] { 1, 3 }, new int[] { 2, 3 } };
            var result = MinimumSemesters(n, relations);
        }
    }
}
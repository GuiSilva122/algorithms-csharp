namespace LeetCode.Graph
{
    public class NetworkDelayTime
    {
        private record Edge(int From, int To, int Cost);
        private record Node(int Id, int Value);
        public static int networkDelayTime(int[][] times, int n, int k)
        {
            var graph = new Dictionary<int, List<Edge>>();
            foreach (var time in times)
            {
                var edge = new Edge(time[0], time[1], time[2]);
                if (!graph.ContainsKey(edge.From))
                    graph.Add(edge.From, new List<Edge>());
                graph[edge.From].Add(edge);
            }
            var distances = Dijkstra(graph, k, n + 1);
            int answer = int.MinValue;
            for (int i = 1; i < distances.Length; i++)
                answer = Math.Max(answer, distances[i]);

            return answer == int.MaxValue ? -1 : answer;
        }
        private static int[] Dijkstra(Dictionary<int, List<Edge>> graph, int start, int n)
        {
            var dist = new int[n];
            Array.Fill(dist, int.MaxValue);
            dist[start] = 0;

            var comparer = Comparer<Node>.Create((a, b) => a.Value - b.Value);
            var initialNode = new Node(start, 0);
            var pq = new PriorityQueue<Node, Node>(comparer);
            pq.Enqueue(initialNode, initialNode);

            var visited = new bool[n];
            var prev = new int[n];

            while (pq.Count > 0)
            {
                var node = pq.Dequeue();
                visited[node.Id] = true;
                if (dist[node.Id] < node.Value) continue;
                if (!graph.ContainsKey(node.Id)) continue;
                var edges = graph[node.Id];
                for (int i = 0; i < edges.Count; i++)
                {
                    var edge = edges[i];
                    if (visited[edge.To]) continue;
                    int newDist = dist[edge.From] + edge.Cost;
                    if (newDist < dist[edge.To])
                    {
                        prev[edge.To] = edge.From;
                        dist[edge.To] = newDist;
                        var newNode = new Node(edge.To, dist[edge.To]);
                        pq.Enqueue(newNode, newNode);
                    }
                }
            }
            return dist;
        }

        public static void TestSolution()
        {
            var times = new int[][] { new int[] { 2, 1, 1}, new int[] { 2, 3, 1 }, new int[] { 3, 4, 1 } };
            int n = 4;
            int k = 2;
            var result = networkDelayTime(times, n, k);
        }
    }
}

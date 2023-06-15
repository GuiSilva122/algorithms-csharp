namespace LeetCode.Graph.Algorithms
{
    // Single Source Shortest Path
    public class DijkstraAlgorithm
    {
        public int Dijkstra(Dictionary<int, List<Edge>> graph, int start, int end, int n)
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
                if (node.Id == end) 
                    return dist[end];
            }
            return -1;
        }
    }
}

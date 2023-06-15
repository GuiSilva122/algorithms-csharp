namespace LeetCode.Graph.Algorithms
{
    // Minimum Spaning Tree
    internal class PrimsAlgorithm
    {
        // O(ElogE) time, O(E) space
        public int Prims(List<List<Edge>> graph, int n)
        {
            int m = n - 1;
            int edgeCount = 0;
            var pq = new PriorityQueue<Edge, Edge>();
            var visited = new bool[n];
            
            var mstEdges = new Edge[m];
            int minCostSum = 0;
            
            visited[0] = true;
            foreach (var edge in graph[0])
            {
                if (!visited[edge.To])
                    pq.Enqueue(edge, edge);
            }
            while (pq.Count > 0 && edgeCount != m)
            {
                var edge = pq.Dequeue();
                int nodeIndex = edge.To;
                
                if (visited[nodeIndex]) 
                    continue;
                
                mstEdges[edgeCount++] = edge;
                minCostSum += edge.Cost;

                foreach (var nextEdge in graph[nodeIndex])
                {
                    if (!visited[nextEdge.To])
                        pq.Enqueue(nextEdge, nextEdge);
                }
            }

            if (edgeCount == m)
                return minCostSum;

            return -1;
        }
    }
}

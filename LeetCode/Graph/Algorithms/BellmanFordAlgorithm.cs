namespace LeetCode.Graph.Algorithms
{
    // Single Source Shortest Path
    public class BellmanFordAlgorithm
    {
        /*
        * The algorithm finds the shortest path betweena starting node and all other nodes in the graph. 
        * The algorithm also detects negative cycles.
        * If a node is part of a negative cycle then the minimum cost for that node is set toint.MaxValue.
        * graph - An adjacency list containing directed edges forming the graph
        * V - The number of vertices in the graph.
        * start - The id of the starting node
        */
        public int[] BellmanFord(List<List<Edge>> graph, int v, int start)
        {
            int[] dist = new int[v];
            Array.Fill(dist, int.MaxValue);
            dist[start] = 0;
            // For each vertex, apply relaxation for all the edges
            for (int i = 0; i < v - 1; i++)
            {
                foreach (List<Edge> edges in graph)
                {
                    foreach (var edge in edges)
                    {
                        if (dist[edge.From] + edge.Cost < dist[edge.To])
                            dist[edge.To] = dist[edge.From] + edge.Cost;
                    }
                }   
            }
            // Run algorithm a second time to detect which nodes are part of a negative cycle.
            // A negative cycle has occurred if we can find a better path beyond the optimal solution.
            for (int i = 0; i < v - 1; i++)
            {
                foreach (List<Edge> edges in graph)
                {
                    foreach (var edge in edges)
                    {
                        if (dist[edge.From] + edge.Cost < dist[edge.To]) 
                            dist[edge.To] = int.MaxValue;
                    }
                }
            }
            // Return the array containing the shortest distance to every node
            return dist;
        }
    }
}
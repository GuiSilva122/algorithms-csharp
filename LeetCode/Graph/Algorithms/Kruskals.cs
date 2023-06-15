namespace LeetCode.Graph.Algorithms
{
    // Minimum Spaning Tree
    public class KruskalsAlgorithm
    {
        // O(ElogE) time, O(E) space
        public int Kruskals(List<Edge> edges, int n)
        {
            edges.Sort((x, y) => x.Cost - y.Cost);
            var unionFind = new UnionFind(n);
            int costSum = 0;
            foreach (var edge in edges)
            {
                if (unionFind.Find(edge.From) != unionFind.Find(edge.To))
                {
                    unionFind.Union(edge.From, edge.To);
                    costSum += edge.Cost;
                }
                // Optimization to stop early if we found a MST that includes all the nodes
                if (unionFind.Size(0) == n) break;
            }
            if (unionFind.Size(0) != n) 
                return -1;

            return costSum;
        }
    }
}

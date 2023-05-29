using System.Drawing;

namespace LeetCode._75
{
    public class UnionFind_MostStonesRemoved
    {
        // Here N is the Number of stones. E is the Number of edges in the graph,
        // the maximum value for E is N(N−1), where there is an edge between every pair of stones.
        // Time complexity: O(N2+E)
            // Building the graph will need O(N^2) as needed to traverse over all pairs of stones.
            // During the DFS traversal, each stone only is visited once.
            // This is because we mark each stone as visited as soon as we see it, and then we only visit stones that are not marked as visited.
            // In addition, when we iterate over the edge list of each stone, we look at each edge once.
        
        // Space complexity: O(N+E)
            // Building the adjacency list will take O(E) space.
            // To keep track of visited vertices, an array of size O(N), is required.
            // Also, the run-time stack for DFS will use O(N) space.
        private int RemoveStones(int[][] stones)
        {
            var adj = new List<List<int>>(stones.Length);
            for (int i = 0; i < stones.Length; i++)
                adj[i] = new List<int>();

            for (int i = 0; i < stones.Length; i++)
            {
                for (int j = i + 1; j < stones.Length; j++)
                {
                    if (ShareSameRowOrColumn(stones[i], stones[j]))
                    {
                        adj[i].Add(j);
                        adj[j].Add(i);
                    }
                }
            }
            int[] visited = new int[stones.Length];
            int componentCount = 0;
            for (int i = 0; i < stones.Length; i++)
            {
                if (visited[i] == 0)
                {
                    componentCount++;
                    Dfs(stones, adj, visited, i);
                }
            }
            return stones.Length - componentCount;
        }
        private bool ShareSameRowOrColumn(int[] a, int[] b) => a[0] == b[0] || a[1] == b[1];
        private void Dfs(int[][] stones, List<List<int>> adj, int[] visited, int src)
        {
            visited[src] = 1;
            foreach (var adjacent in adj[src])
            {
                if (visited[adjacent] == 0)
                    Dfs(stones, adj, visited, adjacent);
            }
        }

        // Time complexity: O(N^2 * alpha(N))
            // The amortized time complexity for each union-find operation is O(alpha(N)),
            // where alphaα is The Inverse Ackermann Function, this is because we have used union by size as well as path compression in the DSU implementation.
            // Initializing the rep and size will take O(N) time.
            // We then iterate over all the O(N^2) pairs and for each pair, the performUnion function will take O(αlpha(n)) time,
            // hence the total time complexity is equal to O(N^2 * alpha(N))\
        // Space complexity: O(N) Storing the representative/immediate-parents and sizes of N stones takes O(N) space.
        public int RemoveStonesV2(int[][] stones)
        {
            int[] rep = new int[stones.Length];
            int[] size = new int[stones.Length];
            for (int i = 0; i < stones.Length; i++)
            {
                rep[i] = i;
                size[i] = 1;
            }
            int componentCount = stones.Length;
            for (int i = 0; i < stones.Length; i++)
            {
                for (int j = i + 1; j < stones.Length; j++)
                {
                    if (ShareSameRowOrColumn(stones[i], stones[j]))
                        componentCount -= PerformUnion(rep, size, i, j);
                }
            }
            return stones.Length - componentCount;
        }
        private int Find(int[] rep, int x)
        {
            if (x == rep[x])
                return x;
            return rep[x] = Find(rep, rep[x]); // Uses Path compression
        }
        private int PerformUnion(int[] rep, int[] size, int x, int y)
        {
            x = Find(rep, x);
            y = Find(rep, y);

            if (x == y)            
                return 0;

            if (size[x] > size[y])
            {
                rep[y] = x;
                size[x] += size[y];
            }
            else
            {
                rep[x] = y;
                size[y] += size[x];
            }
            return 1;
        }
    }
}
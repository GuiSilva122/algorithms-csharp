namespace LeetCode.Graph
{
    public class OptimizeWaterDistribution
    {
        // Let N be the number of houses, and M be the number of pipes from the input.
        
        // Time Complexity: O((N+M) log⁡(N+M))
        // To build the graph, we iterate through the houses and pipes in the input, which takes O(N+M) time.
        // While building the MST, we might need to iterate through all the edges in the graph in the worst case, which amounts to N+M in total.
        // For each edge, it would enter and exit the heap data structure at most once.
        // The enter of edge into heap (i.e.push operation) takes log⁡(N+M) time, while the exit of edge(i.e.pop operation) takes a constant time.
        
        // Space Complexity: O(N+M)
        // The graph that we built consists of N+1 vertices and 2M edges (i.e.pipes are bidirectional).
        // Therefore, the space complexity of graph is O(N+1+2M) = O(N+M)
        // The space complexity of the set that is used to hold the vertices in MST is O(N).
        public int MinCostToSupplyWater(int n, int[] wells, int[][] pipes)
        {
            var comparer = Comparer<(int, int)>.Create((a, b) => a.Item1 - b.Item1);
            var edgesHeap = new PriorityQueue<(int, int), (int, int)>(comparer);

            var graph = new List<List<(int, int)>>(n + 1);
            for (int i = 0; i < n + 1; i++)
                graph.Add(new List<(int, int)>());
            
            for (int i = 0; i < wells.Length; i++)
            {
                var virtualEdge = (wells[i], i + 1);
                graph[0].Add(virtualEdge);
                edgesHeap.Enqueue(virtualEdge, virtualEdge);
            }
            for (int i = 0; i < pipes.Length; i++)
            {
                int house1 = pipes[i][0];
                int house2 = pipes[i][1];
                int cost = pipes[i][2];
                graph[house1].Add((cost, house2));
                graph[house2].Add((cost, house1));
            }
            var mstSet = new HashSet<int> { 0 };
            int totalCost = 0;
            while (mstSet.Count < n + 1)
            {
                var (cost, nextHouse) = edgesHeap.Dequeue();
                if (mstSet.Contains(nextHouse))
                    continue;
                
                mstSet.Add(nextHouse);
                totalCost += cost;
                foreach (var neighbourEdge in graph[nextHouse])
                {
                    var (neighbourCost, neighbourNextHouse) = neighbourEdge;
                    if (!mstSet.Contains(neighbourNextHouse))
                        edgesHeap.Enqueue(neighbourEdge, neighbourEdge);
                }
            }
            return totalCost;
        }
    }
    public class OptimizeWaterDistributionV2
    {
        private class UnionFind
        {
            private int[] group;
            private int[] rank;
            public UnionFind(int size)
            {
                group = new int[size + 1];
                rank = new int[size + 1];
                for (int i = 0; i < size + 1; i++)
                {
                    group[i] = i;
                    rank[i] = 0;
                }
            }
            public int Find(int person)
            {
                if (group[person] != person)
                    group[person] = Find(group[person]);
                return group[person];
            }
            public bool Union(int person1, int person2)
            {
                int group1 = Find(person1);
                int group2 = Find(person2);
                if (group1 == group2)
                    return false;
                if (rank[group1] > rank[group2])
                    group[group2] = group1;
                else if (rank[group1] < rank[group2])
                    group[group1] = group2;
                else
                {
                    group[group1] = group2;
                    rank[group2] += 1;
                }
                return true;
            }
        }
        // Let N be the number of houses, and M be the number of pipes from the input.
        // O((N+M)log(N+M)) time, O(N+M) space
        public int MinCostToSupplyWater(int n, int[] wells, int[][] pipes)
        {
            var orderedEdges = new List<int[]>(n + 1 + pipes.Length);
            for (int i = 0; i < wells.Length; i++)
                orderedEdges.Add(new int[] { 0, i + 1, wells[i] });
            for (int i = 0; i < pipes.Length; i++)
            {
                int[] edge = pipes[i];
                orderedEdges.Add(edge);
            }
            orderedEdges.Sort((a, b) => a[2] - b[2]);
            var unionFind = new UnionFind(n);
            int totalCost = 0;
            foreach (int[] edge in orderedEdges)
            {
                var (house1, house2, cost) = (edge[0], edge[1], edge[2]);
                if (unionFind.Union(house1, house2))                
                    totalCost += cost;
            }
            return totalCost;
        }
    }
}
namespace LeetCode.Graph
{
    public class MinCostToConnectAllPoints
    {
        public class Solution
        {
            private class UnionFind
            {
                private int[] parent;
                private int[] size;
                public UnionFind(int sz)
                {
                    parent = new int[sz];
                    size = new int[sz];
                    for (int i = 0; i < sz; i++)
                    {
                        parent[i] = i;
                        size[i] = 1;
                    }
                }
                public int Find(int x)
                {
                    if (x == parent[x]) return x;
                    return parent[x] = Find(parent[x]);
                }
                public void Union(int a, int b)
                {
                    int parentA = Find(a);
                    int parentB = Find(b);
                    if (parentA != parentB)
                    {
                        if (size[parentA] >= size[parentB])
                        {
                            size[parentA] += size[parentB];
                            parent[parentB] = parentA;
                        }
                        else
                        {
                            size[parentB] += size[parentA];
                            parent[parentA] = parentB;
                        }
                    }
                }
                public int Size(int x) => size[Find(x)];
            }
            //  Kruskal's Algorithm
            // O(N^2 logN) time
            //  To create the allEdges list we take N*(N-1), this is O(N^2).
            //  To sort the allEdges list we take O(N^2 log(N^2))
            //  To do the Union-Find operations we take O(a(N)) where a(N) is the inverse of Ackermann function, which is nearly constant time
            // O(N^2) space, due to the allEdges list
            public int MinCostConnectPointsV1(int[][] points)
            {
                if (points == null || points.Length == 0)
                    return 0;
                int n = points.Length;
                var allEdges = new List<(int, int, int)>();
                for (int currNext = 0; currNext < n; currNext++)
                {
                    for (int nextNext = currNext + 1; nextNext < n; nextNext++)
                    {
                        int weight = Math.Abs(points[currNext][0] - points[nextNext][0]) +
                                     Math.Abs(points[currNext][1] - points[nextNext][1]);
                        allEdges.Add((currNext, nextNext, weight));
                    }
                }
                allEdges.Sort((a, b) => a.Item3.CompareTo(b.Item3));
                var unionFind = new UnionFind(n);
                int costSum = 0;
                foreach (var (from, to, weight) in allEdges)
                {
                    if (unionFind.Find(from) == unionFind.Find(to))
                        continue;
                    unionFind.Union(from, to);
                    costSum += weight;
                    if (unionFind.Size(0) == n)
                        break;
                }
                return costSum;
            }
            //  Kruskal's Algorithm
            // O(ElogE) time, O(E) space
            private record Edge(int From, int To, int Cost);
            public int MinCostConnectPointsV2(int[][] points)
            {
                if (points == null || points.Length == 0) 
                    return 0;
                int size = points.Length;
                var priorityQueue = new PriorityQueue<Edge, Edge>(Comparer<Edge>.Create((x, y) => x.Cost - y.Cost));
                var unionFind = new UnionFind(size);
                
                for (int currNext = 0; currNext < size; currNext++)
                {
                    for (int nextNext = currNext + 1; nextNext < size; nextNext++)
                    {
                        int cost = Math.Abs(points[currNext][0] - points[nextNext][0]) +
                                   Math.Abs(points[currNext][1] - points[nextNext][1]);
                        var edge = new Edge(currNext, nextNext, cost);
                        priorityQueue.Enqueue(edge, edge);
                    }
                }
                int costSum = 0;
                int count = size - 1;
                while (priorityQueue.Count > 0 && count > 0)
                {
                    var edge = priorityQueue.Dequeue();
                    if (unionFind.Find(edge.From) != unionFind.Find(edge.To))
                    {
                        unionFind.Union(edge.From, edge.To);
                        costSum += edge.Cost;
                        count--;
                    }
                }
                return costSum;
            }

            // Prim's Algorithm
            // O(N^2 log(N)) time, O(N^2) space
            public int MinCostConnectPointsV3(int[][] points)
            {
                int n = points.Length;
                // Min-heap to store minimum weight edge at top.
                var comparer = Comparer<(int, int)>.Create((a, b) => a.Item1 - b.Item1);
                var heap = new PriorityQueue<(int, int), (int, int)>(comparer);
                // Track nodes which are included in MST.
                var inMST = new bool[n];
                var initialValue = (0, 0);
                heap.Enqueue(initialValue, initialValue);
                int mstCost = 0;
                int edgesUsed = 0;

                while (edgesUsed < n)
                {
                    var (weight, currNode) = heap.Dequeue();
                    // If node was already included in MST we will discard this edge.
                    if (inMST[currNode])
                        continue;                    
                    inMST[currNode] = true;

                    mstCost += weight;
                    edgesUsed++;

                    for (int nextNode = 0; nextNode < n; ++nextNode)
                    {
                        // If next node is not in MST, then edge from curr node to next node can be pushed in the priority queue.
                        if (!inMST[nextNode])
                        {
                            int nextWeight = Math.Abs(points[currNode][0] - points[nextNode][0]) +
                                             Math.Abs(points[currNode][1] - points[nextNode][1]);
                            var value = (nextWeight, nextNode);
                            heap.Enqueue(value, value);
                        }
                    }
                }
                return mstCost;
            }

            // Prim's Optmized Algorithm
            // O(N^2) time, O(N) space
            public int MinCostConnectPointsV4(int[][] points)
            {
                int n = points.Length;
                int mstCost = 0;
                int edgesUsed = 0;
                var inMST = new bool[n];
                int[] minDist = new int[n];
                minDist[0] = 0;
                for (int i = 1; i < n; i++)
                    minDist[i] = int.MaxValue;

                while (edgesUsed < n)
                {
                    int currMinEdge = int.MaxValue;
                    int currNode = -1;
                    // Pick least weight node which is not in MST.
                    for (int node = 0; node < n; node++)
                    {
                        if (!inMST[node] && currMinEdge > minDist[node])
                        {
                            currMinEdge = minDist[node];
                            currNode = node;
                        }
                    }
                    mstCost += currMinEdge;
                    edgesUsed++;
                    inMST[currNode] = true;
                    // Update adjacent nodes of current node.
                    for (int nextNode = 0; nextNode < n; nextNode++)
                    {
                        int weight = Math.Abs(points[currNode][0] - points[nextNode][0]) +
                                     Math.Abs(points[currNode][1] - points[nextNode][1]);
                        if (!inMST[nextNode] && minDist[nextNode] > weight)
                            minDist[nextNode] = weight;
                    }
                }
                return mstCost;
            }
        }
    }
}
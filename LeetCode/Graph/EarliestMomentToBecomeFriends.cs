namespace LeetCode.Graph
{
    public class EarliestMomentToBecomeFriends
    {
        public class UnionFind
        {
            private int[] parent;
            private int[] size;
            public int Count;
            public UnionFind(int sz)
            {
                Count = sz;
                size = new int[sz];
                parent = new int[sz];
                for (int i = 0; i < sz; i++)
                {
                    size[i] = 1;
                    parent[i] = i;
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
                    Count--;
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
        }
        // Let N be the number of people and M be the number of logs.
        // Time Complexity: O(N + M log ⁡M + Mα(N))
        // Sort logs takes O(M log ⁡M).
        // Create a Union-Find takes O(N)
        // We do Union(a, b) M times, it takes (Mα(N))
        // Space Complexity: O(N + M) or O(N + log M)
        // Union-Find takes O(N) space.
        // Sorting in Python takes O(M) space, While in Java, takes O(log ⁡M).
        public int EarliestAcq(int[][] logs, int n)
        {
            Array.Sort(logs, (a, b) => a[0] - b[0]);
            var unionFind = new UnionFind(n);
            foreach (var edge in logs)
            {
                unionFind.Union(edge[1], edge[2]);
                if (unionFind.Count == 1)
                    return edge[0];
            }
            return -1;
        }
    }
}

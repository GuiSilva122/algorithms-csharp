namespace LeetCode.Graph
{
    public class NumberOfConnectedComponentsInUndirectedGraph
    {
        // O(E a(n)), O(v) space
        public int CountComponents(int n, int[][] edges)
        {
            var unionFind = new UnionFind(n);
            foreach (var edge in edges)
            {
                unionFind.Union(edge[0], edge[1]);
            }
            return unionFind.Count;
        }
        private class UnionFind
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
    }
}
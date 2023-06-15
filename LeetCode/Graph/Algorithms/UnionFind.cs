namespace LeetCode.Graph.Algorithms
{
    internal class UnionFind
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
        public int Size(int p) => size[Find(p)];
    }
}
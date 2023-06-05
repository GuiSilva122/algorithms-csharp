namespace LeetCode.Graph
{
    public class NumberOfProvinces
    {
        public class DisjointSetUnion
        {
            private int[] size;
            private int[] representative;
            public DisjointSetUnion(int sz)
            {
                size = new int[sz];
                representative = new int[sz];
                for (int i = 0; i < sz; i++)
                {
                    size[i] = 1;
                    representative[i] = i;
                }
            }
            public int FindRepresentative(int x)
            {
                if (x == representative[x])
                    return representative[x];
                return representative[x] = FindRepresentative(representative[x]);
            }
            public void UnionByRank(int a, int b)
            {
                int representativeA = FindRepresentative(a);
                int representativeB = FindRepresentative(b);
                if (representativeA != representativeB)
                {
                    if (size[representativeA] >= size[representativeB])
                    {
                        size[representativeA] += size[representativeB];
                        representative[representativeB] = representativeA;
                    }
                    else
                    {
                        size[representativeB] += size[representativeA];
                        representative[representativeA] = representativeB;
                    }
                }
            }

        }
        public int FindCircleNum(int[][] isConnected)
        {
            int n = isConnected.Length;
            int numberOfComponents = n;
            var dsu = new DisjointSetUnion(n);
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (isConnected[i][j] == 1 && dsu.FindRepresentative(i) != dsu.FindRepresentative(j))
                    {
                        numberOfComponents--;
                        dsu.UnionByRank(i, j);
                    }
                }
            }
            return numberOfComponents;
        }
    }
}
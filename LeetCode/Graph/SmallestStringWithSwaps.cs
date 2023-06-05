namespace LeetCode.Graph
{
    public class SmallestStringWithSwaps
    {
        public class UnionFind
        {
            private int[] parent;
            private int[] size;
            public UnionFind(int sz)
            {
                parent = new int[sz];
                size = new int[sz];
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
        public string smallestStringWithSwaps(string s, IList<IList<int>> pairs)
        {
            var unionFind = new UnionFind(s.Length);
            foreach (var edge in pairs)
            {
                int source = edge[0];
                int destination = edge[1];
                unionFind.Union(source, destination);
            }
            var rootToComponent = new Dictionary<int, List<int>>();
            for (int vertex = 0; vertex < s.Length; vertex++)
            {
                int root = unionFind.Find(vertex);
                if (!rootToComponent.ContainsKey(root))
                    rootToComponent.Add(root, new List<int>());
                rootToComponent[root].Add(vertex);
            }

            var smallestString = new char[s.Length];
            foreach (var indices in rootToComponent.Values)
            {
                var characters = new List<char>();
                foreach (int index in indices)
                    characters.Add(s[index]);
                characters.Sort();
                for (int index = 0; index < indices.Count; index++)
                    smallestString[indices[index]] = characters[index];
            }
            return new string(smallestString);
        }
    }
}
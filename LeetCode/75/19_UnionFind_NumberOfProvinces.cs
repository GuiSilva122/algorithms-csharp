namespace LeetCode._75
{
    public class UnionFind_NumberOfProvinces
    {
        // DFS
        // O(n^2) time, O(n) space
        public int FindCircleNum(int[][] isConnected)
        {
            int n = isConnected.Length;
            int numberOfComponents = 0;
            var visit = new bool[n];
            for (int i = 0; i < n; i++)
            {
                if (!visit[i])
                {
                    numberOfComponents++;
                    Dfs(i, isConnected, visit);
                }
            }
            return numberOfComponents;
        }
        public void Dfs(int node, int[][] isConnected, bool[] visit)
        {
            visit[node] = true;
            for (int i = 0; i < isConnected.Length; i++)
            {
                if (isConnected[node][i] == 1 && !visit[i])
                {
                    Dfs(i, isConnected, visit);
                }
            }
        }

        // BFS
        // O(n^2) time, O(n) space
        public int FindCircleNumV2(int[][] isConnected)
        {
            int n = isConnected.Length;
            int numberOfComponents = 0;
            var visit = new bool[n];

            for (int i = 0; i < n; i++)
            {
                if (!visit[i])
                {
                    numberOfComponents++;
                    Bfs(i, isConnected, visit);
                }
            }
            return numberOfComponents;
        }
        public void Bfs(int node, int[][] isConnected, bool[] visit)
        {
            var queue = new Queue<int>();
            queue.Enqueue(node);
            visit[node] = true;

            while (queue.Count > 0)
            {
                node = queue.Dequeue();
                for (int i = 0; i < isConnected.Length; i++)
                {
                    if (isConnected[node][i] == 1 && !visit[i])
                    {
                        queue.Enqueue(i);
                        visit[i] = true;
                    }
                }
            }
        }

        // Union Find
        // O(n^2) time, O(n) space
        public int FindCircleNumV3(int[][] isConnected)
        {
            int n = isConnected.Length;
            var dsu = new UnionFind(n);
            int numberOfComponents = n;

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (isConnected[i][j] == 1 && dsu.Find(i) != dsu.Find(j))
                    {
                        numberOfComponents--;
                        dsu.UnionSet(i, j);
                    }
                }
            }
            return numberOfComponents;
        }
    }
    public class UnionFind
    {
        int[] parent;
        int[] rank;
        public UnionFind(int size)
        {
            parent = new int[size];
            for (int i = 0; i < size; i++)
                parent[i] = i;
            rank = new int[size];
        }
        public int Find(int x)
        {
            if (parent[x] != x)
                parent[x] = Find(parent[x]);
            return parent[x];
        }
        public void UnionSet(int x, int y)
        {
            int xset = Find(x); 
            int yset = Find(y);
            if (xset == yset)            
                return;
            else if (rank[xset] < rank[yset])
                parent[xset] = yset;
            else if (rank[xset] > rank[yset])
                parent[yset] = xset;
            else
            {
                parent[yset] = xset;
                rank[xset]++;
            }
        }
    }
}
namespace LeetCode.Graph
{
    public class PathWithMinimumEffort
    {
        public static int MinimumEffortPath(int[][] heights)
        {
            int row = heights.Length;
            int col = heights[0].Length;
            if (row == 1 && col == 1) 
                return 0;
            
            var unionFind = new UnionFind(heights);
            List<Edge> edgeList = unionFind.edgeList;
            edgeList.Sort((e1, e2) => e1.Difference - e2.Difference);

            for (int i = 0; i < edgeList.Count; i++)
            {
                int x = edgeList[i].X;
                int y = edgeList[i].Y;
                unionFind.Union(x, y);
                if (unionFind.Find(0) == unionFind.Find(row * col - 1)) 
                    return edgeList[i].Difference;
            }
            return -1;
        }
        private record Edge(int X, int Y, int Difference);
        private class UnionFind
        {
            int[] parent;
            int[] rank;
            public List<Edge> edgeList;
            public UnionFind(int[][] heights)
            {
                int row = heights.Length;
                int col = heights[0].Length;
                parent = new int[row * col];
                rank = new int[row * col];
                edgeList = new List<Edge>();
                for (int currentRow = 0; currentRow < row; currentRow++)
                {
                    for (int currentCol = 0; currentCol < col; currentCol++)
                    {
                        if (currentRow > 0)
                        {
                            edgeList.Add(new Edge(
                                currentRow * col + currentCol,
                                (currentRow - 1) * col + currentCol,
                                Math.Abs(heights[currentRow][currentCol] - heights[currentRow - 1][currentCol]))
                            );
                        }
                        if (currentCol > 0)
                        {
                            edgeList.Add(new Edge(
                                currentRow * col + currentCol,
                                currentRow * col + currentCol - 1,
                                Math.Abs(heights[currentRow][currentCol] - heights[currentRow][currentCol - 1]))
                            );
                        }
                        parent[currentRow * col + currentCol] = currentRow * col + currentCol;
                    }
                }
            }
            
            public int Find(int x)
            {
                if (parent[x] != x) parent[x] = Find(parent[x]);
                return parent[x];
            }

            public void Union(int x, int y)
            {
                int parentX = Find(x);
                int parentY = Find(y);
                if (parentX != parentY)
                {
                    if (rank[parentX] > rank[parentY]) 
                        parent[parentY] = parentX;
                    else if (rank[parentX] < rank[parentY]) 
                        parent[parentX] = parentY;
                    else
                    {
                        parent[parentY] = parentX;
                        rank[parentX] += 1;
                    }
                }
            }
        }

        public static void TestSolution()
        {

        }
    }
}
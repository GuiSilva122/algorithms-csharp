using System.Text;

namespace LeetCode
{
    public class Graph_PacificOceanAtlanticOcean
    {
        public IList<IList<int>> PacificAtlantic(int[][] heights)
        {
            if (heights.Length == 0 || heights[0].Length == 0)
                return new List<IList<int>>();

            var numRows = heights.Length;
            var numCols = heights[0].Length;
            var pacificQueue = new Queue<(int, int)>();
            var atlanticQueue = new Queue<(int, int)>();
            var directions = new int[][]
            {
                new int[] { 0, 1 },
                new int[] { 1, 0 },
                new int[] { -1, 0 },
                new int[] { 0, -1 }
            };

            for (int i = 0; i < numRows; i++)
            {
                pacificQueue.Enqueue((i, 0));
                atlanticQueue.Enqueue((i, numCols - 1));
            }
            for (int i = 0; i < numCols; i++)
            {
                pacificQueue.Enqueue((0, i));
                atlanticQueue.Enqueue((numRows - 1, i));
            }
            var pacificReachable = Bfs(heights, pacificQueue, numRows, numCols, directions);
            var atlanticReachable = Bfs(heights, atlanticQueue, numRows, numCols, directions);

            var commonCells = new List<IList<int>>();
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    if (pacificReachable[i, j] && atlanticReachable[i, j])
                        commonCells.Add(new List<int> { i, j });
                }
            }
            return commonCells;
        }

        private bool[,] Bfs(int[][] heights, Queue<(int, int)> queue, int numRows, int numCols, int[][] directions)
        {
            bool[,] reachable = new bool[numRows, numCols];
            while (queue.Count > 0)
            {
                var (row, col) = queue.Dequeue();
                reachable[row, col] = true;

                foreach (var direction in directions)
                {
                    int newRow = row + direction[0];
                    int newCol = col + direction[1];
                    if (newRow < 0 || newRow >= numRows || newCol < 0 || newCol >= numCols)
                        continue;
                    if (reachable[newRow, newCol])
                        continue;
                    if (heights[newRow][newCol] < heights[row][col])
                        continue;
                    queue.Enqueue((newRow, newCol));
                }
            }
            return reachable;
        }





        public IList<IList<int>> PacificAtlanticV2(int[][] heights)
        {
            if (heights.Length == 0 || heights[0].Length == 0)
                return new List<IList<int>>();

            var numRows = heights.Length;
            var numCols = heights[0].Length;
            var directions = new int[][]
            {
                new int[] { 0, 1 },
                new int[] { 1, 0 },
                new int[] { -1, 0 },
                new int[] { 0, -1 }
            };
            var pacificReachable = new bool[numRows,numCols];
            var atlanticReachable = new bool[numRows,numCols];

            for (int i = 0; i < numRows; i++)
            {
                Dfs(heights, i, 0, pacificReachable, numRows, numCols, directions);
                Dfs(heights, i, numCols - 1, atlanticReachable, numRows, numCols, directions);
            }
            for (int i = 0; i < numCols; i++)
            {
                Dfs(heights, 0, i, pacificReachable, numRows, numCols, directions);
                Dfs(heights, numRows - 1, i, atlanticReachable, numRows, numCols, directions);
            }

            var commonCells = new List<IList<int>>();
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    if (pacificReachable[i,j] && atlanticReachable[i,j])
                        commonCells.Add(new List<int> { i, j });
                }
            }
            return commonCells;
        }

        private void Dfs(int[][] heights, int row, int col, bool[,] reachable, int numRows, int numCols, int[][] directions)
        {
            reachable[row,col] = true;
            foreach (var dir in directions)
            {
                int newRow = row + dir[0];
                int newCol = col + dir[1];
                if (newRow < 0 || newRow >= numRows || newCol < 0 || newCol >= numCols)
                    continue;
                if (reachable[newRow,newCol])
                    continue;
                if (heights[newRow][newCol] < heights[row][col])
                    continue;
                
                Dfs(heights, newRow, newCol, reachable, numRows, numCols, directions);
            }
        }
    }
}

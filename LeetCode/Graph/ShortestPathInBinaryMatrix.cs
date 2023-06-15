namespace LeetCode.Graph
{
    public class ShortestPathInBinaryMatrix
    {
        private int[][] directions = new int[][]
        {
            new int[] {-1, -1 }, new int[] {-1, 0 },
            new int[] {-1, 1 }, new int[] {0, -1 },
            new int[] {0, 1 }, new int[] {1, -1 },
            new int[] {1, 0 }, new int[] {1, 1 }
        };
        // BFS
        // O(N) time, O(N) space
        public int ShortestPathBinaryMatrix(int[][] grid)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;
            if (grid[0][0] != 0 || grid[grid.Length - 1][grid[0].Length - 1] != 0)
                return -1;
            var queue = new Queue<(int, int, int)>();
            queue.Enqueue((0, 0, 0));
            var visited = new bool[grid.Length, grid[0].Length];
            while (queue.Count > 0)
            {
                var (level, row, col) = queue.Dequeue();
                if (!visited[row, col])
                {
                    visited[row, col] = true;
                    if (row == grid.Length - 1 && col == grid[0].Length - 1)
                        return level + 1;
                    foreach (var direction in directions)
                    {
                        int newRow = row + direction[0];
                        int newCol = col + direction[1];
                        if (newRow < 0 || newCol < 0 || newRow >= grid.Length || newCol >= grid[0].Length ||
                            grid[newRow][newCol] != 0)
                            continue;
                        queue.Enqueue((level + 1, newRow, newCol));
                    }
                }
            }
            return -1;
        }
        // A* Algorithm
        // O(NlogN) time, O(N) space
        private record Candidate(int Row, int Col, int DistanceSoFar, int TotalEstimate);
        public int ShortestPathBinaryMatrixV2(int[][] grid)
        {
            if (grid[0][0] != 0 || grid[grid.Length - 1][grid[0].Length - 1] != 0)
                return -1;

            var comparer = Comparer<Candidate>.Create((a, b) => a.TotalEstimate - b.TotalEstimate);
            var pq = new PriorityQueue<Candidate, Candidate>(comparer);
            var firstCandidate = new Candidate(0, 0, 1, Estimate(0, 0, grid));
            pq.Enqueue(firstCandidate, firstCandidate);

            var visited = new bool[grid.Length,grid[0].Length];
            while (pq.Count > 0)
            {
                var best = pq.Dequeue();
                if (best.Row == grid.Length - 1 && best.Col == grid[0].Length - 1)
                    return best.DistanceSoFar;
                
                if (visited[best.Row,best.Col])
                    continue;

                visited[best.Row,best.Col] = true;

                foreach (var direction in directions)
                {
                    int neighbourRow = best.Row + direction[0];
                    int neighbourCol = best.Col + direction[1];
                    if (IsInvalidCoordinate(grid, neighbourRow, neighbourCol))
                        continue;
                    // This check isn't necessary for correctness, but it greatly improves performance.
                    if (visited[neighbourRow,neighbourCol])
                        continue;
                    // Otherwise, we need to create a Candidate object for the option of going to neighbor through the current cell.
                    int newDistance = best.DistanceSoFar + 1;
                    int totalEstimate = newDistance + Estimate(neighbourRow, neighbourCol, grid);
                    var candidate = new Candidate(neighbourRow, neighbourCol, newDistance, totalEstimate);
                    pq.Enqueue(candidate, candidate);
                }
            }
            return -1;
        }
        private bool IsInvalidCoordinate(int[][] grid, int row, int col)
            => (row < 0 || col < 0 || row >= grid.Length || col >= grid[0].Length || grid[row][col] != 0); 
        
        // Get the best case estimate of how much further it is to the bottom-right cell.
        private int Estimate(int row, int col, int[][] grid)
        {
            int remainingRows = grid.Length - row - 1;
            int remainingCols = grid[0].Length - col - 1;
            return Math.Max(remainingRows, remainingCols);
        }
    }
}
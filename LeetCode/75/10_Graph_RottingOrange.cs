namespace LeetCode._75
{
    public class Graph_RottingOrange
    {
        // O(nm) time, O(mn) space
        public int OrangesRotting(int[][] grid)
        {
            var queue = new Queue<(int, int)>();
            int freshOranges = 0;
            int ROWS = grid.Length, COLS = grid[0].Length;

            for (int row = 0; row < ROWS; row++)
            {
                for (int col = 0; col < COLS; col++)
                {
                    if (grid[row][col] == 2)
                        queue.Enqueue((row, col));
                    else if (grid[row][col] == 1)
                        freshOranges++;
                }
            }
            queue.Enqueue((-1, -1));
            int minutesElapsed = -1;
            var directions = new int[][] { new int[] { -1, 0 }, new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { 0, -1 } };

            while (queue.Count > 0)
            {
                var (row, col) = queue.Dequeue();
                if (row == -1)
                {
                    minutesElapsed++;
                    if (queue.Count > 0)
                        queue.Enqueue((-1, -1));
                }
                else
                {
                    foreach (int[] direction in directions)
                    {
                        int neighborRow = row + direction[0];
                        int neighborCol = col + direction[1];
                        if (neighborRow >= 0 && neighborRow < ROWS && neighborCol >= 0 && neighborCol < COLS)
                        {
                            if (grid[neighborRow][neighborCol] == 1)
                            {
                                grid[neighborRow][neighborCol] = 2;
                                freshOranges--;
                                queue.Enqueue((neighborRow, neighborCol));
                            }
                        }
                    }
                }
            }
            return freshOranges == 0 ? minutesElapsed : -1;
        }
    }
}

namespace LeetCode._75
{
    public class Matrix_FindTheBall
    {
        // Deep First Search
        // O(mn) time, O(m) space
        public int[] FindBallV1(int[][] grid)
        {
            int[] result = new int[grid[0].Length];
            for (int i = 0; i < grid[0].Length; i++)
                result[i] = FindBallDropColumn(0, i, grid);
            return result;
        }

        public int FindBallDropColumn(int row, int col, int[][] grid)
        {
            if (row == grid.Length)
                return col;
            int nextColumn = col + grid[row][col];
            if (nextColumn < 0 || nextColumn > grid[0].Length - 1 ||
                grid[row][col] != grid[row][nextColumn])
            {
                return -1;
            }
            return FindBallDropColumn(row + 1, nextColumn, grid);
        }

        // Dynamic Programming Memoization
        // O(mn) time, O(mn) space
        public int[] FindBallV2(int[][] grid)
        {
            int[] result = new int[grid[0].Length];
            
            var memo = new int[grid.Length + 1][];
            for (int i = 0; i < memo.Length; i++)
                memo[i] = new int[grid[0].Length];

            for (int row = grid.Length; row >= 0; row--)
            {
                for (int col = 0; col < grid[0].Length; col++)
                {
                    if (row == grid.Length)
                    {
                        memo[row][col] = col;
                        continue;
                    }
                    int nextColumn = col + grid[row][col];
                    if (nextColumn < 0 || nextColumn > grid[0].Length - 1 ||
                        grid[row][col] != grid[row][nextColumn])
                    {
                        memo[row][col] = -1;
                    }
                    else
                        memo[row][col] = memo[row + 1][nextColumn];

                    if (row == 0)
                        result[col] = memo[row][col];
                }
            }
            return result;
        }

        // Iterative Approach, Simulation
        // O(mn) time, O(1) space
        public int[] FindBallV3(int[][] grid)
        {
            int[] result = new int[grid[0].Length];

            for (int col = 0; col < grid[0].Length; col++)
            {
                int currentCol = col;
                for (int row = 0; row < grid.Length; row++)
                {
                    int nextColumn = currentCol + grid[row][currentCol];
                    if (nextColumn < 0 || nextColumn > grid[0].Length - 1 ||
                        grid[row][currentCol] != grid[row][nextColumn])
                    {
                        result[col] = -1;
                        break;
                    }
                    result[col] = nextColumn;
                    currentCol = nextColumn;
                }
            }
            return result;
        }
    }
}
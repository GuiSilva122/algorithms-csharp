namespace LeetCode._75
{
    public class DP_UniquePaths
    {
        // Recursive Top down
        // O(2^(n + m)) time, O(n + m) space
        public int UniquePathsV1(int m, int n)
        {
            if (m == 0 || n == 0) return 0;
            if (m == 1 && n == 1) return 1;
            return UniquePathsV1(m - 1, n) + UniquePathsV1(m, n - 1);
        }

        // Memoization Top down
        // O(n*m) time, O(n + m) space
        private Dictionary<(int, int), int> memo = new Dictionary<(int, int), int>();
        public int UniquePathsV2(int m, int n)
        {
            if (m == 0 || n == 0) return 0;
            if (m == 1 && n == 1) return 1;
            if (memo.ContainsKey((m, n))) return memo[(m, n)];
            memo.Add((m, n), UniquePathsV2(m - 1, n) + UniquePathsV2(m, n - 1));
            return memo[(m, n)];
        }

        // Tabulation bottom up
        // O(n * m) time, O(n + m) space
        public int UniquePathsV3(int m, int n)
        {
            if (m == 0 || n == 0) return 0;
            if (m == 1 && n == 1) return 1;
            var grid = GetGridMByN(m, n);
            grid[1][1] = 1;
            for (int row = 0; row <= m; row++)
            {
                for (int column = 0; column <= n; column++)
                {
                    var current = grid[row][column];
                    if (column + 1 <= n) 
                        grid[row][column + 1] += current;
                    if (row + 1 <= m) 
                        grid[row + 1][column] += current;
                }
            }
            return grid[m][n];
        }

        private int[][] GetGridMByN(int m, int n)
        {
            var grid = new int[m][];
            for (int i = 0; i < grid.Length; i++)
                grid[i] = new int[n];
            return grid;
        }
    }
}
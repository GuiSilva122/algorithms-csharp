namespace LeetCode._75
{
    public class Graph_NumOfIslands
    {
        public int NumIslands(char[][] grid)
        {
            var visited = new HashSet<(int, int)>();
            int islandsCount = 0;
            for (int row = 0; row < grid.Length; row++)
                for (int column = 0; column < grid[row].Length; column++)
                    if (DeepFirstSearch(grid, row, column, visited))
                        islandsCount++;
            return islandsCount;
        }

        private bool DeepFirstSearch(char[][] grid, int row, int column, HashSet<(int, int)> visited)
        {
            if (grid[row][column] == '1' && !visited.Contains((row, column)))
            {
                visited.Add((row, column));
                if (row - 1 >= 0) DeepFirstSearch(grid, row - 1, column, visited);
                if (column - 1 >= 0) DeepFirstSearch(grid, row, column - 1, visited);
                if (row + 1 < grid.Length) DeepFirstSearch(grid, row + 1, column, visited);
                if (column + 1 < grid[row].Length) DeepFirstSearch(grid, row, column + 1, visited);
                return true;
            }
            return false;
        }
    }
}
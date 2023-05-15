namespace LeetCode._75
{
    public class _1_Matrix_SpiralOrder
    {
        public IList<int> SpiralOrder(int[][] matrix)
        {
            var result = new List<int>();
            int rows = matrix.Length, columns = matrix[0].Length;
            int top = 0, left = 0, right = columns - 1, down = rows - 1;
            while (result.Count < rows * columns)
            {
                for (int col = left; col <= right; col++)
                {
                    result.Add(matrix[top][col]);
                }
                for (int row = top + 1; row <= down; row++)
                {
                    result.Add(matrix[row][right]);
                }
                if (top != down)
                {
                    for (int col = right - 1; col >= left; col--)
                    {
                        result.Add(matrix[down][col]);
                    }
                }
                if (left != right)
                {
                    for (int row = down - 1; row > top; row--)
                    {
                        result.Add(matrix[row][left]);
                    }
                }
                top++;
                left++;
                right--;
                down--;
            }
            return result;
        }
    }
}
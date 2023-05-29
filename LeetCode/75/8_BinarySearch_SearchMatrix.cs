namespace LeetCode._75
{
    public class BinarySearch_SearchMatrix
    {
        // O(log mn) time, O(1) space
        public bool SearchMatrix(int[][] matrix, int target)
        {
            int m = matrix.Length, n = matrix[0].Length;
            int left = 0, right = (m * n) - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                int row = mid / n;
                int col = mid % n;
                if (target == matrix[row][col])
                    return true;
                else if (target < matrix[row][col])
                    right = mid - 1;
                else if (target > matrix[row][col])
                    left = mid + 1;
            }
            return false;
        }
    }
}
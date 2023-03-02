using CrackingTheCodeInterview.Helpers;
using System;

namespace CrackingTheCodeInterview.ArraysAndStrings
{
    internal static class RotateMatrix
    {
        public static bool Rotate(int[][] matrix)
        {
            if (matrix.Length == 0 || matrix.Length != matrix[0].Length) 
                return false; // Not a square
            
            int n = matrix.Length;

            for (int layer = 0; layer < n / 2; layer++)
            {
                int first = layer;
                int last = n - 1 - layer;
                for (int i = first; i < last; i++)
                {
                    int offset = i - first;
                    int top = matrix[first][i]; // save top

                    // left -> top
                    matrix[first][i] = matrix[last - offset][first];

                    // bottom -> left
                    matrix[last - offset][first] = matrix[last][last - offset];

                    // right -> bottom
                    matrix[last][last - offset] = matrix[i][last];

                    // top -> right
                    matrix[i][last] = top; // right <- saved top
                }
            }
            return true;
        }

        public static void TestSolution()
        {
            int[][] matrix = MatrixHelper.RandomMatrix(3, 3, 0, 9);
            MatrixHelper.PrintMatrix(matrix);
            Rotate(matrix);
            Console.WriteLine();
            MatrixHelper.PrintMatrix(matrix);
        }
    }
}

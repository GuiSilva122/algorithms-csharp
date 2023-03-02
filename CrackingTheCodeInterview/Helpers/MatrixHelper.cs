using System;

namespace CrackingTheCodeInterview.Helpers
{
    internal class MatrixHelper
    {
        private static readonly Random random = new();

        public static int[][] RandomMatrix(int m, int n, int min, int max)
        {
            int[][] matrix = new int[m][];
            for (int i = 0; i < m; i++)
            {
                matrix[i] = new int[n];
                for (int j = 0; j < n; j++)
                    matrix[i][j] = random.Next(min, max);
            }
            return matrix;
        }

        public static void PrintMatrix(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] < 10 && matrix[i][j] > -10)
                        Console.Write(" ");
                    
                    if (matrix[i][j] < 100 && matrix[i][j] > -100)
                        Console.Write(" ");
                    
                    if (matrix[i][j] >= 0)
                    Console.Write(" ");

                    Console.Write(" " + matrix[i][j]);
                }
                Console.WriteLine();
            }
        }
    }
}

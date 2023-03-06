using CrackingTheCodeInterview.ArraysAndStrings.Helpers;
using System;

namespace CrackingTheCodeInterview.ArraysAndStrings
{
    internal class ZeroMatrix
    {
        private static void ZeroFyColumn(int[][] matrix, int columnIndex)
        {
            for (int i = 0; i < matrix.Length; i++)
                matrix[i][columnIndex] = 0;
        }

        private static void ZeroFyLine(int[][] matrix, int lineIndex)
        {
            for (int j = 0; j < matrix[lineIndex].Length; j++)
                matrix[lineIndex][j] = 0;
        }

        public static void zeroMatrix(int[][] matrix)
        {
            var zeroRows = new bool[matrix.Length];
            var zeroColumns = new bool[matrix[0].Length];

            for (int lineIndex = 0; lineIndex < matrix.Length; lineIndex++)
            {
                for (int columnIndex = 0; columnIndex < matrix[lineIndex].Length; columnIndex++)
                {
                    if (matrix[lineIndex][columnIndex] == 0)
                    {
                        zeroRows[lineIndex] = true;
                        zeroColumns[columnIndex] = true;
                    }
                }
            }

            // Nullify rows
            for (int i = 0; i < zeroRows.Length; i++)
                if (zeroRows[i])
                    ZeroFyLine(matrix, i);

            // Nullify columns
            for (int j = 0; j < zeroColumns.Length; j++)
                if (zeroColumns[j])
                    ZeroFyColumn(matrix, j);
        }

        public static void TestSolution()
        {
            int nrows = 5;
            int ncols = 4;
            int[][] matrix = MatrixHelper.RandomMatrix(nrows, ncols, -10, 10);

            MatrixHelper.PrintMatrix(matrix);

            zeroMatrix(matrix);

            Console.WriteLine();

            MatrixHelper.PrintMatrix(matrix);
        }
    }
}

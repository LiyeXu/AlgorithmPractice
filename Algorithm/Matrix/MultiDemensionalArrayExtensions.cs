using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Matrix
{
    public static class MultiDemensionalArrayExtensions
    {
        public static void RotateLeft<T>(this T[,] matrix)
        {
            if (matrix.GetLength(0) == 1)
                return;
            matrix.SwapBottomUp();
            matrix.SwapByAuxiliaryDiagonal();
        }

        public static void RotateRight<T>(this T[,] matrix)
        {
            if (matrix.GetLength(0) == 1)
                return;
            matrix.SwapBottomUp();
            matrix.SwapByDiagonal();
        }

        public static void SwapBottomUp<T>(this T[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0) / 2; i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    var tmp = matrix[i, j];
                    int k = matrix.GetLength(0) - 1 - i;
                    matrix[i, j] = matrix[k, j];
                    matrix[k, j] = tmp;
                }
            }
        }

        public static void SwapByAuxiliaryDiagonal<T>(this T[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1 - i; j++)
                {
                    var tmp = matrix[i, j];
                    int u = matrix.GetLength(1) - 1 - j;
                    int v = matrix.GetLength(0) - 1 - i;
                    matrix[i, j] = matrix[u, v];
                    matrix[u, v] = tmp;
                }
            }
        }

        public static void SwapByDiagonal<T>(this T[,] matrix)
        {
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < i; j++)
                {
                    var tmp = matrix[i, j];
                    matrix[i, j] = matrix[j, i];
                    matrix[j, i] = tmp;
                }
            }
        }
    }
}

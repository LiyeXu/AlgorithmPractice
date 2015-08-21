using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Numerics
{
    public static class Series
    {
        /// <summary>
        /// Get the Nth element of the Fibbonacci series in a definitive way
        /// </summary>
        /// <param name="n">The ordinal number of the element</param>
        /// <returns>The Nth element</returns>
        public static BigInteger Fibbonacci2(int n)
        {
            if (n <= 0)
                throw new ArgumentOutOfRangeException("n");
            if (n == 1 || n == 2)
            {
                return 1;
            }
            BigInteger p = 1;
            BigInteger q = 1;
            BigInteger result = 1;
            for (BigInteger i = 2; i < n; i++)
            {
                result = p + q;
                p = q;
                q = result;
            }
            return result;
        }

        /// <summary>
        /// Get the Nth element of the Fibbonacci series using matrix product
        /// </summary>
        /// <param name="n">The ordinal number of the element</param>
        /// <returns>The Nth element</returns>
        public static BigInteger Fibbonacci(int n)
        {
            if (n <= 0)
                throw new ArgumentOutOfRangeException("n");
            BigInteger[,] m = new BigInteger[,] { { 1, 1 }, { 1, 0 } };
            BigInteger[,] result = DoMatrixPower(m, n - 1);
            return result[0, 0];
        }

        /// <summary>
        /// Get the golden ratio with a specified precision
        /// </summary>
        /// <param name="precision">The precision</param>
        /// <returns>The Phi value</returns>
        public static double Phi(int precision)
        {
            if (precision <= 0)
                throw new ArgumentOutOfRangeException("precision");
            BigInteger[,] m = new BigInteger[,] { { 1, 1 }, { 1, 0 } };
            BigInteger[,] result = DoMatrixPower(m, precision - 1);
            return (double)result[0, 0]/(double)result[0, 1];
        }

        private static BigInteger[,] DoMatrixPower(BigInteger[,] m, int n)
        {
            if (n == 1)
                return m;
            if ((n & 1) == 0)
            {
                var root = DoMatrixPower(m, n / 2);
                BigInteger[,] result = Rank2MatrixProduct(root, root);
                return result;
            }
            else
            {
                var root = DoMatrixPower(m, (n - 1) / 2);
                BigInteger[,] result = Rank2MatrixProduct(root, root);
                result = Rank2MatrixProduct(result, m);
                return result;
            }
        }

        private static BigInteger[,] Rank2MatrixProduct(BigInteger[,] a, BigInteger[,] b)
        {
            BigInteger[,] result = new BigInteger[2, 2];
            result[0, 0] = a[0, 0] * b[0, 0] + a[0, 1] * b[1, 0];
            result[0, 1] = a[0, 0] * b[0, 1] + a[0, 1] * b[1, 1];
            result[1, 0] = a[1, 0] * b[0, 0] + a[1, 1] * b[1, 0];
            result[1, 1] = a[1, 0] * b[0, 1] + a[1, 1] * b[1, 1];
            return result;
        }
    }
}

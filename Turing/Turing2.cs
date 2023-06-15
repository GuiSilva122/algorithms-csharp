using System;

namespace Turing
{
    public class Turing2
    {
        public static int[] Decode(int[] k, int x)
        {
            var output = new int[k.Length];
            if (x != 0 && x % k.Length == 0)
                return k;
            else if (x == 0)
                return output;
            else
            {
                for (int i = 0; i < k.Length; i++)
                {
                    int times = Math.Abs(x);
                    int index = GetIndex(i, x) %  k.Length;
                    int currentSum = 0;
                    while (times-- > 0)
                    {
                        currentSum += k[index % k.Length];
                        MoveIndex(x, ref index, k.Length);
                    }
                    output[i] = currentSum;
                }
            }
            return output;
        }
        private static int GetIndex(int i, int x)
        {
            if (x > 0) return i + x;
            return i - x;
        }
        private static void MoveIndex(int x, ref int index, int length)
        {
            if (x > 0)
            {
                if (index == 0)
                    index = length - 1;
                else 
                    index--;
            }
            else
            {
                if (index == length - 1)
                    index = 0;
                else
                    index++;
            }
        }

        public static int Solution(int[] k)
        {
            Array.Sort(k);
            int sum = 0;
            int halfIndex = k.Length / 2;
            for (int i = 0; i < k.Length / 2; i += 2) {
                sum = Math.Max(sum, k[i] + k[halfIndex]);
                halfIndex += 2;
            }
            return sum;
        }

        public static void TestSolution()
        {
            int[] k = new int[] { 1, 4, 3, 2, 6, 5 };
            var result = Solution(k);
        }
    }
}

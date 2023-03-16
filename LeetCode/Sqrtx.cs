namespace LeetCode
{
    public static class Sqrtx
    {
        // Pocket Calculator Algorithm
        // O(1) time, O(1) space
        // Sqrt(x) = e^(1/2 * log x)
        public static int MySqrtV1(int x)
        {
            if (x < 2)
                return x;

            int left = (int)Math.Pow(Math.E, 0.5 * Math.Log(x));
            int right = left + 1;

            return (long)right * right > x ? left : right;
        }

        // Binary Search
        // O(log n) time, O(1) space
        public static int MySqrtV2(int x)
        {
            if (x < 2)
                return x;

            int left = 2;
            int right = x / 2;

            while (left <= right)
            {
                int pivot = left + (right - left) / 2;
                long num = (long)pivot * pivot;
                if (num > x)
                    right = pivot - 1;
                else if (num < x)
                    left = pivot + 1;
                else
                    return pivot;
            }
            return right;
        }

        // Recursion + Bit Shifts
        // O(log n) time, O(log n) space
        // Sqrt(x) = 2 Sqrt(x/4) --> MySqrtV3(x) = 2 * MySqrtV3(x/4)
        // x << y = x*2^y
        // x >> y = x/2^y
        public static int MySqrtV3(int x)
        {
            if (x < 2)
                return x;

            int left = MySqrtV3(x >> 2) << 1;
            int right = left + 1;
            return (long)right * right > x ? left : right;
        }

        // Newton's Method
        // O(log n) time, O(1) space
        public static int MySqrtV4(int x)
        {
            if (x < 2) 
                return x;

            double x0 = x;
            double x1 = (x0 + x / x0) / 2.0;
            
            while (Math.Abs(x0 - x1) >= 1)
            {
                x0 = x1;
                x1 = (x0 + x / x0) / 2.0;
            }

            return (int)x1;
        }

        public static void TestSolution()
        {

        }
    }
}

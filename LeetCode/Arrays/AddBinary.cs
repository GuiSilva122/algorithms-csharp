using System.Numerics;
using System.Text;

namespace LeetCode.Arrays
{
    public static class AddBinary
    {
        public static string AddV1(string a, string b)
            => Convert.ToString(Convert.ToInt32(a, 2) + Convert.ToInt32(b, 2), 2);

        public static string AddV2(string a, string b)
        {
            int aLength = a.Length;
            int bLength = b.Length;
            if (aLength < bLength) return AddV2(b, a);

            int biggerLength = Math.Max(aLength, bLength);
            int j = bLength - 1;
            int carry = 0;
            var sum = new StringBuilder(biggerLength);

            for (int i = biggerLength - 1; i >= 0; i--)
            {
                if (a[i] == '1')
                    carry++;

                if (j >= 0 && b[j--] == '1')
                    carry++;

                if (carry % 2 == 0)
                    sum.Append('0');
                else
                    sum.Append('1');

                carry /= 2;
            }

            if (carry == 1)
                sum.Append('1');

            return new string(sum.ToString().Reverse().ToArray());
        }

        public static string AddV3(string a, string b)
        {
            var x = new BigInteger(Convert.ToInt32(a, 2));
            var y = new BigInteger(Convert.ToInt32(b, 2));
            var zero = BigInteger.Zero;
            BigInteger carry;
            BigInteger answer;

            while (y != zero)
            {
                answer = x ^ y;
                carry = (x & y) << 1;
                x = answer;
                y = carry;
            }
            return Convert.ToString((int)x, 2);
        }

        public static void TestSolution()
        {
            string a = "11";
            string b = "1";
            string expected = "100";
            string result = AddV3(a, b);
            Console.WriteLine($"a = {a}, b = {b}, result = {result}, expected = {expected}");

            a = "1010";
            b = "1011";
            expected = "10101";
            result = AddV3(a, b);
            Console.WriteLine($"a = {a}, b = {b}, result = {result}, expected = {expected}");
        }
    }
}

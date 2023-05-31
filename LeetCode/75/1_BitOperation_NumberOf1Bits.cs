namespace LeetCode._75
{
    public class BitOperation_NumberOf1Bits
    {
        // O(1) time, O(1) space
        public int HammingWeight(uint n)
        {
            int bits = 0;
            int mask = 1;
            for (int i = 0; i < 32; i++)
            {
                if ((n & mask) != 0)
                    bits++;
                mask <<= 1;
            }
            return bits;
        }
        
        // O(1) time, O(1) space
        public int HammingWeightV2(uint n)
        {
            int sum = 0;
            while (n != 0)
            {
                sum++;
                n &= (n - 1);
            }
            return sum;
        }
    }
}

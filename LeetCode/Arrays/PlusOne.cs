namespace LeetCode.Arrays
{
    public class PlusOne
    {
        public static int[] AddOne(int[] digits)
        {
            int length = digits.Length;
            for (int i = length - 1; i >= 0; i--)
            {
                if (digits[i] == 9)
                    digits[i] = 0;
                else
                {
                    digits[i]++;
                    return digits;
                }
            }
            var newDigits = new int[length + 1];
            newDigits[0]++;
            return newDigits;
        }
    }
}
namespace LeetCode
{
    internal class RomanToInt
    {
        private static readonly Dictionary<char, int> RomansMap = new()
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 }
        };

        public static int Convert(string romanNumber)
        {
            int converted = 0;

            for (int i = 0; i < romanNumber.Length; i++)
            {
                int currentValue = RomansMap[romanNumber[i]];
                int nextValue = 0;

                if (i + 1 < romanNumber.Length)
                    nextValue = RomansMap[romanNumber[i + 1]];

                if (currentValue < nextValue)
                {
                    converted += (nextValue - currentValue);
                    i++;
                }
                else
                    converted += currentValue;
            }
            return converted;
        }

        public static void TestSolution()
        {
            var result = Convert("III"); //3
            result = Convert("LVIII"); //58
            result = Convert("MCMXCIV"); //1994
        }
    }
}

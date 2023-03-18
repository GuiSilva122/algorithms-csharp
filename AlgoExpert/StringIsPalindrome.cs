namespace AlgoExpert
{
    public static class StringIsPalindrome
    {
        public static bool IsPalindrome(string str)
        {
            if (str.Length == 1) return true;

            int comparisons = str.Length / 2;
            if (str.Length % 2 != 0 && comparisons > 1) 
                comparisons--;

            int i = 0;
            while (i < comparisons)
            {
                if (str[i] != str[str.Length - 1 - i])
                    return false;
                i++;
            }
            return true;
        }

        public static void TestSolution()
        {
            string str = "abb";
            var expected = false;
            var result = IsPalindrome(str);
            
            Console.WriteLine($"str = {str}, expected = {expected}, result = {result}");
        }
    }
}
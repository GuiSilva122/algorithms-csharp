namespace LeetCode._75
{
    public class HashMap_BullsAndCows
    {
        public static string GetHint(string secret, string guess)
        {
            var hash = new int[10];
            int bulls = 0;
            int cows = 0;
            for (int i = 0; i < guess.Length; i++)
            {
                if (secret[i] == guess[i])
                {
                    bulls++;
                }
                else
                {
                    if (hash[secret[i] - '0'] < 0)
                        cows++;
                    if (hash[guess[i] - '0'] > 0)
                        cows++;
                    hash[secret[i] - '0']++;
                    hash[guess[i] - '0']--;
                }
            }
            return $"{bulls}A{cows}B";
        }

        public static void TestSolution()
        {
            var secret = "1949";
            secret.Substring
            var guess =  "4422";
            var result = GetHint(secret, guess);
        }
    }
}
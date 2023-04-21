namespace LeetCode._75
{
    public class Greedy_LongestPalindrome
    {
        public int LongestPalindrome(string s)
        {
            int[] count = new int[128];
            foreach (char c in s) 
                count[c]++;

            int answer = 0;
            for (int i = 0; i < count.Length; i++)
            {
                answer += count[i] / 2 * 2;
                if (answer % 2 == 0 && count[i] % 2 == 1)
                    answer++;
            }
            return answer;
        }
    }
}
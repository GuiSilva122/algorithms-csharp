namespace LeetCode._75
{
    public class WindowSliding_LongestSubstringWithoutRepeatingCharacters
    {
        public int LengthOfLongestSubstring(string s)
        {
            int answer = 0;
            int start = 0;
            int[] frequency = new int[128];
            for (int end = 0; end < s.Length; end++)
            {
                frequency[s[end]]++;
                while (frequency[s[end]] > 1)
                {
                    frequency[s[start]]--;
                    start++;
                }
                answer = Math.Max(answer, end - start + 1);
            }
            return answer;
        }
    }
}
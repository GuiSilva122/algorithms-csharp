namespace LeetCode.SlidingWIndow
{
    public class LongestStringOneConsecutives
    {
        public static int GetLongestStringOneConsecutives(string s)
        {
            int start = 0;
            int curr = 0;
            int answer = 0;
            for (int end = 0; end < s.Length; end++)
            {
                if (s[end] == '0')
                    curr++;

                while (curr > 1)
                {
                    if (s[start] == '0')
                        curr--;
                    start++;
                }
                answer = Math.Max(answer, end - start + 1);
            }
            return answer;
        }
    }
}
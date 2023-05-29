namespace LeetCode._75
{
    public class WindowSliding_MinimumWindowSubstring
    {
        public string MinWindow(string s, string t)
        {
            var frequencyT = new Dictionary<char, int>();
            foreach (char c in t)
                frequencyT[c] = frequencyT.GetValueOrDefault(c, 0) + 1;
            
            int start = 0;
            int numberOfUniqueCharInT = frequencyT.Count;
            int formed = 0;
            var windowCounts = new Dictionary<char, int>();
            
            int? minWindowSize;
            int minWindowStart;
            int minWindowEnd;
            (minWindowSize, minWindowStart, minWindowEnd) = (null, 0, 0);

            for (int end = 0; end < s.Length; end++)
            {
                char c = s[end];
                windowCounts[c] = windowCounts.GetValueOrDefault(c, 0) + 1;
                if (frequencyT.ContainsKey(c) && windowCounts[c] == frequencyT[c])
                {
                    formed++;
                }
                while (start <= end && formed == numberOfUniqueCharInT)
                {
                    c = s[start];
                    int currentWindowSize = (end - start + 1);
                    if (minWindowSize == null || currentWindowSize < minWindowSize)
                    {
                        (minWindowSize, minWindowStart, minWindowEnd) = (currentWindowSize, start, end);
                    }
                    if (windowCounts.ContainsKey(c))
                    {
                        if (windowCounts[c] > 1)
                            windowCounts[c]--;
                        else
                            windowCounts.Remove(c);
                    }
                    if (frequencyT.ContainsKey(c) && windowCounts.GetValueOrDefault(c, 0) < frequencyT[c])
                        formed--;
                    start++;
                }
            }
            return minWindowSize == null ? 
                string.Empty : 
                s.Substring(minWindowStart, minWindowEnd - minWindowStart + 1);
        }
    }
}

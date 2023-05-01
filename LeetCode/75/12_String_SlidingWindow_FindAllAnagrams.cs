namespace LeetCode._75
{
    public class SlidingWindow_FindAllAnagrams
    {
        // Sliding window with HashMap
        // Given ns equals to s.Length and K the number of distincts values for s and p
        // O(ns) time, O(k) space, k = 26 (alphabet size)
        public static IList<int> FindAnagramsV1(string s, string p)
        {
            var output = new List<int>();
            if (s.Length < p.Length)
                return output;

            var pCount = new Dictionary<char, int>();
            var sCount = new Dictionary<char, int>();

            foreach (char c in p)
            {
                if (!pCount.ContainsKey(c))
                    pCount.Add(c, 1);
                else
                    pCount[c]++;
            }
            for (int i = 0; i < s.Length; i++)
            {
                if (sCount.ContainsKey(s[i]))
                    sCount[s[i]]++;
                else
                    sCount.Add(s[i], 1);

                if (i >= p.Length)
                {
                    var ch = s[i - p.Length];
                    if (sCount.ContainsKey(ch))
                    {
                        if (sCount[ch] == 1)
                            sCount.Remove(ch);
                        else
                            sCount[ch]--;
                    }
                }
                // compare hashmap in the sliding window with the reference hashmap
                if (pCount.Count == sCount.Count && !pCount.Except(sCount).Any())
                    output.Add(i - p.Length + 1);
            }
            return output;
        }

        // Sliding window with Array
        // Given ns equals to s.Length and K the number of distincts values for s and p
        // O(ns) time, O(k) space, k = 26 (alphabet size)
        public static IList<int> FindAnagrams(string s, string p)
        {
            var output = new List<int>();
            if (s.Length < p.Length)
                return output;

            var pCount = new int[26];
            var sCount = new int[26];

            foreach (char c in p)
                pCount[c - 'a']++;
            
            for (int i = 0; i < s.Length; i++)
            {
                sCount[s[i] - 'a']++;

                if (i >= p.Length)
                    sCount[s[i - p.Length] - 'a']--;

                if (Enumerable.SequenceEqual(pCount, sCount))
                    output.Add(i - p.Length + 1);
            }
            return output;
        }

        public static void TestSolution()
        {
            var s = "cbaebabacd";
            var p = "abc";
            var result = FindAnagrams(s, p);
        }
    }
}

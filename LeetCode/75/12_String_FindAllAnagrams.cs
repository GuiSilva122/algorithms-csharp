namespace LeetCode._75
{
    public class String_FindAllAnagrams
    {
        public static IList<int> FindAnagrams(string s, string p)
        {
            int ns = s.Length; 
            int np = p.Length;
            if (ns < np) return new List<int>();
            
            var pCount = new Dictionary<char, int>();
            var sCount = new Dictionary<char, int>();

            foreach (char ch in p)
            {
                if (pCount.ContainsKey(ch))
                    pCount[ch]++;
                else
                    pCount.Add(ch, 1);
            }

            var output = new List<int>();

            for (int i = 0; i < ns; ++i)
            {  
                char ch = s[i];
                if (sCount.ContainsKey(ch))
                    sCount[ch]++;
                else
                    sCount.Add(ch, 1);
                
                if (i >= np)
                {
                    ch = s[i - np];
                    if (sCount[ch] == 1)
                        sCount.Remove(ch);
                    else
                        sCount[ch]--;
                }
                
                if (pCount.Count == sCount.Count && !pCount.Except(sCount).Any())
                    output.Add(i - np + 1);
            }
            return output;
        }

        public static IList<int> FindAnagramsV2(string s, string p)
        {
            int ns = s.Length;
            int np = p.Length;
            if (ns < np) return new List<int>();

            int[] pCount = new int[26];
            int[] sCount = new int[26];
            foreach (char ch in p)
                pCount[ch - 'a']++;
            
            var output = new List<int>();

            for (int i = 0; i < ns; ++i)
            {
                sCount[s[i] - 'a']++;

                if (i >= np)
                    sCount[s[i - np] - 'a']--;

                if (Enumerable.SequenceEqual(pCount, sCount))
                    output.Add(i - np + 1);
            }
            return output;
        }

        public static void TestSolution()
        {
            var s = "cbaebabacd";
            var p = "abc";

            var output = FindAnagramsV2(s, p);
        }
    }
}

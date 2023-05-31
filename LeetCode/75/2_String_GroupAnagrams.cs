using System.Text;

namespace LeetCode._75
{
    public class String_GroupAnagrams
    {
        // O(n(m log m)) time, O(nm) space
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var hash = new Dictionary<string, List<string>>();
            foreach (string word in strs)
            {
                var wordArray = word.ToCharArray();
                Array.Sort(wordArray);
                string orderedWordKey = new string(wordArray);
                if (!hash.ContainsKey(orderedWordKey))
                    hash[orderedWordKey] = new List<string>();
                hash[orderedWordKey].Add(word);
            }
            var results = new List<IList<string>>(hash.Count);
            foreach (var entry in hash)
                results.Add(entry.Value);
            return results;
        }
        // Time Complexity: O(NK), where N is the length of strs, 
        // and K is the maximum length of a string in strs.
        // Space Complexity: O(NK)
        public IList<IList<string>> GroupAnagramsV2(string[] strs)
        {
            if (strs.Length == 0) 
                return new List<IList<string>>();
            var ans = new Dictionary<string, List<string>>();
            int[] count = new int[26];
            foreach (string s in strs)
            {
                Array.Fill(count, 0);
                foreach (char c in s) 
                    count[c - 'a']++;

                var sb = new StringBuilder();
                for (int i = 0; i < 26; i++)
                {
                    sb.Append('#');
                    sb.Append(count[i]);
                }
                string key = sb.ToString();
                if (!ans.ContainsKey(key)) 
                    ans.Add(key, new List<string>());
                ans[key].Add(s);
            }
            return new List<IList<string>>(ans.Values);
        }
    }
}
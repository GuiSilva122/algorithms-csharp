using Microsoft.VisualBasic;
using System.Text;

namespace LeetCode._75
{
    public class IsomorphicString
    {
        // O(n) time, O(1) space
        public bool IsIsomorphicV1(string s, string t)
        {
            int[] mappingDictStoT = new int[256];
            Array.Fill(mappingDictStoT, -1);

            int[] mappingDictTtoS = new int[256];
            Array.Fill(mappingDictTtoS, -1);

            for (int i = 0; i < s.Length; ++i)
            {
                if (mappingDictStoT[s[i]] == -1 && mappingDictTtoS[t[i]] == -1)
                {
                    mappingDictStoT[s[i]] = t[i];
                    mappingDictTtoS[t[i]] = s[i];
                }
                else if (!(mappingDictStoT[s[i]] == t[i] && mappingDictTtoS[t[i]] == s[i]))
                    return false;
            }
            return true;
        }

        private string TransformString(string s)
        {
            var indexMapping = new Dictionary<char, int>();
            var builder = new StringBuilder();

            for (int i = 0; i < s.Length; ++i)
            {
                if (!indexMapping.ContainsKey(s[i]))
                    indexMapping.Add(s[i], i);

                builder.Append(indexMapping[s[i]] + ' ');
            }
            return builder.ToString();
        }

        public bool IsIsomorphicV2(string s, string t)
            => TransformString(s).Equals(TransformString(t));
    }
}
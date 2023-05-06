using static LeetCode._75.Heap_TopKFrequentWords;
using System.Diagnostics.Metrics;

namespace LeetCode._75
{
    public class Heap_TopKFrequentWords
    {
        // Brute force
        // O(n logn) time, O(n) space
        public static IList<string> TopKFrequentV1(string[] words, int k)
        {
            var count = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (!count.ContainsKey(word))
                    count.Add(word, 1);
                else
                    count[word]++;
            }
            var candidates = new List<string>(count.Keys);
            candidates.Sort((w1, w2) => (count[w1].Equals(count[w2]) ? w1.CompareTo(w2) : count[w2] - count[w1]));
            return candidates.GetRange(0, k);
        }

        // Max Heap
        // O(n + klogn) time, O(n) space
        public IList<string> TopKFrequentV2(string[] words, int k)
        {
            var count = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (!count.ContainsKey(word))
                    count.Add(word, 1);
                else
                    count[word]++;
            }
            var comparer = Comparer<(string, int)>.Create((a, b) => {
                var (word1, count1) = a;
                var (word2, count2) = b;
                if (count1 == count2) return word1.CompareTo(word2);
                return count2 - count1;
            });
            var maxHeap = new PriorityQueue<string, (string, int)>(comparer);
            foreach (var entry in count)
                maxHeap.Enqueue(entry.Key, (entry.Key, entry.Value));

            var result = new List<string>();
            for (int i = 0; i < k; i++)
                result.Add(maxHeap.Dequeue());
            return result;
        }

        // Min Heap
        // O(nlogk) time, O(n) space
        public static IList<string> TopKFrequentV3(string[] words, int k)
        {
            var count = new Dictionary<string, int>();
            foreach (string word in words)
            {
                if (!count.ContainsKey(word))
                    count.Add(word, 1);
                else
                    count[word]++;
            }
            var comparer = Comparer<string>.Create((w1, w2) => count[w1].Equals(count[w2]) ? w2.CompareTo(w1) : count[w1] - count[w2]);
            var heap = new PriorityQueue<string, string>(comparer);
            foreach (var word in count.Keys)
            {
                heap.Enqueue(word, word);
                if (heap.Count > k)
                    heap.Dequeue();
            }

            var res = new List<string>();
            while (heap.Count > 0)
                res.Add(heap.Dequeue());

            res.Reverse();
            return res;
        }

        // Bucket Sorting + Trie
        // O(n) time, O(n) space
        private class TrieNode
        {
            public TrieNode[] children;
            public bool isWord;

            public TrieNode()
            {
                children = new TrieNode[26];
                isWord = false;
            }
        }
        public static IList<string> TopKFrequentV4(string[] words, int k)
        {   
            TrieNode[] bucket = new TrieNode[words.Length + 1];
            var cnt = new Dictionary<string, int>();

            foreach (string word in words)
            {
                if (!cnt.ContainsKey(word))
                    cnt.Add(word, 0);
                cnt[word]++;
            }

            foreach (var entry in cnt)
            {
                if (bucket[entry.Value] == null)
                    bucket[entry.Value] = new TrieNode();
                
                AddWord(bucket[entry.Value], entry.Key);
            }

            var res = new List<string>();
            for (int i = words.Length; i > 0; i--)
            {
                if (bucket[i] != null)
                    GetWords(bucket[i], ref k, res, "");
                
                if (k == 0) break;
            }
            return res;
        }

        private static void AddWord(TrieNode root, string word)
        {
            TrieNode cur = root;
            foreach (char c in word)
            {
                if (cur.children[c - 'a'] == null)
                    cur.children[c - 'a'] = new TrieNode();
                
                cur = cur.children[c - 'a'];
            }
            cur.isWord = true;
        }

        private static void GetWords(TrieNode root, ref int k, List<string> result, string prefix)
        {
            if (k == 0) return;

            if (root.isWord)
            {
                k--;
                result.Add(prefix);
            }
            for (int i = 0; i < 26; i++)
            {
                if (root.children[i] != null)
                    GetWords(root.children[i], ref k, result, prefix + (char)(i + 'a'));
            }
        }

        public static void TestSolution()
        {
            var words = new string[] { "i", "love", "leetcode", "i", "love", "coding" };
            var k = 2;
            var result = TopKFrequentV4(words, k);
        }
    }
}
namespace LeetCode._75.Helper
{
    public class TrieNode
    {
        private TrieNode[] links;
        private const int R = 26;
        private bool isEnd;
        public TrieNode() => links = new TrieNode[R];
        public bool ContainsKey(char ch) => links[ch - 'a'] != null;
        public TrieNode Get(char ch) => links[ch - 'a'];
        public void Put(char ch, TrieNode node) => links[ch - 'a'] = node;
        public void SetEnd() => isEnd = true;
        public bool IsEnd() => isEnd;
    }

    public class Trie
    {
        private TrieNode root;
        public Trie() => root = new TrieNode();
        // O(m) time, O(m) space, where m is the length of word
        public void Insert(string word)
        {
            TrieNode node = root;
            for (int i = 0; i < word.Length; i++)
            {
                if (!node.ContainsKey(word[i]))
                    node.Put(word[i], new TrieNode());
                node = node.Get(word[i]);
            }
            node.SetEnd();
        }
        // O(m) time, O(1) space, where m is the length of word
        public bool Search(string word)
        {
            var node = SearchPrefix(word);
            return node != null && node.IsEnd();
        }
        // O(m) time, O(1) space, where m is the length of word
        public bool StartsWith(string prefix)
        {
            var node = SearchPrefix(prefix);
            return node != null;
        }
        // O(m) time, O(1) space, where m is the length of word
        private TrieNode SearchPrefix(String word)
        {
            TrieNode node = root;
            for (int i = 0; i < word.Length; i++)
            {
                if (node.ContainsKey(word[i]))
                    node = node.Get(word[i]);
                else
                    return null;
            }
            return node;
        }
    }
}
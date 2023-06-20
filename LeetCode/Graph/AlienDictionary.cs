using System.Text;

namespace LeetCode.Graph
{
    public class AlienDictionary
    {
        public string AlienOrder(string[] words)
        {
            var graph = new Dictionary<char, List<char>>();
            var counts = new Dictionary<char, int>();
            foreach (var word in words)
            {
                foreach (char c in word)
                {
                    counts[c] = counts.GetValueOrDefault(c, 0);
                    graph[c] = graph.GetValueOrDefault(c, new List<char>());
                }
            }
            for (int i = 0; i < words.Length - 1; i++)
            {
                var word1 = words[i];
                var word2 = words[i + 1];
                // Check that word2 is not a prefix of word1.
                if (word1.Length > word2.Length && word1.StartsWith(word2))
                    return "";
                // Find the first non match and insert the corresponding relation.
                for (int j = 0; j < Math.Min(word1.Length, word2.Length); j++)
                {
                    if (word1[j] != word2[j])
                    {
                        graph[word1[j]].Add(word2[j]);
                        counts[word2[j]]++;
                        break;
                    }
                }
            }
            // Step 2: Breadth-first search.
            var sb = new StringBuilder();
            var queue = new Queue<char>();
            foreach (char c in counts.Keys)
            {
                if (counts[c] == 0)
                    queue.Enqueue(c);
            }
            while (queue.Count > 0)
            {
                var c = queue.Dequeue();
                sb.Append(c);
                foreach (char next in graph[c])
                {
                    counts[next]--;
                    if (counts[next] == 0)
                        queue.Enqueue(next);
                }
            }
            if (sb.Length < counts.Count)
                return "";

            return sb.ToString();
        }
    }
}
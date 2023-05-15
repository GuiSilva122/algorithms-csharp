namespace LeetCode._75
{
    public class Greedy_LongestPalindromeByConcatenatingWords
    {
        public int LongestPalindrome(string[] words)
        {
            var frequencyCount = new Dictionary<string, int>();
            foreach (var word in words)
                frequencyCount[word] = frequencyCount.GetValueOrDefault(word, 0) + 1;
            int answer = 0;
            bool isCentral = false;
            foreach (var entry in frequencyCount)
            {
                var word = entry.Key;
                var count = entry.Value;
                if (word[0] == word[1])
                {
                    if (frequencyCount[word] % 2 == 0)
                        answer += count;
                    else
                    {
                        answer += count - 1;
                        isCentral = true;
                    }
                } // we don't want to process a pair with his reversed part twice
                else if (word[0] < word[1])
                {
                    var reversed = $"{word[1]}{word[0]}";
                    if (frequencyCount.ContainsKey(reversed))
                        answer += 2 * Math.Min(count, frequencyCount[reversed]);
                }
            }
            if (isCentral) answer++;
            return answer * 2;
        }
    }
}
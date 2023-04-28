namespace LeetCode._75
{
    public class String_LongestRepeatingCharacter
    {
        // Sliding Window + Binary Search
        // O(n log n) time, O(m) space, where m is the number of unique characters (26)
        public int CharacterReplacement(string s, int k)
        {
            // binary search over the length of substring
            // lo contains the valid value, and hi contains the invalid value
            int lo = 1;
            int hi = s.Length + 1;

            while (lo + 1 < hi)
            {
                int mid = lo + (hi - lo) / 2;
                if (CanMakeValidSubstring(s, mid, k)) // can we make a valid substring of length `mid`?
                {
                    lo = mid; // explore the right half
                }
                else
                {
                    hi = mid; // explore the left half
                }
            }
                         
            return lo; // length of the longest substring that satisfies the given condition
        }

        private bool CanMakeValidSubstring(string s, int substringLength, int k)
        {
            // take a window of length `substringLength` on the given  string, and move it from left to right.
            // If this window satisfies the condition of a valid string, then we return true

            int[] freqMap = new int[26];
            int maxFrequency = 0;
            int start = 0;
            for (int end = 0; end < s.Length; end += 1)
            {
                freqMap[s[end] - 'A'] += 1;

                // if the window [start, end] exceeds substringLength then move the start pointer one step toward right
                if (end + 1 - start > substringLength)
                {
                    // before moving the pointer toward right, decrease the frequency of the corresponding character
                    freqMap[s[start] - 'A'] -= 1;
                    start += 1;
                }
                // record the maximum frequency seen so far
                maxFrequency = Math.Max(maxFrequency, freqMap[s[end] - 'A']);
                if (substringLength - maxFrequency <= k)
                {
                    return true;
                }
            }
            return false; // we didn't a valid substring of the given size
        }

        // Sliding Window(Slow)
        // O(nm) time, where n is the number of characters in the string and m is the number of unique characters  (26).
        // O(m) space
        public int CharacterReplacementV2(string s, int k)
        {
            var allLetters = new HashSet<char>();

            // collect all unique letters
            for (int i = 0; i < s.Length; i++)
                allLetters.Add(s[i]);

            int maxLength = 0;
            foreach (var letter in allLetters)
            {
                int start = 0;
                int count = 0;
                // initialize a sliding window for each unique letter
                for (int end = 0; end < s.Length; end += 1)
                {
                    if (s[end] == letter)
                        count += 1; // if the letter matches, increase the count
                    
                    // bring start forward until the window is valid again
                    while (!isWindowValid(start, end, count, k))
                    {
                        if (s[start] == letter)
                            count -= 1; // if the letter matches, decrease the count
                        start += 1;
                    }
                    // at this point the window is valid, update maxLength
                    maxLength = Math.Max(maxLength, end + 1 - start);
                }
            }
            return maxLength;
        }

        private bool isWindowValid(int start, int end, int count, int k)
            => end + 1 - start - count <= k;

        // O(n) time, O(m) space, where m is the number of unique characters (26)
        public int CharacterReplacementV3(string s, int k)
        {
            int start = 0;
            int[] frequencyMap = new int[26];
            int maxFrequency = 0;
            int longestSubstringLength = 0;

            for (int end = 0; end < s.Length; end += 1)
            {
                int currentChar = s[end] - 'A';
                frequencyMap[currentChar] += 1;

                // the maximum frequency we have seen in any window yet
                maxFrequency = Math.Max(maxFrequency, frequencyMap[currentChar]);

                // move the start pointer towards right if the current window is invalid
                var isValid = (end + 1 - start - maxFrequency <= k);
                if (!isValid)
                {
                    // offset of the character moving out of the window
                    int outgoingChar = s[start] - 'A';
                    // decrease its frequency
                    frequencyMap[outgoingChar] -= 1;
                    // move the start pointer forward
                    start += 1;
                }
                // the window is valid at this point, note down the length size of the window never decreases
                longestSubstringLength = end + 1 - start;
            }
            return longestSubstringLength;
        }
    }
}
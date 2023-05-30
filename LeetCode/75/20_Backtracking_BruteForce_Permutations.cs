namespace LeetCode._75
{
    public class Backtracking_BruteForce_Permutations
    {
        // Given start + 1 = k and N the number of elements in nums array
        // Time complexity: O(SUM from k=1 to N of P(N, K)) where P(N, k) = N!/(N−k)! = N(N−1)...(N−k+1)
        // this is called k-permutations of n, or partial permutation.

        // Space Complexity: O(N!) since one has to keep N! solutions.
        public IList<IList<int>> Permute(int[] nums)
        {
            var results = new List<IList<int>>();
            var currentPermutation = new List<int>();
            foreach (int num in nums)
                currentPermutation.Add(num);
            Backtrack(results, currentPermutation, nums.Length, 0);
            return results;
        }
        private void Backtrack(List<IList<int>> results, List<int> currentPermutation,
                               int total, int start)
        {
            if (start == total)
            {
                results.Add(new List<int>(currentPermutation));
                return;
            }
            for (int i = start; i < total; i++)
            {
                (currentPermutation[start], currentPermutation[i]) = (currentPermutation[i], currentPermutation[start]);
                Backtrack(results, currentPermutation, total, start + 1);
                (currentPermutation[i], currentPermutation[start]) = (currentPermutation[start], currentPermutation[i]);
            }
        }
    }
}
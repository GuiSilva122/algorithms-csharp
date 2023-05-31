using System.Text;
using System.Xml.Linq;

namespace LeetCode._75
{
    public class BitOperation_SubSetWithDup
    {
        // Bitmasking
        // O(n2^n) time, O(n2^n) space
        public IList<IList<int>> SubsetsWithDupV1(int[] nums)
        {
            var subsets = new List<IList<int>>();
            int n = nums.Length;
            Array.Sort(nums);

            int maxNumberOfSubsets = (int)Math.Pow(2, n);
            var seen = new HashSet<string>();

            for (int subsetIndex = 0; subsetIndex < maxNumberOfSubsets; subsetIndex++)
            {
                var currentSubset = new List<int>();
                var hashcode = new StringBuilder();
                for (int j = 0; j < n; j++)
                {
                    int mask = 1 << j;
                    int isSet = mask & subsetIndex;
                    if (isSet != 0)
                    {
                        currentSubset.Add(nums[j]);
                        hashcode.Append(nums[j]).Append(",");
                    }
                }
                if (!seen.Contains(hashcode.ToString()))
                {
                    seen.Add(hashcode.ToString());
                    subsets.Add(currentSubset);
                }
            }
            return subsets;
        }

        // Cascading (Iterative)
        // O(n2^n) time, O(logn) space, because of sorting
        public IList<IList<int>> SubsetsWithDupV2(int[] nums)
        {
            Array.Sort(nums);
            var subsets = new List<IList<int>>();
            subsets.Add(new List<int>());
            int subsetSize = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                int startingIndex = (i >= 1 && nums[i] == nums[i - 1]) ? subsetSize : 0;
                subsetSize = subsets.Count;
                for (int j = startingIndex; j < subsetSize; j++)
                {
                    var currentSubset = new List<int>(subsets[j]);
                    currentSubset.Add(nums[i]);
                    subsets.Add(currentSubset);
                }
            }
            return subsets;
        }

        // Backtracking
        // O(n2^n) time, O(n) space
        public IList<IList<int>> SubsetsWithDupV3(int[] nums)
        {
            Array.Sort(nums);
            var subsets = new List<IList<int>>();
            var currentSubset = new List<int>();
            SubsetsWithDupHelper(subsets, currentSubset, nums, 0);
            return subsets;
        }

        private void SubsetsWithDupHelper(List<IList<int>> subsets, List<int> currentSubset, int[] nums, int index)
        {
            subsets.Add(new List<int>(currentSubset));

            for (int i = index; i < nums.Length; i++)
            {
                if (i != index && nums[i] == nums[i - 1])
                    continue;
                
                currentSubset.Add(nums[i]);
                SubsetsWithDupHelper(subsets, currentSubset, nums, i + 1);
                currentSubset.Remove(currentSubset.Last());
            }
        }
    }
}
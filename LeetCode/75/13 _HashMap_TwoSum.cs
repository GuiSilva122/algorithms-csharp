namespace LeetCode._75
{
    public class HashMap_TwoSUm
    {
        //O(n) space, O(n) time
        public int[] TwoSum(int[] nums, int target)
        {
            var hash = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int potentialMatch = target - nums[i];
                if (hash.ContainsKey(potentialMatch))
                    return new int[] { hash[potentialMatch], i };
                else if (!hash.ContainsKey(nums[i]))
                    hash.Add(nums[i], i);
            }
            return null;
        }
    }
}
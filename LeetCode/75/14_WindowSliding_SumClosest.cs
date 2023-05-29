namespace LeetCode._75
{
    public class WindowSliding_SumClosest
    {
        public static int ThreeSumClosest(int[] nums, int target)
        {
            Array.Sort(nums);
            int closestSum = nums[0] + nums[1] + nums[2];
            int minDifference = Math.Abs(closestSum - target);
            for (int i = 0; i < nums.Length - 2; i++)
            {
                int left = i + 1;
                int right = nums.Length - 1;
                while (left < right)
                {
                    int currentSum = nums[i] + nums[left] + nums[right];
                    int currentDifference = Math.Abs(currentSum - target);
                    if (currentDifference < minDifference)
                    {
                        closestSum = currentSum;
                        minDifference = currentDifference;
                    }
                    if (currentSum < target)
                        left++;
                    else
                        right--;
                }
            }
            return closestSum;
        }

        public static void TestSolution()
        {
            var nums = new int[] { -1, 2, 1, -4 };
            var result = ThreeSumClosest(nums, 1);
        }
    }
}

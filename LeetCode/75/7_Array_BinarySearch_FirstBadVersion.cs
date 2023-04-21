namespace LeetCode._75
{
    public class Array_BinarySearch_FirstBadVersion
    {
        // Only for compilation purposes
        private static bool[] badVersions = new bool[] { false, false, false, true, true, true, true };
        public static bool IsBadVersion(int version) => badVersions[version - 1];
        
        public static int FirstBadVersion(int n)
        {
            int left = 1;
            int right = n;
            while (left < right)
            {
                int pivot = left + (right - left) / 2;
                if (IsBadVersion(pivot))
                    right = pivot;
                else
                    left = pivot + 1;
            }
            return left;
        }

        public static void TestSolution()
        {
            var first = FirstBadVersion(badVersions.Length);
        }
    }
}
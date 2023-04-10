namespace LeetCode.Arrays
{
    public class MergeSortedArray
    {
        public void MergeV1(int[] nums1, int m, int[] nums2, int n)
        {
            for (int i = 0; i < nums1.Length; i++)
                nums1[i + m] = nums2[i];

            Array.Sort(nums1);
        }

        public void MergeV2(int[] nums1, int m, int[] nums2, int n)
        {
            int index1 = m - 1;
            int index2 = n - 1;

            for (int sortedIndex = m + n - 1; sortedIndex >= 0; sortedIndex--)
            {
                if (index2 < 0)
                    break;

                if (index1 >= 0 && nums1[index1] > nums2[index2])
                    nums1[sortedIndex] = nums1[index1--];
                else
                    nums1[sortedIndex] = nums2[index2--];
            }
        }
    }
}
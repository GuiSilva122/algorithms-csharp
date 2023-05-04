namespace LeetCode.Heap
{
    public class KthLargestElementInArray
    {
        // O(n log k) time, O(k) space
        public static int FindKthLargest(int[] nums, int k)
        {
            var minHeap = new PriorityQueue<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                minHeap.Enqueue(nums[i], nums[i]);
                if (minHeap.Count > k)
                    minHeap.Dequeue();
            }
            return minHeap.Dequeue();
        }

        public static void TestSolution()
        {
            int[] nums = new int[] { 3, 2, 1, 5, 6, 4 };
            var result = FindKthLargest(nums, 1);
        }
    }
}

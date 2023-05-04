namespace LeetCode.Heap
{
    public class KthLargestElementInStream
    {
        public class KthLargest
        {
            // Given N as the length of nums and M as the number of calls to add()
            // O(n logn + M log k), O(n)
            private PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();
            private int k = 0;
            public KthLargest(int k, int[] nums)
            {
                this.k = k;
                foreach (var num in nums)
                    minHeap.Enqueue(num, num);

                while (minHeap.Count > k)
                    minHeap.Dequeue();
            }

            public int Add(int val)
            {
                minHeap.Enqueue(val, val);
                if (minHeap.Count > k)
                    minHeap.Dequeue();
                return minHeap.Peek();
            }
        }
    }
}

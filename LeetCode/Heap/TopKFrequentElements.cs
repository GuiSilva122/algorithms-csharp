namespace LeetCode.Heap
{
    public class TopKFrequentElements
    {
        // O(n logk) time, O(n + k) space
        public int[] TopKFrequent(int[] nums, int k)
        {
            var count = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                if (!count.ContainsKey(num)) 
                    count.Add(num, 0);
                
                count[num]++;
            }

            var minHeap = new PriorityQueue<int, int>();
            foreach (var entry in count)
            {
                minHeap.Enqueue(entry.Key, entry.Value);
                if (minHeap.Count > k)
                    minHeap.Dequeue();
            }
            var result = new int[k];
            int i = 0;
            while (minHeap.Count > 0 && i < result.Length)
            {
                result[i] = minHeap.Dequeue();
                i++;
            }
            return result;
        }
    }
}

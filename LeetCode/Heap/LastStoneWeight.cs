namespace LeetCode.Heap
{
    public class LastStoneWeight
    {
        public int GetLastStoneWeight(int[] stones)
        {
            var maxHeap = new PriorityQueue<int, int>(Comparer<int>.Create((x, y) => y - x));
            foreach (var stone in stones)
                maxHeap.Enqueue(stone, stone);

            while (maxHeap.Count > 1)
            {
                var stone1 = maxHeap.Dequeue();
                var stone2 = maxHeap.Dequeue();
                if (stone1 != stone2)
                {
                    var reminder = stone1 - stone2;
                    maxHeap.Enqueue(reminder, reminder);
                }
            }
            return maxHeap.Count > 0 ? maxHeap.Dequeue() : 0;
        }
    }
}

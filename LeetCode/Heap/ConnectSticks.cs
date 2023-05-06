namespace LeetCode.Heap
{
    public class HeapConnectSticks
    {
        // O (n logn) time, space O(n)
        public static int ConnectSticks(int[] sticks)
        {
            if (sticks == null || sticks.Length == 1) return 0;
            var minHeap = new PriorityQueue<int, int>();
            foreach (var stick in sticks)
                minHeap.Enqueue(stick, stick);
            int totalCost = 0;
            while (minHeap.Count > 1)
            {
                var firstStick = minHeap.Dequeue();
                var secondStick = minHeap.Dequeue();
                var result = firstStick + secondStick;
                totalCost += result;
                minHeap.Enqueue(result, result);
            }
            return  totalCost;
        }

        public static void TestSolution()
        {
            var sticks = new int[] { 1, 8, 3, 5 };
            var result = ConnectSticks(sticks);
        }

    }
}

namespace LeetCode.Heap
{
    public class MeetingsRooms
    {
        // O (N log N) time, O(N) space
        public static int MinMeetingRooms(int[][] intervals)
        {
            if (intervals.Length == 0) return 0;
            // Min heap
            var allocatorMinHeap = new PriorityQueue<int, int>(); 
            // Sort the intervals by start time
            Array.Sort(intervals, Comparer<int[]>.Create((x, y) => x[0] - y[0]));
            allocatorMinHeap.Enqueue(intervals[0][1], intervals[0][1]);

            for (int i = 1; i < intervals.Length; i++)
            {
                // If the room due to free up the earliest is free, assign that room to this meeting.
                if (intervals[i][0] >= allocatorMinHeap.Peek())
                    allocatorMinHeap.Dequeue();                
                // If a new room is to be assigned, then also we add to the heap,
                // If an old room is allocated, then also we have to add to the heap with updated end time.
                allocatorMinHeap.Enqueue(intervals[i][1], intervals[i][1]);
            }
            // The size of the heap tells us the minimum rooms required for all the meetings.
            return allocatorMinHeap.Count;
        }

        public int[][] KClosest(int[][] points, int k)
        {
            var maxHeap = new PriorityQueue<int[], double>(Comparer<double>.Create((x, y) => (int)(y - x)));
            foreach (var point in points)
            {
                var distance = Math.Sqrt(point[0] + point[1]);
                maxHeap.Enqueue(point, distance);
                if (maxHeap.Count > k)
                {
                    maxHeap.Dequeue();
                }
            }
            int i = 0;
            int[][] result = new int[k][];
            while (i < k && maxHeap.Count > 0)
            {
                result[i] = maxHeap.Dequeue();
                i++;
            }
            return result;
        }

        public static void TestSolution()
        {
            int[][] intervals = new int[6][]
            {   
                new int[] { 11, 30 },
                new int[] { 10, 20 },
                new int[] { 8, 12 },
                new int[] { 3, 19 },
                new int[] { 2, 7 },
                new int[] { 1, 10 }
            };
            var result = MinMeetingRooms(intervals);
        }
    }
}
namespace LeetCode.Heap
{
    public class KClosestPointsToOrigin
    {
        // O(n logk) time, O(k) space
        public static int[][] KClosest(int[][] points, int k)
        {
            var maxHeap = new PriorityQueue<int[], double>(Comparer<double>.Create((x, y) => y.CompareTo(x)));
            foreach (var point in points)
            {
                var distance = Math.Sqrt(Math.Pow(point[0], 2) + Math.Pow(point[1], 2));
                maxHeap.Enqueue(point, distance);
                if (maxHeap.Count > k)
                    maxHeap.Dequeue();
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
            var points = new int[][]
            {
                new int[] { 3, 3 },
                new int[] { 5, -1 },
                new int[] { -2, 4 }
            };
            int k = 2;
            var result = KClosest(points, k);
        }
    }
}

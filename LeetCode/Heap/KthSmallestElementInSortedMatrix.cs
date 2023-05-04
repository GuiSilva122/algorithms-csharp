namespace LeetCode.Heap
{
    public class KthSmallestElementInSortedMatrix
    {
        private record MyHeapNode(int Row, int Column, int Value) : IComparable<MyHeapNode>
        {
            public int CompareTo(MyHeapNode? other) => Value - other.Value;
        }

        // Given N = matrix.Length, x = min(K,N)
        // O(X + Klog(X)) time, O(X) space
        public static int KthSmallest(int[][] matrix, int k)
        {
            var minHeap = new PriorityQueue<MyHeapNode, MyHeapNode>();
            for (int row = 0; row < Math.Min(matrix.Length, k); row++)
            {
                var heapNode = new MyHeapNode(row, 0, matrix[row][0]);
                minHeap.Enqueue(heapNode, heapNode);
            }
            MyHeapNode element = minHeap.Peek();
            while (k-- > 0)
            {
                element = minHeap.Dequeue();
                int row = element.Row;
                int col = element.Column;

                if (col < matrix.Length - 1)
                {
                    var heapNode = new MyHeapNode(row, col + 1, matrix[row][col + 1]);
                    minHeap.Enqueue(heapNode, heapNode);
                }
            }
            return element.Value;
        }

        public static void TestSolution()
        {
            var matrix = new int[3][]
            {
                new int[] { 1, 3, 7 },
                new int[] { 5, 10, 12 },
                new int[] { 6, 12, 15 }
            };
            int k = 5;
            var result = KthSmallest(matrix, k);
        }
    }
}
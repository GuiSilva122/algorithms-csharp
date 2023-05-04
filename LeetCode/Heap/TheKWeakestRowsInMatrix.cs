namespace LeetCode.Heap
{
    public class TheKWeakestRowsInMatrix
    {
        private static int BinarySearch(int[] row)
        {
            int low = 0;
            int high = row.Length;
            while (low < high)
            {
                int mid = low + (high - low) / 2;
                if (row[mid] == 1)
                    low = mid + 1;
                else
                    high = mid;
            }
            return low;
        }

        public int[] KWeakestRows(int[][] mat, int k)
        {
            int m = mat.Length;
            int n = mat[0].Length;
            var maxHeap = new PriorityQueue<int[], int[]>(Comparer<int[]>.Create((first, second) => {
                if (first[0] == second[0])
                    return second[1] - first[1];
                else
                    return second[0] - first[0];
            }));
            for (int i = 0; i < m; i++)
            {
                int strength = BinarySearch(mat[i]);
                int[] entry = new int[] { strength, i };
                maxHeap.Enqueue(entry, entry);

                if (maxHeap.Count > k)
                    maxHeap.Dequeue();
            }
            int[] indexes = new int[k];
            for (int i = k - 1; i >= 0; i--)
            {
                int[] pair = maxHeap.Dequeue();
                indexes[i] = pair[1];
            }
            return indexes;
        }
    }
}

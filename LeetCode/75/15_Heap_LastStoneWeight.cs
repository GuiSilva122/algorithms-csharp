using System;

namespace LeetCode._75
{
    public class Heap_LastStoneWeight
    {
        // Array-Based Simulation
        // O(n^2) time, O(n) space
        private int RemoveLargest(List<int> stones)
        {
            int indexOfLargest = stones.IndexOf(stones.Max());
            int result = stones[indexOfLargest];
            stones[indexOfLargest] = stones[stones.Count - 1];
            stones.Remove(stones.Count - 1);
            return result;
        }

        public int LastStoneWeightV1(int[] stones)
        {
            var stoneList = new List<int>();
            foreach (int weight in stones)
                stoneList.Add(weight);

            while (stoneList.Count > 1)
            {
                int stone1 = RemoveLargest(stoneList);
                int stone2 = RemoveLargest(stoneList);
                if (stone1 != stone2)
                    stoneList.Add(stone1 - stone2);
            }
            return stoneList.Count > 0 ? stoneList[0] : 0;
        }

        // Sorted Array-Based Simulation
        // O(n^2) time, O(n) space
        public int LastStoneWeightV2(int[] stones)
        {
            var stoneList = new List<int>();
            foreach (int weight in stones)
                stoneList.Add(weight);
            stoneList.Sort();

            while (stoneList.Count > 1)
            {
                int stone1 = stoneList[stoneList.Count - 1];
                stoneList.RemoveAt(stoneList.Count - 1);

                int stone2 = stoneList[stoneList.Count - 1];
                stoneList.RemoveAt(stoneList.Count - 1);

                if (stone1 != stone2)
                {
                    int newStone = stone1 - stone2;
                    int index = stoneList.BinarySearch(newStone);
                    if (index < 0)
                        stoneList.Insert(-index - 1, newStone);
                    else
                        stoneList.Insert(index, newStone);
                }
            }
            return stoneList.Count > 0 ? stoneList[0] : 0;
        }

        // Heap-Based Simulation
        // O(n logn) time, O(n) space
        public static int LastStoneWeightV3(int[] stones)
        {
            var heap = new PriorityQueue<int, int>(Comparer<int>.Create((x, y) => y - x));
            foreach (var stone in stones)
                heap.Enqueue(stone, stone);

            while (heap.Count > 1)
            {
                int stone1 = heap.Dequeue();
                int stone2 = heap.Dequeue();
                if (stone1 != stone2)
                {
                    var current = stone1 - stone2;
                    heap.Enqueue(current, current);
                }
            }
            return heap.Count <= 0 ? 0 : heap.Dequeue();
        }

        private static int BinarySearch(int[] row)
        {
            int low = 0;
            int high = row.Length;
            while (low < high)
            {
                int mid = low + (high - low) / 2;
                if (row[mid] == 1)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid;
                }
            }
            return low;
        }

        public static void TestSolution()
        {
            var stones = new int[] { 2, 7, 4, 1, 8, 1 };
            var result = LastStoneWeightV3(stones);
        }
    }
}
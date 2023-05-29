namespace LeetCode._75
{
    public class Interval_MergeIntervals
    {
        // O(nlogn) time, O(n) space
        public int[][] Merge(int[][] intervals)
        {
            var merged = new List<int[]>();
            Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));
            foreach (var interval in intervals)
            {
                if (merged.Count == 0 || merged.Last()[1] < interval[0])
                    merged.Add(interval);
                else
                    merged.Last()[1] = Math.Max(merged.Last()[1], interval[1]);
            }
            return merged.ToArray();
        }
    }
}

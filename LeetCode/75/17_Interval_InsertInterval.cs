namespace LeetCode._75
{
    public class Interval_InsertInterval
    {
        // O(n) time, O(1) space
        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
            intervals = InsertInterval(intervals, newInterval);
            var answer = new List<int[]>();
            for (int i = 0; i < intervals.Length; i++)
            {
                int[] currInterval = { intervals[i][0], intervals[i][1] };
                while (i < intervals.Length && DoesIntervalsOverlap(currInterval, intervals[i]))
                {
                    currInterval = MergeIntervals(currInterval, intervals[i]);
                    i++;
                }
                i--;
                answer.Add(currInterval);
            }
            return answer.ToArray();
        }
        private int[][] InsertInterval(int[][] intervals, int[] newInterval)
        {
            bool isIntervalInserted = false;
            var list = new List<int[]>(intervals.ToList());
            for (int i = 0; i < intervals.Length; i++)
            {
                if (newInterval[0] < intervals[i][0])
                {
                    list.Insert(i, newInterval);
                    isIntervalInserted = true;
                    break;
                }
            }
            if (!isIntervalInserted)
                list.Add(newInterval);

            return list.ToArray();
        }

        private int[][] InsertIntervalV2(int[][] intervals, int[] newInterval)
        {
            var list = new List<int[]>(intervals.ToList());
            int index = UpperBound(intervals, newInterval);

            if (index != intervals.Length)
                list.Insert(index, newInterval);
            else
                list.Add(newInterval);

            return list.ToArray();
        }
        private int UpperBound(int[][] intervals, int[] newInterval)
        {
            if (intervals.Length == 0)
                return 0;

            int start = 0, end = intervals.Length - 1;
            int ans = intervals.Length;
            while (start <= end)
            {
                int mid = (start + end) / 2;
                // If the start value is greater than the newInterval
                // This could be the position, so store it but keep looking on the left side.
                if (intervals[mid][0] > newInterval[0])
                {
                    ans = mid;
                    end = mid - 1;
                }
                else
                    start = mid + 1;
            }
            return ans;
        }

        private bool DoesIntervalsOverlap(int[] a, int[] b)
            => Math.Min(a[1], b[1]) - Math.Max(a[0], b[0]) >= 0;

        private int[] MergeIntervals(int[] a, int[] b)
        {
            int[] newInterval = { Math.Min(a[0], b[0]), Math.Max(a[1], b[1]) };
            return newInterval;
        }
    }
}

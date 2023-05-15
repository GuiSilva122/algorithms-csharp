namespace LeetCode._75
{
    public class Greedy_TaskScheduler
    {
        public int LeastInterval(char[] tasks, int n)
        {
            int[] frequencies = new int[26];
            foreach (char t in tasks)
                frequencies[t - 'A']++;

            Array.Sort(frequencies);
            int fMax = frequencies[25];
            int idleTime = (fMax - 1) * n;
            for (int i = frequencies.Length - 2; i >= 0 && idleTime > 0; i--)
                idleTime -= Math.Min(fMax - 1, frequencies[i]);
            idleTime = Math.Max(idleTime, 0);
            return idleTime + tasks.Length;
        }
    }
}
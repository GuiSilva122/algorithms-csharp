namespace LeetCode._75
{
    public class ImplementationSimulation_HappyNumber
    {
        // O(logn) time, O(logn) space
        public bool IsHappy(int n)
        {
            var seen = new HashSet<int>();
            while (n != 1 && !seen.Contains(n))
            {
                seen.Add(n);
                n = GetNext(n);
            }
            return n == 1;
        }

        // O(logn) time, O(1) space
        public bool IsHappyV2(int n)
        {
            var slow = n;
            var fast = GetNext(n);
            while (slow != fast && fast != 1)
            {
                slow = GetNext(slow);
                fast = GetNext(GetNext(fast));
            }
            return fast == 1;
        }

        private int GetNext(int n)
        {
            int totalSum = 0;
            while (n > 0)
            {
                int d = n % 10;
                n = n / 10;
                totalSum += d * d;
            }
            return totalSum;
        }
    }
}
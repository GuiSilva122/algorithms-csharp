namespace LeetCode.Graph
{
    public class CheapestFlightWithinKStops
    {
        // Let E be the number of flights and N be number of cities.
        // Time complexity: O((N+E)K)
        // Space complexity: O(N)
        public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k)
        {
            if (src == dst) return 0;
            int[] previous = new int[n];
            int[] current = new int[n];
            for (int i = 0; i < n; i++)
            {
                previous[i] = int.MaxValue;
                current[i] = int.MaxValue;
            }
            previous[src] = 0;
            for (int i = 1; i < k + 2; i++)
            {
                current[src] = 0;
                foreach (int[] flight in flights)
                {
                    int previousFlight = flight[0];
                    int currentFlight = flight[1];
                    int cost = flight[2];

                    if (previous[previousFlight] < int.MaxValue)
                        current[currentFlight] = Math.Min(current[currentFlight], previous[previousFlight] + cost);
                }
                previous = (int[])current.Clone();
            }
            return current[dst] == int.MaxValue ? -1 : current[dst];
        }
    }
}

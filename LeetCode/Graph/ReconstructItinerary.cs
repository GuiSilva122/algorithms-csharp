using System.Linq;

namespace LeetCode.Graph
{
    public class ReconstructItinerary
    {
        // Time Complexity: O(|E|^d), where |E| is the number of total flights and d
        // is the maximum number of flights from an airport.
        // To calculate a loose upper bound for the time complexity,
        // let us consider it as a combination problem where the goal is to construct a sequence of a specific order,
        // i.e. |V_1V_2...V_n|. For each V_i, we could have ddd choices,
        // i.e. at each airport one could have at most d possible destinations.
        // Since the length of the sequence is |E|, the total number of combination would be |E|^d
        // In the worst case, our backtracking algorithm would have to enumerate all possible combinations.

        // Space Complexity: O(|V|+|E|), where |V| is the number of airports and |E| is the number of flights.
        // In the algorithm, we use the graph as well as the visit bitmap,
        // which would require the space of |V| + |E|.
        // Since we applied recursion in the algorithm,
        // which would incur additional memory consumption in the function call stack.
        // The maximum depth of the recursion would be exactly the number of flights in the input, i.e. |E|.
        // As a result, the total space complexity of the algorithm would be O(|V|+2|E|) = O(|V|+|E|)
        public IList<string> FindItinerary(IList<IList<string>> tickets)
        {
            var flightMap = new Dictionary<string, List<string>>();
            var visitBitmap = new Dictionary<string, bool[]>();
            List<string>? result = null;

            // Step 1). build the graph first
            foreach (List<string> ticket in tickets)
            {
                var (origin, destination) = (ticket[0], ticket[1]);
                if (flightMap.ContainsKey(origin))
                    flightMap[origin].Add(destination);
                else
                    flightMap.Add(origin, new List<string> { destination });
            }
            // Step 2). order the destinations and init the visit bitmap
            foreach (var entry in flightMap)
            {
                entry.Value.Sort();
                visitBitmap.Add(entry.Key, new bool[entry.Value.Count]);
            }
            // Step 3). backtracking
            Backtracking(flightMap, visitBitmap, result, "JFK", new List<string> { "JFK" }, tickets.Count);
            return result!;
        }
        protected bool Backtracking(Dictionary<string, List<string>> flightMap, Dictionary<string, bool[]> visitBitmap, 
                                    List<string>? result, string origin, List<string> route, int flights)
        {
            if (route.Count == flights + 1)
            {
                result = new List<string>(route);
                return true;
            }
            if (!flightMap.ContainsKey(origin))
                return false;
            int i = 0;
            bool[] bitmap = visitBitmap[origin];
            foreach (string destination in flightMap[origin])
            {
                if (!bitmap[i])
                {
                    bitmap[i] = true;
                    route.Add(destination);
                    var backtrackingResult = Backtracking(flightMap, visitBitmap, result, destination, route, flights);
                    route.RemoveAt(route.Count - 1);
                    bitmap[i] = false;
                    if (backtrackingResult)
                        return true;
                }
                i++;
            }
            return false;
        }


        public IList<string> FindItineraryV2(IList<IList<string>> tickets)
        {
            var flightMap = new Dictionary<string, List<string>>();
            var result = new List<string>();
            // Step 1). build the graph first
            foreach (List<string> ticket in tickets)
            {
                var (origin, destination) = (ticket[0], ticket[1]);
                if (flightMap.ContainsKey(origin))
                    flightMap[origin].Add(destination);
                else
                    flightMap.Add(origin, new List<string> { destination });
            }
            // Step 2). order the destinations
            foreach (var flightEntry in flightMap)
                flightEntry.Value.Sort();

            Dfs(flightMap, result, "JFK");

            return result;
        }

        protected void Dfs(Dictionary<string, List<string>> flightMap, List<string> result, string origin)
        {
            // Visit all the outgoing edges first.
            if (flightMap.ContainsKey(origin))
            {
                var destinationList = flightMap[origin];
                while (destinationList.Count > 0)
                {
                    // while we visit the edge, we trim it off from graph.
                    string destination = destinationList.First();
                    destinationList.RemoveAt(0);
                    Dfs(flightMap, result, destination);
                }
            }
            // add the airport to the head of the itinerary
            result.Insert(0, origin);
        }
    }
}
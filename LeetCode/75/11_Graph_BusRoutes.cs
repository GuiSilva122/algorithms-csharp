using System.Drawing;

namespace LeetCode._75
{
    public class Graph_BusRoutes
    {
        public int NumBusesToDestination(int[][] routes, int source, int target)
        {
            if (source == target) 
                return 0;
            int N = routes.Length;

            var graph = new List<List<int>>();
            for (int i = 0; i < N; ++i)
            {   
                Array.Sort(routes[i]);
                graph.Add(new List<int>());
            }
            var seen = new HashSet<int>();
            var targets = new HashSet<int>();
            var queue = new Queue<Point>();
            // Build the graph. Two buses are connected if they share at least one bus stop.
            for (int i = 0; i < N; ++i)
            {
                for (int j = i + 1; j < N; ++j)
                {
                    if (Intersect(routes[i], routes[j]))
                    {
                        graph[i].Add(j);
                        graph[j].Add(i);
                    }
                }   
            }
            // Initialize seen, queue, targets.
            // seen represents whether a node has ever been enqueued to queue.
            // queue handles our breadth first search.
            // targets is the set of goal states we have.
            for (int i = 0; i < N; i++)
            {
                if (Array.BinarySearch(routes[i], source) >= 0)
                {
                    seen.Add(i);
                    queue.Enqueue(new Point(i, 0));
                }
                if (Array.BinarySearch(routes[i], target) >= 0)
                    targets.Add(i);
            }
            while (queue.Count > 0)
            {
                var info = queue.Dequeue();
                int node = info.X, depth = info.Y;
                if (targets.Contains(node))
                    return depth + 1;
                foreach (var nei in graph[node])
                {
                    if (!seen.Contains(nei))
                    {
                        seen.Add(nei);
                        queue.Enqueue(new Point(nei, depth + 1));
                    }
                }
            }
            return -1;
        }

        public bool Intersect(int[] A, int[] B)
        {
            int i = 0, j = 0;
            while (i < A.Length && j < B.Length)
            {
                if (A[i] == B[j]) 
                    return true;
                if (A[i] < B[j]) 
                    i++;
                else 
                    j++;
            }
            return false;
        }
    }
}

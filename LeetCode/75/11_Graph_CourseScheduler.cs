namespace LeetCode._75
{
    // Time Complexity: O(V+E), where V represents the number of vertices and E represents the number of edges.
    // Essentially we iterate through each node and each vertex in the graph once and only once.
    // Space Complexity: O(V+E)
    public class Graph_CourseScheduler
    {
        static int WHITE = 1;
        static int GRAY = 2;
        static int BLACK = 3;

        bool isPossible;
        Dictionary<int, int> color;
        Dictionary<int, List<int>> adjList;
        List<int> topologicalOrder;

        private void Init(int numCourses)
        {
            isPossible = true;
            color = new Dictionary<int, int>();
            adjList = new Dictionary<int, List<int>>();
            topologicalOrder = new List<int>();

            for (int i = 0; i < numCourses; i++)
                color.Add(i, WHITE);
        }

        public int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            Init(numCourses);

            for (int i = 0; i < prerequisites.Length; i++)
            {
                int dest = prerequisites[i][0];
                int src = prerequisites[i][1];
                List<int> lst = adjList.GetValueOrDefault(src, new List<int>());
                lst.Add(dest);
                adjList[src] = lst;
            }

            for (int i = 0; i < numCourses; i++)
            {
                if (color[i] == WHITE)
                    Dfs(i);
            }

            int[] order;
            if (isPossible)
            {
                order = new int[numCourses];
                for (int i = 0; i < numCourses; i++)
                    order[i] = topologicalOrder[numCourses - i - 1];
            }
            else
                order = new int[0];

            return order;
        }

        private void Dfs(int node)
        {
            // Don't recurse further if we found a cycle already
            if (!isPossible)
                return;
            // Start the recursion (Visiting)
            color[node] = GRAY;
            // Traverse on neighboring vertices
            foreach (int neighbor in adjList.GetValueOrDefault(node, new List<int>()))
            {
                if (color[neighbor] == WHITE)
                    Dfs(neighbor);
                else if (color[neighbor] == GRAY)
                    // An edge to a GRAY vertex represents a cycle
                    isPossible = false; 
            }
            // Recursion ends. We mark it as black
            color[node] = BLACK;
            topologicalOrder.Add(node);
        }

        public int[] FindOrderV2(int numCourses, int[][] prerequisites)
        {
            bool isPossible = true;
            var adjList = new Dictionary<int, List<int>>();
            int[] indegree = new int[numCourses];
            int[] topologicalOrder = new int[numCourses];
            // Create the adjacency list representation of the graph
            for (int i = 0; i < prerequisites.Length; i++)
            {
                int dest = prerequisites[i][0];
                int src = prerequisites[i][1];
                List<int> lst = adjList.GetValueOrDefault(src, new List<int>());
                lst.Add(dest);
                adjList[src] = lst;
                // Record in-degree of each vertex
                indegree[dest] += 1;
            }
            // Add all vertices with 0 in-degree to the queue
            var q = new Queue<int>();
            for (int i = 0; i < numCourses; i++)
            {
                if (indegree[i] == 0)
                    q.Enqueue(i);
            }

            int index = 0;
            // Process until the Q becomes empty
            while (q.Count > 0)
            {
                int node = q.Dequeue();
                topologicalOrder[index++] = node;
                // Reduce the in-degree of each neighbor by 1
                if (adjList.ContainsKey(node))
                {
                    foreach (int neighbor in adjList[node])
                    {
                        indegree[neighbor]--;
                        // If in-degree of a neighbor becomes 0, add it to the Q
                        if (indegree[neighbor] == 0)
                            q.Enqueue(neighbor);
                    }
                }
            }
            // Check to see if topological sort is possible or not.
            if (index == numCourses)
                return topologicalOrder;
            return new int[0];
        }
    }
}
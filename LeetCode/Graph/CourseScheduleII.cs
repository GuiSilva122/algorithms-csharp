namespace LeetCode.Graph
{
    public class CourseScheduleII
    {
        public static int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            var adjList = new Dictionary<int, List<int>>();
            int[] indegree = new int[numCourses];

            foreach (var prerequisite in prerequisites)
            {
                if (!adjList.ContainsKey(prerequisite[1]))
                    adjList.Add(prerequisite[1], new List<int>());
                adjList[prerequisite[1]].Add(prerequisite[0]);
                indegree[prerequisite[0]]++;
            }
            var queue = new Queue<int>();
            for (int i = 0; i < indegree.Length; i++)
            {
                if (indegree[i] == 0)
                    queue.Enqueue(i);
            }
            int[] topologicalOrder = new int[numCourses];
            int index = 0;
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                topologicalOrder[index++] = current;
                if (adjList.ContainsKey(current))
                {
                    foreach (int to in adjList[current])
                    {
                        indegree[to]--;
                        if (indegree[to] == 0)
                            queue.Enqueue(to);
                    }
                }
            }
            return topologicalOrder;
        }

        public static void TestSolution()
        {
            int numCourses = 4;
            var prerequisites = new int[][] 
            { 
                new int[] { 1, 0 }, 
                new int[] { 2, 0 }, 
                new int[] { 3, 1 }, 
                new int[] { 3, 2 } 
            };
            var result = FindOrder(numCourses, prerequisites);
        }
    }
}
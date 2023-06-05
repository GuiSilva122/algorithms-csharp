namespace LeetCode.Graph
{
    public class EvaluateDivision
    {
        // intuition
        // a/b = 2, b/c = 3
        // b/a = 1/2, c/b = 1/3
        // a/c = (a/b)*(b/c) = 2*3 = 6
        
        // Let N be the number of input equations and M be the number of queries.
        
        // Time Complexity: O(MN)
            // Building the graph takes O(N)
            // For each query, we need to traverse the graph which takes O(N) to verse and will be done M times, hence O(MN).

        //Space Complexity: O(N)
            // We build a graph out the equations. In the worst case where there is no overlapping among the equations,
            // we would have N edges and 2N nodes in the graph.
            // Therefore, the sapce complexity of the graph is O(N+2N)= O(3N) = O(N).

            // Since we employ the recursion in the backtracking, the call stack will take O(N) space.
            // In addition, we used a set visited to keep track of the nodes we visited during the backtracking.
            // The space complexity of the visited set would be O(N).
        public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
        {
            var graph = new Dictionary<string, Dictionary<string, double>>();
            for (int i = 0; i < equations.Count; i++)
            {
                string dividend = equations[i][0];
                string divisor = equations[i][1];
                double quotient = values[i];
                if (!graph.ContainsKey(dividend))
                    graph.Add(dividend, new Dictionary<string, double>());
                if (!graph.ContainsKey(divisor))
                    graph.Add(divisor, new Dictionary<string, double>());
                graph[dividend].Add(divisor, quotient); // (a / b) = values[i]
                graph[divisor].Add(dividend, 1 / quotient); // (b / a) = (1 / values[i])
            }
            var results = new double[queries.Count];
            for (int i = 0; i < queries.Count; i++)
            {
                var query = queries[i];
                string dividend = query[0];
                string divisor = query[1];
                if (!graph.ContainsKey(dividend) || !graph.ContainsKey(divisor))
                    results[i] = -1.0;
                else if (dividend == divisor)
                    results[i] = 1.0;
                else
                {
                    var visited = new HashSet<string>();
                    results[i] = BacktrackEvaluate(graph, visited, dividend, divisor, 1);
                }
            }
            return results;
        }
        private double BacktrackEvaluate(Dictionary<string, Dictionary<string, double>> graph, HashSet<string> visited,
                                         string currentNode, string targetNode, double accProduct)
        {
            visited.Add(currentNode);
            double ret = -1.0;
            var neighbors = graph[currentNode];
            if (neighbors.ContainsKey(targetNode))
                ret = accProduct * neighbors[targetNode];
            else
            {
                foreach (var pair in neighbors)
                {
                    string nextNode = pair.Key;
                    if (visited.Contains(nextNode))
                        continue;
                    ret = BacktrackEvaluate(graph, visited, nextNode, targetNode, accProduct * pair.Value);
                    if (ret != -1.0)
                        break;
                }
            }
            visited.Remove(currentNode);
            return ret;
        }

        // Statement: If M operations, either Union or Find, are applied to N elements, the total run time is O(Mlog⁡N),
        // when we perform unions arbitrarily instead of by size or rank.
        // The maximum number of elements in the Union-Find data structure is equal to twice of the number of equations,
        // each equation introduces two new variables.

        //  Let N be the number of input equations and M be the number of queries.

        // Time Complexity: O((M + N)log⁡N)
        // First of all, we iterate through each input equation and invoke union() upon it.
        // As a result, the overall time complexity of this step is O(Nlog⁡N)
        // As the second step, we then evaluate the query one by one.
        // For each evaluation, we invoke the find() function at most twice.
        // Therefore, the overall time complexity of this step is O(Mlog⁡N)

        // Space Complexity: O(N)
        public static double[] CalcEquationV2(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
        {
            var gidWeight = new Dictionary<string, (string, double)>();
            for (int i = 0; i < equations.Count; i++)
            {
                var equation = equations[i];
                string dividend = equation[0];
                string divisor = equation[1];
                double quotient = values[i];
                Union(gidWeight, dividend, divisor, quotient);
            }
            double[] results = new double[queries.Count];
            for (int i = 0; i < queries.Count; i++)
            {
                var query = queries[i];
                string dividend = query[0];
                string divisor = query[1];

                if (!gidWeight.ContainsKey(dividend) || !gidWeight.ContainsKey(divisor))
                    results[i] = -1.0;
                else
                {
                    var (dividendGid, dividendWeight) = Find(gidWeight, dividend);
                    var (divisorGid, divisorWeight) = Find(gidWeight, divisor);

                    if (!dividendGid.Equals(divisorGid))
                        results[i] = -1.0;
                    else
                        results[i] = dividendWeight / divisorWeight;
                }
            }
            return results;
        }

        private static (string, double) Find(Dictionary<string, (string, double)> gidWeight, string nodeId)
        {
            if (!gidWeight.ContainsKey(nodeId))
                gidWeight.Add(nodeId, (nodeId, 1.0));

            var (parentNode, weight) = gidWeight[nodeId];
            if (!parentNode.Equals(nodeId))
            {
                var (newParent, newWeight) = Find(gidWeight, parentNode);
                if (!gidWeight.ContainsKey(nodeId))
                    gidWeight.Add(nodeId, (newParent, weight * newWeight));
                else
                    gidWeight[nodeId] = (newParent, weight * newWeight);
            }
            return gidWeight[nodeId];
        }

        private static void Union(Dictionary<string, (string, double)> gidWeight, string dividend, string divisor, double value)
        {
            var (dividendGid, dividendWeight) = Find(gidWeight, dividend);
            var (divisorGid, divisorWeight) = Find(gidWeight, divisor);

            if (!dividendGid.Equals(divisorGid))
            {
                if (!gidWeight.ContainsKey(dividendGid))
                    gidWeight.Add(dividendGid, (divisorGid, divisorWeight * value / dividendWeight));
                else
                    gidWeight[dividendGid] = (divisorGid, divisorWeight * value / dividendWeight);
            }
        }

        public static void TestSolution()
        {
            var equations = new List<IList<string>>
            {
                new List<string> { "a", "b" },
                new List<string> { "b", "c" }
            };
            var queries = new List<IList<string>>
            {
                new List<string> { "a", "c" },
                new List<string> { "b", "a" },
                new List<string> { "a", "e" },
                new List<string> { "a", "a" },
                new List<string> { "x", "x" }
            };
            double[] values = new double[] { 2.0, 3.0 };
            var result = CalcEquationV2(equations, values, queries);
        }
    }
}

using CrackingTheCodeInterview.TreesAndGraphs.Helper;
using System;
using System.Collections.Generic;

namespace CrackingTheCodeInterview.TreesAndGraphs
{
    public class RoutesBetweenNodes
    {
        public static bool Search(Graph g, Node start, Node end)
        {   
            foreach (var node in g.GetNodes()) node.state = NodeState.Unvisited;
            start.state = NodeState.Visiting;

            var visitingNodes = new LinkedList<Node>();
            visitingNodes.AddLast(start);

            while (visitingNodes.Count > 0)
            {
                Node currentNode = visitingNodes.First.Value;
                visitingNodes.RemoveFirst();

                if (currentNode != null)
                {
                    foreach (var currentAdjacentNode in currentNode.GetAdjacent())
                    {
                        if (currentAdjacentNode.state == NodeState.Unvisited)
                        {
                            if (currentAdjacentNode == end)
                                return true;
                            else
                            {
                                currentAdjacentNode.state = NodeState.Visiting;
                                visitingNodes.AddLast(currentAdjacentNode);
                            }
                        }
                    }
                    currentNode.state = NodeState.Visited;
                }
            }

            return false;
        }

        public static void TestSolution()
        {
            Graph g = CreateNewGraph();
            Node[] n = g.GetNodes();
            Node start = n[3];
            Node end = n[5];
            Console.WriteLine(Search(g, start, end));

            start = n[5];
            end = n[2];
            Console.WriteLine(Search(g, start, end));
        }

        private static Graph CreateNewGraph()
        {
            var g = new Graph();            
            var temp = new Node[6];

            temp[0] = new Node("a", 3);
            temp[1] = new Node("b", 0);
            temp[2] = new Node("c", 0);
            temp[3] = new Node("d", 1);
            temp[4] = new Node("e", 1);
            temp[5] = new Node("f", 0);

            temp[0].AddAdjacent(temp[1]);
            temp[0].AddAdjacent(temp[2]);
            temp[0].AddAdjacent(temp[3]);
            temp[3].AddAdjacent(temp[4]);
            temp[4].AddAdjacent(temp[5]);
            
            for (int i = 0; i < 6; i++)
                g.AddNode(temp[i]);

            return g;
        }
    }
}
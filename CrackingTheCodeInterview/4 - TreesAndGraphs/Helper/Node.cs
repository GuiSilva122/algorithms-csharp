using System;

namespace CrackingTheCodeInterview.TreesAndGraphs.Helper
{
    public class Node
    {
        private Node[] adjacent;
        public int adjacentCount;
        private string vertex;
        public NodeState state;

        public Node(string vertex, int adjacentLength)
        {
            this.vertex = vertex;
            adjacentCount = 0;
            adjacent = new Node[adjacentLength];
        }

        public void AddAdjacent(Node x)
        {
            if (adjacentCount < adjacent.Length)
            {
                this.adjacent[adjacentCount] = x;
                adjacentCount++;
            }
            else
                Console.WriteLine("No more adjacent can be added");
        }

        public Node[] GetAdjacent() => adjacent;

        public string getVertex() => vertex;
    }
}
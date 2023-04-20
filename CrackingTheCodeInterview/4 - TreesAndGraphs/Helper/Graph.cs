using System;

namespace CrackingTheCodeInterview.TreesAndGraphs.Helper
{
    public class Graph
    {
        public static int MAX_VERTICES = 6;
        private Node[] vertices;
        public int count;

        public Graph()
        {
            vertices = new Node[MAX_VERTICES];
            count = 0;
        }

        public void AddNode(Node x)
        {
            if (count < vertices.Length)
            {
                vertices[count] = x;
                count++;
            }
            else
                Console.WriteLine("Graph full");
        }

        public Node[] GetNodes() => vertices;
    }
}

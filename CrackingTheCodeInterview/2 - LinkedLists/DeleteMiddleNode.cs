using CrackingTheCodeInterview.LinkedLists.Helpers;
using System;
namespace CrackingTheCodeInterview.LinkedLists
{
    public class DeleteMiddleNode
    {
        public static bool DeleteNode(LinkedListNode node)
        {
            if (node == null || node.next == null)
                return false;

            var next = node.next;
            node.data = next.data;
            node.next = next.next;
            return true;
        }

        public static void TestSolution()
        {
            LinkedListNode head = LinkedListHelper.RandomLinkedList(10, 0, 10);
            Console.WriteLine(head.PrintForward());
            DeleteNode(head.next.next.next.next); // delete node 4
            Console.WriteLine(head.PrintForward());
        }
    }
}

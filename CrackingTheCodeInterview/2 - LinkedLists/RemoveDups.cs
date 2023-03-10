using CrackingTheCodeInterview.LinkedLists.Helpers;
using System;
using System.Collections.Generic;

namespace CrackingTheCodeInterview.LinkedLists
{
    internal class RemoveDups
    {
        // O(n) time, O(n) space
        public static void DeleteDupsV1(LinkedListNode linkedList)
        {
            var values = new HashSet<int>();
            LinkedListNode previous = null;
            while (linkedList != null)
            {
                if (values.Contains(linkedList.data))
                    previous.next = linkedList.next;
                else
                {
                    values.Add(linkedList.data);
                    previous = linkedList;
                }
                linkedList = linkedList.next;
            }
        }

        // O(n) time, O(1) space
        public static void DeleteDupsV2(LinkedListNode linkedList)
        {
            var current = linkedList;
            while (current != null)
            {
                var runner = current;
                while (runner.next != null)
                {
                    if (current.data == runner.next.data)
                        runner.next = runner.next.next;
                    else
                        runner = runner.next;
                }
                current = current.next;
            }
        }

        public static void DeleteDupsV3(LinkedListNode linkedList)
        {
            var current = linkedList;
            while (current != null)
            {
                var nextDistinctNode = current.next;
                while (nextDistinctNode != null && current.data == nextDistinctNode.data)
                    nextDistinctNode = nextDistinctNode.next;

                current.next = nextDistinctNode;
                current = nextDistinctNode;
            }
        }

        public static void TestSolution()
        {
            var first = new LinkedListNode(0, null, null);
            LinkedListNode head = first;
            LinkedListNode second = first;
            for (int i = 1; i < 8; i++)
            {
                second = new LinkedListNode(i % 2, null, null);
                first.SetNext(second);
                second.SetPrevious(first);
                first = second;
            }
            Console.WriteLine(head.PrintForward());
            DeleteDupsV2(head);
            Console.WriteLine(head.PrintForward());
        }
    }
}

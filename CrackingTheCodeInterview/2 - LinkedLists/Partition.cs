using CrackingTheCodeInterview.LinkedLists.Helpers;
using System;

namespace CrackingTheCodeInterview.LinkedLists
{
    public class Partition
    {
        public static LinkedListNode PartitionBy(LinkedListNode node, int partition)
        {
            LinkedListNode beforeStart = null;
            LinkedListNode beforeEnd = null;
            LinkedListNode afterStart = null;
            LinkedListNode afterEnd = null;

            while (node != null)
            {
                var next = node.next;
                node.next = null;
                if (node.data < partition)
                {
                    if (beforeStart == null)
                    {
                        beforeStart = node;
                        beforeEnd = beforeStart;
                    }
                    else
                    {
                        beforeEnd.next = node;
                        beforeEnd = node;
                    }
                }
                else
                {
                    if (afterStart == null)
                    {
                        afterStart = node;
                        afterEnd = afterStart;
                    }
                    else
                    {
                        afterEnd.next = node;
                        afterEnd = node;
                    }
                }
                node = next;
            }
            if (beforeStart == null)
                return afterStart;

            beforeEnd.next = afterStart;
            return beforeStart;
        }

        public static void TestSolution()
        {
            int[] vals = { 10, 12, 20, 25, 26, 1, 2, 3, 4 };
            var head = new LinkedListNode(vals[0], null, null);
            var current = head;
            for (int i = 1; i < vals.Length; i++)
            {
                current = new LinkedListNode(vals[i], null, current);
            }
            Console.WriteLine(head.PrintForward());

            LinkedListNode h = PartitionBy(head, 5);

            Console.WriteLine(h.PrintForward());
        }
    }
}

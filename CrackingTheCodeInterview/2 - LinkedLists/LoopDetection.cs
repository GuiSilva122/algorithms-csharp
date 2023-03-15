using CrackingTheCodeInterview.LinkedLists.Helpers;
using System;

namespace CrackingTheCodeInterview.LinkedLists
{
    public class LoopDetection
    {
        public static LinkedListNode Detect(LinkedListNode head)
        {
            var slow = head;
            var fast = head;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if (slow == fast)
                    break;
            }
            if (fast == null || fast.next == null)
                return null;

            slow = head;
            while (slow != fast)
            {
                slow = slow.next;
                fast = fast.next;
            }
            return fast;
        }

        public static void TestSolution()
        {
            int list_length = 100;
            int k = 10;
            var nodes = new LinkedListNode[list_length];
            for (int i = 0; i < list_length; i++)
                nodes[i] = new LinkedListNode(i, null, i > 0 ? nodes[i - 1] : null);
            
            // Create loop;
            nodes[list_length - 1].next = nodes[list_length - k];

            LinkedListNode loop = Detect(nodes[0]);
            Console.WriteLine($"{(loop == null ? "No Cycle." : loop.data) }");
        }
    }
}

































//var slow = head;
//var fast = head;
//while (fast != null && fast.next != null)
//{
//    slow = slow.next;
//    fast = fast.next.next;
//    if (slow == fast)
//        break;
//}
//if (fast != null && fast.next != null)
//    return null;

//slow = head;
//while (slow != fast)
//{
//    slow = slow.next;
//    fast = fast.next;
//}
//return fast;
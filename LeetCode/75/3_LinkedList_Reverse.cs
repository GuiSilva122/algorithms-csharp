using LeetCode._75.Helper;

namespace LeetCode._75
{
    public  class LinkedList_Reverse
    {
        // O(n) time, O(1) space
        public static ListNode Reverse(ListNode head)
        {
            ListNode prev = null;
            var current = head;
            while (current != null)
            {
                var temNext = current.next;
                current.next = prev;
                prev = current;
                current = temNext;
            }
            return prev;
        }

        // O(n) time, O(n) space
        public static ListNode ReverseV2(ListNode head)
        {
            if (head == null || head.next == null)
                return head;

            var p = ReverseV2(head.next);
            head.next.next = head;
            head.next = null;
            return p;
        }

        public static void TestSolution()
        {
            var head = new ListNode(1, new(2, new(3, new(4, new(5)))));
            Console.WriteLine(head.PrintForward());

            var reversed = ReverseV2(head);
            Console.WriteLine(reversed.PrintForward());
        }
    }
}
using LeetCode._75.Helper;

namespace LeetCode.LinkedList
{
    public class RemoveDuplicatesfromSortedListII
    {
        public static ListNode DeleteDuplicates(ListNode head)
        {
            var current = head;
            var dummy = new ListNode(-1, head);
            var prev = dummy;
            while (current != null)
            {
                if (current.next != null && current.val == current.next.val)
                {
                    while (current.next != null && current.val == current.next.val)
                        current = current.next;
                    
                    prev.next = current.next;
                    current = current.next;
                }
                else
                {
                    prev = current;
                    current = current.next;
                }
            }
            return dummy.next;
        }

        public static void TestSolution()
        {
            var head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(3, new ListNode(4, new ListNode(4, new ListNode(5)))))));
            head = DeleteDuplicates(head);
        }
    }
}

using LeetCode._75.Helper;

namespace LeetCode.LinkedList
{
    public class ReverseLinkedListII
    {
        public ListNode ReverseBetween(ListNode head, int left, int right)
        {
            var dummy = new ListNode(0, head);
            var (leftPrev, current) = (dummy, head);
            for (int i = 0; i < left - 1; i++)
                (leftPrev, current) = (current, current.next);

            ListNode? prev = null;
            for (int i = 0; i < ((right - left) + 1); i++)
            {
                var tempNext = current.next;
                current.next = prev!;
                (prev, current) = (current, tempNext);
            }
            leftPrev.next.next = current;
            leftPrev.next = prev!;
            return dummy.next;
        }
    }
}
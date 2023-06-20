using LeetCode._75.Helper;

namespace LeetCode.LinkedList
{
    public class SawpNodesInPairs
    {
        public ListNode SwapPairs(ListNode head)
        {
            var dummy = new ListNode(0, head);
            var (prev, current) = (dummy, head);
            while (current != null && current.next != null)
            {
                var nextPair = current.next.next;
                var second = current.next;

                second.next = current;
                current.next = nextPair;
                prev.next = second;

                prev = current;
                current = nextPair;
            }
            return dummy.next;
        }
    }
}
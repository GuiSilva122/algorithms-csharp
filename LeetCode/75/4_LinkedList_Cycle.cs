using LeetCode._75.Helper;

namespace LeetCode._75
{
    public class LinkedList_Cycle
    {
        public ListNode DetectCycle(ListNode head)
        {
            var slow = head;
            var fast = head;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if (fast == slow)
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
            return slow;
        }
    }
}

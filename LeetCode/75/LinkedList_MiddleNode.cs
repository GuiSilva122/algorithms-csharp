using LeetCode._75.Helper;

namespace LeetCode._75
{
    public  class LinkedList_MiddleNode
    {
        public ListNode MiddleNode(ListNode head)
        {
            var slow = head;
            var fast = head;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }
            return slow;
        }
    }
}

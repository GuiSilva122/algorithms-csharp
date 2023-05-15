using LeetCode._75.Helper;

namespace LeetCode._75
{
    public class LinkedList_OddEvenLinkedList
    {
        public ListNode OddEvenList(ListNode head)
        {
            if (head == null)
                return null;
            var odd = head;
            var even = head.next;
            var evenHead = even;
            while (even != null && even.next != null)
            {
                odd.next = even.next;
                odd = odd.next;
                even.next = odd.next;
                even = even.next;
            }
            odd.next = evenHead;
            return head;
        }
    }
}
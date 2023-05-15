using LeetCode._75.Helper;

namespace LeetCode._75
{
    public class LinkedList_SortLinkedList
    {
        public ListNode SortList(ListNode head)
        {
            if (head == null || head.next == null)
                return head;
            var mid = GetMid(head);
            var left = SortList(head);
            var right = SortList(mid);
            return Merge(left, right);
        }

        private ListNode Merge(ListNode list1, ListNode list2)
        {
            var dummyHead = new ListNode();
            var tail = dummyHead;
            while (list1 != null && list2 != null)
            {
                if (list1.val < list2.val)
                {
                    tail.next = list1;
                    list1 = list1.next;
                }
                else
                {
                    tail.next = list2;
                    list2 = list2.next;
                }
                tail = tail.next;
            }
            tail.next = (list1 != null) ? list1 : list2;
            return dummyHead.next;
        }

        private ListNode GetMid(ListNode head)
        {
            ListNode midPrev = null;
            while (head != null && head.next != null)
            {
                midPrev = (midPrev == null) ? head : midPrev.next;
                head = head.next.next;
            }
            ListNode mid = midPrev.next;
            midPrev.next = null;
            return mid;
        }
    }
}
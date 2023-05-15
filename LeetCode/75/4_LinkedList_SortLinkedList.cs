using LeetCode._75.Helper;

namespace LeetCode._75
{
    public class LinkedList_SortLinkedList
    {
        public static ListNode SortList(ListNode head)
        {
            if (head == null || head.next == null)
                return head;
            var mid = GetMid(head);
            var left = SortList(head);
            var right = SortList(mid);
            return Merge(left, right);
        }

        private static ListNode Merge(ListNode list1, ListNode list2)
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

        private static ListNode GetMid(ListNode head)
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

        public static void TestSolution()
        {
            // -1 -> 5 -> 3 -> 4 -> 0
            ListNode head = new ListNode(-1, new ListNode(5, new ListNode(3, new ListNode(4, new ListNode(0)))));
            var sorted = SortList(head);
        }
    }
}
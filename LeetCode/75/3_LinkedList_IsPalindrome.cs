using LeetCode._75.Helper;

namespace LeetCode._75
{
    public class LinkedList_IsPalindrome
    {
        // O(n) time, O(1) space
        public bool IsPalindrome(ListNode head)
        {
            if (head == null)
                return true;
            ListNode firstHalfEnd = GetListMiddleNode(head);
            ListNode secondHalfStart = ReverseList(firstHalfEnd.next);
            ListNode p1 = head;
            ListNode p2 = secondHalfStart;
            var result = true;
            while (result && p2 != null)
            {
                if (p1.val != p2.val) result = false;
                p1 = p1.next;
                p2 = p2.next;
            }
            firstHalfEnd.next = ReverseList(secondHalfStart);
            return result;
        }

        private ListNode GetListMiddleNode(ListNode head)
        {
            var fast = head;
            var slow = head;
            while (fast.next != null && fast.next.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
            }
            return slow;
        }

        private ListNode ReverseList(ListNode head)
        {
            ListNode prev = null;
            var current = head;
            while (current != null)
            {
                var nextTemp = current.next;
                current.next = prev;
                prev = current;
                current = nextTemp;
            }
            return prev;
        }
    }
}
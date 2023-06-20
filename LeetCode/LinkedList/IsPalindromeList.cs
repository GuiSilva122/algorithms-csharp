using LeetCode._75.Helper;

namespace LeetCode.LinkedList
{
    public class IsPalindromeList
    {
        private static ListNode frontNode;
        public static bool IsPalindromeV1(ListNode head)
        {
            frontNode = head;
            return IsPalindromeHelper(head);
        }
        private static bool IsPalindromeHelper(ListNode node)
        {
            if (node != null)
            {
                if (!IsPalindromeHelper(node.next)) return false;
                if (node.val != frontNode.val) return false;
                frontNode = frontNode.next;
            }
            return true;
        }

        public static bool IsPalindrome(ListNode head)
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

        private static ListNode GetListMiddleNode(ListNode head)
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

        private static ListNode ReverseList(ListNode head)
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

        public static void TestSolution()
        {
            var head = new ListNode(1, new ListNode(2, new ListNode(2, new ListNode(1))));
            var result = IsPalindrome(head);
        }
    }
}
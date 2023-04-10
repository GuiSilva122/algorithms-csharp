namespace LeetCode.LinkedList
{
    internal class PalindromeSingleLinkedList
    {
        public class ListNode
        {
            public int val;
            public ListNode? next;
            public ListNode(int val = 0, ListNode? next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        //V1 O(n), O(n)
        public static bool IsPalindrome(ListNode head)
        {
            var values = new List<int>();
            var node = head;
            int listLength = 0;
            while (node != null)
            {
                values.Add(node.val);
                node = node.next;
                listLength++;
            }

            int init = 0;
            int end = values.Count - 1;
            while (init < end)
            {
                if (values[init] == values[end])
                {
                    init++;
                    end--;
                }
                else
                    return false;
            }
            return true;
        }

        // O(n) time, O(1) space
        private static ListNode frontNode;
        private static bool IsPalindromeRecursive(ListNode node)
        {
            if (node != null)
            {
                if (!IsPalindromeRecursive(node.next)) return false;
                if (node.val != frontNode.val) return false;
                frontNode = frontNode.next;
            }
            return true;
        }
        public static bool IsPalindromeV2(ListNode head)
        {
            frontNode = head;
            return IsPalindromeRecursive(head);
        }

        public static void TestSolution()
        {
            var head = new ListNode(1, new ListNode(2, new ListNode(2, new ListNode(3))));
            var result = IsPalindrome(head);
            result = IsPalindromeV2(head);
        }
    }
}
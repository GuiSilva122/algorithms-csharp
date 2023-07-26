using LeetCode._75.Helper;

namespace LeetCode.LinkedList
{
    public class RemoveLinkedListElements
    {
        public static ListNode RemoveElements(ListNode head, int val)
        {
            var dummy = new ListNode(0);
            dummy.next = head;

            var prev = dummy;
            var current = head;
            while (current != null)
            {
                if (current.val == val)
                    prev.next = current.next;
                else
                    prev = current;
                current = current.next;
            }
            return dummy.next;
        }

        public static void TestSolution()
        {
            var head = ListNode.GetListNodeFromArray(new int[] { 1, 2, 6, 3, 4, 5, 6 });
            var newHead = RemoveElements(head, 6);
        }
    }
}

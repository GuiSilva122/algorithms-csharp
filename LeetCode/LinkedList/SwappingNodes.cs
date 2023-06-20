using LeetCode._75.Helper;

namespace LeetCode.LinkedList
{
    public class SwappingNodes
    {
        public static ListNode SwapNodes(ListNode head, int k)
        {
            var frontNode = head;
            for (int i = 1; i < k; i++)
                frontNode = frontNode.next;
            var current = frontNode;
            var backNode = head;
            while (current.next != null)
            {
                current = current.next;
                backNode = backNode.next;
            }
            (frontNode.val, backNode.val) = (backNode.val, frontNode.val);
            return head;
        }

        public static void TestSolution()
        {
            var head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
            head = SwapNodes(head, 2);
        }
    }
}

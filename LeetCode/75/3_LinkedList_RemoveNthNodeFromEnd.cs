using LeetCode._75.Helper;

namespace LeetCode._75
{
    public class LinkedList_RemoveNthNodeFromEnd
    {
        // Approach 1 Two Pass
        // O(n) time, O(1) space
        public ListNode RemoveNthFromEndV1(ListNode head, int n)
        {
            int length = 0;
            var currentNode = head;
            while (currentNode != null)
            {
                currentNode = currentNode.next;
                length++;
            }
            if (length == n) return head.next;
            currentNode = head;
            int nodeBeforeRemovedIndex = length - n - 1;
            for (int i = 0; i < nodeBeforeRemovedIndex; i++)
                currentNode = currentNode.next;
            currentNode.next = currentNode.next.next;
            return head;
        }
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            var currentNode = head;
            for (int i = 0; i < n; i++)
                currentNode = currentNode.next;

            if (currentNode == null)
                return head.next;

            var nodeBeforeRemove = head;
            while (currentNode.next != null)
            {
                currentNode = currentNode.next;
                nodeBeforeRemove = nodeBeforeRemove.next;
            }
            nodeBeforeRemove.next = nodeBeforeRemove.next.next;
            return head;
        }
    }
}

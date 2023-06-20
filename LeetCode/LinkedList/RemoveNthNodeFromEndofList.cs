using LeetCode._75.Helper;

namespace LeetCode.LinkedList
{
    internal class RemoveNthNodeFromEndofList
    {
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
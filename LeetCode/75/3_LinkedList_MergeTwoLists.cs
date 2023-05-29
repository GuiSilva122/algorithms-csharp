using LeetCode._75.Helper;

namespace LeetCode._75
{
    public class LinkedList_MergeTwoLists
    {
        // O(n + m) time, O(n + m) space
        public static ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            if (list1 == null) 
                return list2;
            else if (list2 == null) 
                return list1;
            else if (list1.val < list2.val)
            {
                list1.next = MergeTwoLists(list1.next, list2);
                return list1;
            }
            else
            {
                list2.next = MergeTwoLists(list1, list2.next);
                return list2;
            }
        }

        public static ListNode MergeTwoListsV2(ListNode l1, ListNode l2)
        {
            ListNode prehead = new ListNode(-1);
            ListNode prev = prehead;

            while (l1 != null && l2 != null)
            {
                if (l1.val <= l2.val)
                {
                    prev.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    prev.next = l2;
                    l2 = l2.next;
                }
                prev = prev.next;
            }
            prev.next = l1 == null ? l2 : l1;
            return prehead.next;
        }

        private static void PrintLinkedList(ListNode list)
        {
            if (list != null)
            {
                Console.Write(list.next != null ? $"{list.val} -> " : $"{list.val}");
                PrintLinkedList(list.next);
            }
        }

        public static void TestSolution()
        {
            var l1 = new ListNode(1, new ListNode(2, new ListNode(4)));
            var l2 = new ListNode(1, new ListNode(3, new ListNode(4)));
            var merged = MergeTwoLists(l1, l2);
            PrintLinkedList(merged);

            var head = new ListNode(0, new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5))))));
            PrintLinkedList(head);
        }
    }
}
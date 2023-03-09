using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LeetCode
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }

        public string PrintForward()
        {
            if (next != null)
                return val + " -> " + next.PrintForward();

            return val.ToString();
        }
    }

    public static class MergeTwoLinkedLists
    {
        // time O(m + n), space O(m + n)
        public static ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null)
                return l2;
            if (l2 == null)
                return l1;
            else if (l1.val < l2.val)
            {
                l1.next = MergeTwoLists(l1.next, l2);
                return l1;
            }
            else
            {
                l2.next = MergeTwoLists(l1, l2.next);
                return l2;
            }
        }

        // time O(m + n), space O(1)
        public static ListNode MergeTwoListsV2(ListNode l1, ListNode l2)
        {
            ListNode merged = new ListNode();
            var tailMerged = merged;
            while (l1 != null && l2 != null)
            {
                if (l1.val < l2.val)
                {
                    tailMerged.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    tailMerged.next = l2;
                    l2 = l2.next;
                }
                tailMerged = tailMerged.next;
            }
            tailMerged.next = l1 == null ? l2 : l1;
            return merged.next;
        }

        public static void TestSolution()
        {
            var head1 = new ListNode(1, new ListNode(2, new ListNode(4)));
            var head2 = new ListNode(1, new ListNode(3, new ListNode(4)));
            Console.WriteLine($"list 1 = { head1.PrintForward() }");
            Console.WriteLine($"list 2 = { head2.PrintForward() }");
            
            var result = MergeTwoListsV2(head1, head2);

            Console.WriteLine($"result = { result.PrintForward() }");
        }
    }
}

using LeetCode._75.Helper;

namespace LeetCode.LinkedList
{
    public class AddTwoNumbers
    {
        public static ListNode AddTwoNumberss(ListNode l1, ListNode l2)
        {
            var dummy = new ListNode(0);
            var current = dummy;
            int carry = 0;
            while (l1 != null || l2 != null)
            {
                int sum = carry;
                if (l1 != null)
                {
                    sum += l1.val;
                    l1 = l1.next;
                }
                if (l2 != null)
                {
                    sum += l2.val;
                    l2 = l2.next;
                }
                carry = sum / 10;
                current.next = new ListNode(sum % 10);
                current = current.next;
            }
            return dummy.next;
        }

        public static void TestSolution()
        {
            var list1 = new ListNode(2, new ListNode(4, new ListNode(3)));
            var list2 = new ListNode(5, new ListNode(6, new ListNode(4)));
            var result = AddTwoNumberss(list1, list2);
        }
    }
}
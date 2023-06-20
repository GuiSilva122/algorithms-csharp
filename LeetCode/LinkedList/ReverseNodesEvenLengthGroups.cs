using LeetCode._75.Helper;

namespace LeetCode.LinkedList
{
    public class ReverseNodesEvenLengthGroups
    {
        public ListNode ReverseEvenLengthGroups(ListNode head)
        {
            var dummy = new ListNode(0, head);
            var groupPrev = dummy;

            int k = 1;
            while (groupPrev != null && groupPrev.next != null)
            {
                var (kthNode, newK) = GetKthNode(groupPrev, k);
                k = newK;
                var groupNext = kthNode.next;

                if (k % 2 != 0)
                {
                    groupPrev = kthNode;
                }
                else
                {
                    var (prev, current) = (kthNode.next, groupPrev.next);
                    while (current != null && current != groupNext) 
                    {
                        var currentNextTemp = current.next;
                        current.next = prev;
                        prev = current;
                        current = currentNextTemp;
                    }
                    var groupPrevNextTemp = groupPrev.next;
                    groupPrev.next = kthNode;
                    groupPrev = groupPrevNextTemp;
                }
                k++;
            }
            return dummy.next;
        }

        private (ListNode, int) GetKthNode(ListNode current, int k)
        {
            int count = k;
            while (current != null && current.next != null && k > 0)
            {
                current = current.next;
                k--;
            }
            return (current, count - k);
        }

        public static void TestSolution()
        {
            var head = ListNode.GetListNodeFromArray(new int[] { 5, 2, 6, 3, 9, 1, 7, 3, 8, 4 });
            var result = ReverseEvenLengthGroups(head);
            Console.WriteLine(head.PrintForward());
        }
    }
}
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LeetCode._75.Helper
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
                return val + "->" + next.PrintForward();

            return val.ToString();
        }
    }
}
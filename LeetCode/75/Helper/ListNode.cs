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

        public override string ToString()
            => $"{val}->{next?.val.ToString() ?? "null" }";

        public static ListNode GetListNodeFromArray(int[] nums)
        {
            var head = new ListNode();
            var current = head;
            for (int i = 0; i < nums.Length; i++)
            {
                current.val = nums[i];
                current.next = new ListNode();
                current = current.next;
            }
            return head;
        }
    }
}
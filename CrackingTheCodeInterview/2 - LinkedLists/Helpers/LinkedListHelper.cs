namespace CrackingTheCodeInterview.LinkedLists.Helpers
{
    internal class LinkedListHelper
    {
        public static LinkedListNode CreateLinkedListFromArray(int[] vals)
        {
            var head = new LinkedListNode(vals[0], null, null);
            var current = head;
            for (int i = 1; i < vals.Length; i++)
                current = new LinkedListNode(vals[i], null, current);
            
            return head;
        }
    }
}

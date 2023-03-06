namespace CrackingTheCodeInterview.LinkedLists.Helpers
{
    public class LinkedListNode
    {
        public LinkedListNode next;
        public LinkedListNode prev;
        public LinkedListNode last;
        public int data;
        
        public LinkedListNode() { }

        public LinkedListNode(int data) => this.data = data;

        public LinkedListNode(int data, LinkedListNode next, LinkedListNode previous)
        {
            this.data = data;
            SetNext(next);
            SetPrevious(previous);
        }

        public void SetNext(LinkedListNode n)
        {
            next = n;
            if (this == last)
                last = n;
            
            if (n != null && n.prev != this)
                n.SetPrevious(this);
        }

        public void SetPrevious(LinkedListNode p)
        {
            prev = p;
            if (p != null && p.next != this)
                p.SetNext(this);
        }

        public string PrintForward()
        {
            if (next != null)
                return data + "->" + next.PrintForward();
            
            return data.ToString();
        }
    }
}
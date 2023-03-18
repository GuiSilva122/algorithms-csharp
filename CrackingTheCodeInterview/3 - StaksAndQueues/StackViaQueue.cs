using System.Collections.Generic;

namespace CrackingTheCodeInterview.StaksAndQueues
{
    public class StackViaQueue
    {
        private Queue<int> q1 = new Queue<int>();
        private Queue<int> q2 = new Queue<int>();

        public void Push(int x)
        {
            q2.Enqueue(x);

            while (q1.Count > 0) 
                q2.Enqueue(q1.Dequeue());

            Queue<int> temp = q1;
            q1 = q2;
            q2 = temp;
        }

        public int Pop()
        {
            if (q1.Count == 0) return -1;
            return q1.Dequeue();
        }

        public int Top()
        {
            if (q1.Count == 0) return -1;
            return q1.Peek();
        }

        public int Size() => q1.Count;
    }
}
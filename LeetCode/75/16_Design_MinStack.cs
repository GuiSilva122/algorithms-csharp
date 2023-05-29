namespace LeetCode._75
{
    public class Design_MinStack
    {
        public class MyQueue
        {
            private Stack<int> s1;
            private Stack<int> s2;
            int front;
            public MyQueue()
            {
                s1 = new Stack<int>();
                s2 = new Stack<int>();
            }
            // O(1) time, O(n) space
            public void Push(int x)
            {
                if (s1.Count == 0)
                    front = x;
                s1.Push(x);
            }
            // O(1) time amortized, O(1) space
            public int Pop()
            {
                if (s2.Count == 0)
                {
                    while (s1.Count > 0)
                        s2.Push(s1.Pop());
                }
                return s2.Pop();
            }
            // O(1) time, O(1) space
            public int Peek()
            {
                if (s2.Count > 0)
                    return s2.Peek();
                return front;
            }
            // O(1) time, O(1) space
            public bool Empty() => s1.Count == 0 && s2.Count == 0;
        }
    }
}
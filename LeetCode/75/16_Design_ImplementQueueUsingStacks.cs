namespace LeetCode._75
{
    public class Design_ImplementQueueUsingStacks
    {
        public class MinStack
        {
            private Stack<int> stack = new Stack<int>();
            private Stack<int[]> minStack = new Stack<int[]>();
            public MinStack() { }

            public void Push(int val)
            {
                stack.Push(val);
                if (minStack.Count == 0 || val < minStack.Peek()[0])
                    minStack.Push(new int[] { val, 1 });
                else if (val == minStack.Peek()[0])
                    minStack.Peek()[1]++;
            }

            public void Pop()
            {
                if (stack.Peek().Equals(minStack.Peek()[0]))
                    minStack.Peek()[1]--;
                if (minStack.Peek()[1] == 0)
                    minStack.Pop();
                stack.Pop();
            }

            public int Top() => stack.Peek();

            public int GetMin() => minStack.Peek()[0];
        }
    }
}
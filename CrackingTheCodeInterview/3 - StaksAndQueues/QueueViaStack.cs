using System.Collections.Generic;

namespace CrackingTheCodeInterview.StaksAndQueues
{
    public class QueueViaStack<T>
    {
        private Stack<T> stackNewest;
        private Stack<T> stackOldest;

        public QueueViaStack()
        {
            stackNewest = new Stack<T>();
            stackOldest = new Stack<T>();
        }

        public int Size() => stackOldest.Count + stackNewest.Count;

        public void Add(T value) => stackNewest.Push(value);

        public T Peek()
        {
            ShiftStacks();
            return stackOldest.Peek();
        }

        public T Remove()
        {
            ShiftStacks();
            return stackOldest.Pop();
        }

        private void ShiftStacks()
        {
            if (stackOldest.Count == 0)
                while (stackNewest.Count > 0)
                    stackOldest.Push(stackNewest.Pop());
        }
    }
}
using System;
using System.Collections.Generic;

namespace CrackingTheCodeInterview.StaksAndQueues
{
    public static class SortStack
    {
        public static Stack<int> Sort(Stack<int> stack)
        {
            if (stack == null) return null;
            if (stack.Count == 0 || stack.Count == 1) return stack;

            var orderedStack = new Stack<int>();
            while (stack.Count > 0)
            {
                var temp = stack.Pop();
                while (orderedStack.Count > 0 && orderedStack.Peek() > temp)
                    stack.Push(orderedStack.Pop());

                orderedStack.Push(temp);
            }

            while (orderedStack.Count > 0)
                stack.Push(orderedStack.Pop());

            return stack;
        }

        public static void TestSolution()
        {
            var stack = new Stack<int>();
            var random = new Random();

            for (int i = 0; i < 5; i++)
                stack.Push(random.Next(0, 10));

            Sort(stack);

            while (stack.Count > 0)
                Console.WriteLine(stack.Pop());
        }
    }
}

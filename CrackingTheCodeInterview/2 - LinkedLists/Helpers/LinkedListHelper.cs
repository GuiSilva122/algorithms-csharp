using System;

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

        private static Random random = new();
        public static int RandomInt(int n) => (int)(random.NextSingle() * n);
        public static int RandomIntInRange(int min, int max) => RandomInt(max + 1 - min) + min;
        public static LinkedListNode RandomLinkedList(int N, int min, int max)
        {
            var root = new LinkedListNode(RandomIntInRange(min, max), null, null);
            var prev = root;
            for (int i = 1; i < N; i++)
            {
                int data = RandomIntInRange(min, max);
                var next = new LinkedListNode(data, null, null);
                prev.SetNext(next);
                prev = next;
            }
            return root;
        }
    }
}

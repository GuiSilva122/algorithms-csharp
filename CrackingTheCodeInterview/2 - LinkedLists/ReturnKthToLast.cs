using CrackingTheCodeInterview.LinkedLists.Helpers;
using System;

namespace CrackingTheCodeInterview.LinkedLists
{
    internal class ReturnKthToLast
    {
        public static int KthToLastV1(LinkedListNode head, int k)
        {
            if (head == null) return 0;
            int index = KthToLastV1(head.next, k) + 1;
            if (index == k)
                Console.WriteLine($"The {k}th element from the last is {head.data}");

            return index;
        }

        public record Index { public int value = 0; }
        public static LinkedListNode KthToLastV2(LinkedListNode head, int k)
        {
            var index = new Index();
            return KthToLastV2(head, k, index);
        }

        public static LinkedListNode KthToLastV2(LinkedListNode head, int k, Index index)
        {
            if (head == null) return null;

            var node = KthToLastV2(head.next, k, index);
            index.value++;
            
            if (index.value == k) return head;
            return node;
        }

        public static LinkedListNode KthToLastV3(LinkedListNode head, int k)
        {
            var first = head;
            var second = head;

            for (int i = 0; i < k; i++) 
            {
                if (first == null) return null;
                first = first.next;
            }
            
            while (first != null)
            {
                first = first.next;
                second = second.next;
            }
            return second;

        }

        public static void TestSolution()
        {
            int[] array = { 0, 1, 2, 3, 4, 5, 6 };
            var head = LinkedListHelper.CreateLinkedListFromArray(array);
            for (int i = 0; i <= array.Length + 1; i++)
                KthToLastV1(head, i);

            for (int i = 0; i <= array.Length + 1; i++)
            {
                var data = KthToLastV3(head, i)?.data.ToString();
                Console.WriteLine($"The {i}th element from the last is { (!string.IsNullOrEmpty(data) ? data : "null") }");
            }   
        }
    }
}

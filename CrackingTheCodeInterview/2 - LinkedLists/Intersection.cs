using CrackingTheCodeInterview.LinkedLists.Helpers;
using System;
using static CrackingTheCodeInterview.LinkedLists.Palindrome;

namespace CrackingTheCodeInterview.LinkedLists
{
    public static class Intersection
    {
        // O(nm) where n is the length of List 1 and m is the length of List 2, O(1) space
        public static LinkedListNode FindIntersectionV1(LinkedListNode list1, LinkedListNode list2)
        {
            var currentL1 = list1;
            var currentL2 = list2;
            while (currentL1 != null)
            {
                while (currentL2 != null)
                {
                    if (currentL1 == currentL2)
                        return currentL1;

                    currentL2 = currentL2.next;
                }
                currentL2 = list2;
                currentL1 = currentL1.next;
            }

            return null;
        }

        public static LinkedListNode FindIntersectionV2(LinkedListNode list1, LinkedListNode list2)
        {
            (var lengthL1, var tailL1) = GetLengthAndTail(list1);
            (var lengthL2, var tailL2) = GetLengthAndTail(list2);

            if (tailL1 != tailL2) return null;

            LinkedListNode shorter = lengthL1 < lengthL2 ? list1 : list2;
            LinkedListNode longer = lengthL1 > lengthL2 ? list2 : list1;

            longer = GetKthNode(longer, Math.Abs(lengthL1 - lengthL2));

            while (shorter != longer)
            {
                shorter = shorter.next;
                longer = longer.next;
            }
            
            return longer;
        }

        private static (int length, LinkedListNode tail) GetLengthAndTail(LinkedListNode list1)
        {
            int length = 0;
            var current = list1;
            while (current.next != null)
            {
                length++;
                current = current.next;
            }
            length++;
            return (length, current);
        }

        private static LinkedListNode GetKthNode(LinkedListNode head, int k)
        {
            var current = head;
            while (k > 0 && current != null)
            {
                current = current.next;
                k--;
            }
            return current;
        }

        public static void TestSolution()
        {
            int[] vals = { -1, -2, 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            LinkedListNode list1 = LinkedListHelper.CreateLinkedListFromArray(vals);

            int[] vals2 = { 12, 14, 15 };
            LinkedListNode list2 = LinkedListHelper.CreateLinkedListFromArray(vals2);

            list2.next.next = list1.next.next.next.next;

            Console.WriteLine(list1.PrintForward());
            Console.WriteLine(list2.PrintForward());

            LinkedListNode intersection = FindIntersectionV2(list1, list2);

            Console.WriteLine(intersection.PrintForward());
        }
    }
}
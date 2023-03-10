using CrackingTheCodeInterview.LinkedLists.Helpers;
using System;

namespace CrackingTheCodeInterview.LinkedLists
{
    public static class SumLists
    {
        public static LinkedListNode AddListsV1(LinkedListNode l1, LinkedListNode l2)
        {
            int l1Value = 0;
            int l2Value = 0;

            while (l1 != null)
            {
                l1Value = l1Value * 10 + l1.data;
                l1 = l1.next;
            }
            while (l2 != null)
            {
                l2Value = l2Value * 10 + l2.data;
                l2 = l2.next;
            }
                        
            int digit = 0;
            int sum = l1Value + l2Value;
            LinkedListNode resultHead = null;
           
            while (sum > 0)
            {
                digit = sum % 10;
                
                var node = new LinkedListNode(digit);
                node.next = resultHead;
                resultHead = node;

                sum /= 10;
            }
            return resultHead;
        }

        public static LinkedListNode AddListsV2(LinkedListNode l1, LinkedListNode l2)
        {
            return AddListsV2(l1, l2, 0);
        }

        public static LinkedListNode AddListsV2(LinkedListNode l1, LinkedListNode l2, int carry)
        {
            if (l1 == null && l2 == null && carry == 0)
                return null;

            int value = carry;
            if (l1 != null) value += l1.data;
            if (l2 != null) value += l2.data;

            var result = new LinkedListNode();
            result.data = value % 10;

            if (l1 != null || l2 != null)
            {
                var more = AddListsV2(l1 == null ? null : l1.next, l2 == null ? null : l2.next, value >= 10 ? 1 : 0);
                result.SetNext(more);
            }

            return result;
        }

        public static (LinkedListNode node, int carry) AddListsV3(LinkedListNode l1, LinkedListNode l2)
        {
            if (l1 == null && l2 == null) return (null, 0);
            var (node, carry) = AddListsV3(l1.next, l2.next);

            int value = carry;
            if (l1 != null) value += l1.data;
            if (l2 != null) value += l2.data;

            var result = new LinkedListNode();
            result.data = value % 10;

            if (l1 != null || l2 != null)
                result.SetNext(node);

            return (result, value >= 10 ? 1 : 0);
        }

        public static void PrintReverseLinkedList(LinkedListNode node)
        {
            if (node != null)
                PrintReverseLinkedList(node.next);
            
            Console.WriteLine($"-> {node?.data}");
        }

        public static void TestSolution()
        {
            var lA1 = new LinkedListNode(6, null, null);
            var lA2 = new LinkedListNode(1, null, lA1);
            var lA3 = new LinkedListNode(7, null, lA2);

            var lB1 = new LinkedListNode(2, null, null);
            var lB2 = new LinkedListNode(9, null, lB1);
            var lB3 = new LinkedListNode(5, null, lB2);

            Console.WriteLine("  " + lA1.PrintForward());
            Console.WriteLine("+ " + lB1.PrintForward());

            (LinkedListNode list3, int carry) = AddListsV3(lA1, lB1);

            PrintReverseLinkedList(lA1);

            Console.WriteLine("  " + lA1.PrintForward());
            Console.WriteLine("+ " + lB1.PrintForward());
            Console.WriteLine("= " + list3.PrintForward());
        }
    }
}

using CrackingTheCodeInterview.LinkedLists.Helpers;
using System;
using System.Collections.Generic;

namespace CrackingTheCodeInterview.LinkedLists
{
    internal class Palindrome
    {
        #region V1
        public static bool IsPalindromeV1(LinkedListNode head)
        {
            LinkedListNode reversed = ReverseAndCloneRecursive(head);
            return IsEqual(head, reversed);
        }

        public static bool IsEqual(LinkedListNode l1, LinkedListNode l2)
        {
            while (l1 != null && l2 != null)
            {
                if (l1.data != l2.data)
                    return false;
                l1 = l1.next;
                l2 = l2.next;
            }
            return l1 == null && l2 == null;
        }

        private static LinkedListNode ReverseAndClone(LinkedListNode head)
        {
            LinkedListNode newListHead = null;

            while (head != null)
            {
                var newNode = new LinkedListNode(head.data);
                newNode.next = newListHead;
                newListHead = newNode;
                head = head.next;
            }
            return newListHead;
        }

        private static LinkedListNode ReverseAndCloneRecursive(LinkedListNode head)
        {
            if (head == null || head.next == null)
                return head;

            LinkedListNode newHeadNode = ReverseAndCloneRecursive(head.next);
            head.next.next = head;
            head.next = null;

            return newHeadNode;
        }

        #endregion

        #region V2

        // O(n) time, O(n) space
        public static bool IsPalindromeV2(LinkedListNode head)
        {
            var slow = head;
            var fast = head;
            var stack = new Stack<int>();
            while (fast != null && fast.next != null)
            {
                stack.Push(slow.data);
                slow = slow.next;
                fast = fast.next.next;
            }
            if (fast != null) //Skip middle element
                slow = slow.next;

            while (slow != null)
            {
                if (slow.data != stack.Pop())
                    return false;

                slow = slow.next;
            }
            return true;
        }

        #endregion

        #region V3

        public record Result { public LinkedListNode node; public bool result; }

        public static bool IsPalindromeV3(LinkedListNode head)
        {
            int length = LengthList(head);
            var result = IsPalindromeRecurse(head, length);

            return result.result;
        }

        private static int LengthList(LinkedListNode node)
        {
            int length = 0;
            while (node != null)
            {
                length++;
                node = node.next;
            }
            return length;
        }

        public static Result IsPalindromeRecurse(LinkedListNode head, int length)
        {
            if (head == null || length <= 0)
                return new Result { node = head, result = true };
            else if (length == 1)
                return new Result { node = head.next, result = true };

            var result = IsPalindromeRecurse(head.next, length - 2);

            if (!result.result || result.node == null)
                return result;

            result.result = (head.data == result.node.data);
            result.node = result.node.next;

            return result;
        }

        #endregion

        public static void TestSolution()
        {
            var lA1 = new LinkedListNode(1, null, null);
            var lA2 = new LinkedListNode(2, null, lA1);
            var lA3 = new LinkedListNode(3, null, lA2);
            var lA4 = new LinkedListNode(2, null, lA3);
            var lA5 = new LinkedListNode(1, null, lA4);

            Console.WriteLine(lA1.PrintForward());
            var isPalindrome = IsPalindromeV3(lA1);
            Console.WriteLine($"IsPalindrome = {isPalindrome}");
        }
    }
}

using CrackingTheCodeInterview.TreesAndGraphs.Helper;
using System;

namespace CrackingTheCodeInterview.TreesAndGraphs
{
    public class Traversals
    {
        public static void Visit(TreeNode node)
        {
            if (node != null)
                Console.WriteLine(node.data);
        }

        public static void InOrderTraversal(TreeNode node)
        {
            if (node != null)
            {
                InOrderTraversal(node.left);
                Visit(node);
                InOrderTraversal(node.right);
            }
        }

        public static void PreOrderTraversal(TreeNode node)
        {
            if (node != null)
            {
                Visit(node);
                InOrderTraversal(node.left);
                InOrderTraversal(node.right);
            }
        }

        public static void PostOrderTraversal(TreeNode node)
        {
            if (node != null)
            {
                InOrderTraversal(node.left);
                InOrderTraversal(node.right);
                Visit(node);
            }
        }

        public static void Test()
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var root = TreeNode.CreateMinimalBST(array);
            InOrderTraversal(root);
            Console.WriteLine();
            PreOrderTraversal(root);
            Console.WriteLine();
            PostOrderTraversal(root);
        }
    }
}

namespace LeetCode.Graph
{
    public class PopulatingNextRightPointers
    {
        public class Node
        {
            public int val;
            public Node left;
            public Node right;
            public Node next;

            public Node() { }

            public Node(int _val)
            {
                val = _val;
            }

            public Node(int _val, Node _left, Node _right, Node _next)
            {
                val = _val;
                left = _left;
                right = _right;
                next = _next;
            }
        }

        public static Node Connect(Node root)
        {
            if (root == null) 
                return root;
            var queue = new Queue<Node>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                int size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    var node = queue.Dequeue();
                    // The queue will contain nodes from 2 levels at most at any point in time.
                    // This check ensures we only don't establish next pointers beyond the end of a level
                    if (i < size - 1)
                        node.next = queue.Peek();

                    if (node.left != null)
                        queue.Enqueue(node.left);
                    
                    if (node.right != null)
                        queue.Enqueue(node.right);
                }
            }
            return root;
        }

        public static Node ConnectV2(Node root)
        {
            if (root == null)
                return root;

            // Start with the root node. There are no next pointers that need to be set up on the first level
            Node leftmost = root;
            // Once we reach the final level, we are done
            while (leftmost.left != null)
            {
                // Iterate the "linked list" starting from the head node and using the next pointers,
                // establish the corresponding links for the next level
                Node head = leftmost;
                while (head != null)
                {
                    // CONNECTION 1
                    head.left.next = head.right;
                    // CONNECTION 2
                    if (head.next != null)
                        head.right.next = head.next.left;
                    // Progress along the list (nodes on the current level)
                    head = head.next;
                }
                // Move onto the next level
                leftmost = leftmost.left;
            }
            return root;
        }

        public static void TestSolution()
        {
            var left = new Node(2, new Node(4), new Node(5), null);
            var right = new Node(3, new Node(6), new Node(7), null);
            var root = new Node(1, left, right, null);

            var result = Connect(root);
        }
    }
}
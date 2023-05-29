namespace LeetCode._75
{
    public class Stack_AsteroidCollision
    {
        public static int[] AsteroidCollision(int[] asteroids)
        {
            var stack = new Stack<int>();
            foreach (var asteroid in asteroids)
            {
                if (asteroid > 0)
                    stack.Push(asteroid);
                else
                {
                    while (stack.Count > 0 && stack.Peek() > 0 && stack.Peek() < -asteroid)
                        stack.Pop();

                    if (stack.Count == 0 || stack.Peek() < 0)
                        stack.Push(asteroid);
                    else if (stack.Peek() == -asteroid)
                        stack.Pop();
                }
            }
            return stack.Reverse().ToArray();
        }

        public static void TestSolution()
        {
            var asteroids = new int[] { 5, 10, -5 };
            var result = AsteroidCollision(asteroids);
            //Output: [5,10]
        }
    }
}
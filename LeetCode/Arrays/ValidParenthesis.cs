namespace LeetCode.Arrays
{
    public static class ValidParenthesis
    {
        // O(n) time, O(n) space
        public static bool IsValid(string s)
        {
            var hashMap = new Dictionary<char, char>
            {
                { ')', '(' },
                { ']', '[' },
                { '}', '{' }
            };

            var stack = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (hashMap.ContainsKey(s[i]))
                {
                    char topElement = stack.Count == 0 ? '#' : stack.Pop();
                    if (topElement != hashMap[s[i]])
                        return false;
                }
                else
                    stack.Push(s[i]);
            }
            return stack.Count == 0;
        }

        public static void TestSolution()
        {
            var s = "()";
            var isValid = IsValid(s);
            Console.WriteLine($"string = {s}, is valid = {IsValid}");

            s = "()[]{}";
            isValid = IsValid(s);
            Console.WriteLine($"string = {s}, is valid = {IsValid}");

            s = "(]";
            isValid = IsValid(s);
            Console.WriteLine($"string = {s}, is valid = {IsValid}");
        }
    }
}
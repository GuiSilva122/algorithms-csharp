namespace LeetCode._75
{
    public class Stack_BackSpaceStringCompare
    {
        public bool BackspaceCompare(string s, string t)
            => BuildChar(s).Equals(BuildChar(t));

        private string BuildChar(string s)
        {
            var stack = new Stack<char>();
            foreach (char sChar in s)
            {
                if (sChar != '#')
                    stack.Push(sChar);
                else if (stack.Count > 0)
                    stack.Pop();
            }
            return string.Join("", stack.ToList());
        }
    }
}
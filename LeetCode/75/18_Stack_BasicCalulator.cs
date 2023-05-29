namespace LeetCode._75
{
    public class Stack_BasicCalulator
    {
        public static int Calculate(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;
            var stack = new Stack<int>();
            int currentNumber = 0;
            char operation = '+';
            for (int i = 0; i < s.Length; i++)
            {
                char currentChar = s[i];
                if (char.IsDigit(currentChar))
                    currentNumber = (currentNumber * 10) + (currentChar - '0');
                                
                if (!char.IsDigit(currentChar) && !char.IsWhiteSpace(currentChar) || i == s.Length - 1)
                {
                    if (operation == '-')
                        stack.Push(-currentNumber);
                    else if (operation == '+')
                        stack.Push(currentNumber);
                    else if (operation == '*')
                        stack.Push(stack.Pop() * currentNumber);
                    else if (operation == '/')
                        stack.Push(stack.Pop() / currentNumber);
                    
                    operation = currentChar;
                    currentNumber = 0;
                }
            }
            int result = 0;
            while (stack.Count > 0)
                result += stack.Pop();
            
            return result;
        }

        // O(n) time, O(1) space
        public int CalculateV2(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;
            int currentNumber = 0, lastNumber = 0, result = 0;
            char operation = '+';
            for (int i = 0; i < s.Length; i++)
            {
                char currentChar = s[i];
                if (char.IsDigit(currentChar))
                    currentNumber = (currentNumber * 10) + (currentChar - '0');
                
                if (!char.IsDigit(currentChar) && !char.IsWhiteSpace(currentChar) || i == s.Length - 1)
                {
                    if (operation == '+' || operation == '-')
                    {
                        result += lastNumber;
                        lastNumber = (operation == '+') ? currentNumber : -currentNumber;
                    }
                    else if (operation == '*')
                    {
                        lastNumber = lastNumber * currentNumber;
                    }
                    else if (operation == '/')
                    {
                        lastNumber = lastNumber / currentNumber;
                    }
                    operation = currentChar;
                    currentNumber = 0;
                }
            }
            result += lastNumber;
            return result;
        }

        public static void TestSolution()
        {
            var s = "3+2*2";
            var result = Calculate(s);
        }
    }
}
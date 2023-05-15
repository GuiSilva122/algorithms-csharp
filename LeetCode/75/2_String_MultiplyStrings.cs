using System.Text;

namespace LeetCode._75
{
    public class String_MultiplyStrings
    {
        public static string Multiply(string num1, string num2)
        {
            if (num1.Equals("0") || num2.Equals("0"))
                return "0";
            // Reverse both the numbers.
            var firstNumber = new StringBuilder(new string(num1.Reverse().ToArray()));
            var secondNumber = new StringBuilder(new string(num2.Reverse().ToArray()));

            // To store the multiplication result of each digit of secondNumber with firstNumber.
            int N = firstNumber.Length + secondNumber.Length;
            var answer = new StringBuilder();
            for (int i = 0; i < N; i++)
                answer.Append(0);

            for (int place2 = 0; place2 < secondNumber.Length; place2++)
            {
                int digit2 = secondNumber[place2] - '0';
                // For each digit in secondNumber multiply the digit by all digits in firstNumber.
                for (int place1 = 0; place1 < firstNumber.Length; place1++)
                {
                    int digit1 = firstNumber[place1] - '0';
                    // The number of zeros from multiplying to digits depends on the 
                    // place of digit2 in secondNumber and the place of the digit1 in firstNumber.
                    int currentPos = place1 + place2;
                    // The digit currently at position currentPos in the answer string
                    // is carried over and summed with the current result.
                    int carry = answer[currentPos] - '0';
                    int multiplication = digit1 * digit2 + carry;
                    // Set the ones place of the multiplication result.
                    answer[currentPos] = (char)(multiplication % 10 + '0');
                    // Carry the tens place of the multiplication result by 
                    // adding it to the next position in the answer array.
                    int value = (answer[currentPos + 1] - '0') + multiplication / 10;
                    answer[currentPos + 1] = (char)(value + '0');
                }
            }
            // Pop excess 0 from the rear of answer.
            if (answer[answer.Length - 1] == '0')
                answer.Remove(answer.Length - 1, 1);

            return new string(answer.ToString().Reverse().ToArray());
        }

        public static void TestSolution()
        {
            var result = Multiply("23", "45");
        }
    }
}
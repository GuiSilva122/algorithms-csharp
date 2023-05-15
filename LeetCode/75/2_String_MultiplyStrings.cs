using System.Text;

namespace LeetCode._75
{
    public class String_MultiplyStrings
    {
        // Here N and M are the number of digits in num1 and num2 respectively.
        // Time complexity: O(M^2 + MN)
                // During multiplication, we perform N operations for each of the M digits of the second number;
                // this requires O(MN) time.
                // Then we add each of the M multiplication results(of length O(N+M)) to the answer string;
                // this requires O(M(M+N))
        //Space complexity: O(M^2 + MN)
        public string MultiplyV1(string num1, string num2)
        {
            if (num1.Equals("0") || num2.Equals("0"))
                return "0";

            var firstNumber = new StringBuilder(new string(num1.Reverse().ToArray()));
            var secondNumber = new StringBuilder(new string(num2.Reverse().ToArray()));

            var results = new List<List<int>>();
            for (int i = 0; i < secondNumber.Length; i++)
                results.Add(MultiplyOneDigit(firstNumber, secondNumber[i], i));
            
            var answer = SumResults(results);
            return new string(answer.ToString().Reverse().ToArray());
        }

        private List<int> MultiplyOneDigit(StringBuilder firstNumber, char secondNumberDigit, int numZeros)
        {
            var currentResult = new List<int>();
            for (int i = 0; i < numZeros; i++)
                currentResult.Add(0);            
            int carry = 0;
            for (int i = 0; i < firstNumber.Length; i++)
            {
                char firstNumberDigit = firstNumber[i];
                int multiplication = (secondNumberDigit - '0') * (firstNumberDigit - '0') + carry;
                carry = multiplication / 10;
                currentResult.Add(multiplication % 10);
            }
            if (carry != 0)
                currentResult.Add(carry);            
            return currentResult;
        }

        private StringBuilder SumResults(List<List<int>> results)
        {
            var answer = new List<int>(results[results.Count - 1]);
            var newAnswer = new List<int>();
            for (int j = 0; j < results.Count - 1; j++)
            {
                var result = new List<int>(results[j]);
                newAnswer = new List<int>();
                int carry = 0;
                for (int i = 0; i < answer.Count || i < result.Count; i++)
                {
                    int digit1 = i < result.Count ? result[i]: 0;
                    int digit2 = i < answer.Count ? answer[i] : 0;
                    int sum = digit1 + digit2 + carry;
                    carry = sum / 10;
                    newAnswer.Add(sum % 10);
                }
                if (carry != 0)
                    newAnswer.Add(carry);
                answer = newAnswer;
            }
            var finalAnswer = new StringBuilder();
            foreach (int digit in answer)
                finalAnswer.Append(digit);            
            return finalAnswer;
        }

        // Time complexity: O(M(M + N))
        //Space complexity: O(M + N)
        public string MultiplyV2(string num1, string num2)
        {
            if (num1.Equals("0") || num2.Equals("0"))
                return "0";
                        
            var firstNumber = new StringBuilder(new string(num1.Reverse().ToArray()));
            var secondNumber = new StringBuilder(new string(num2.Reverse().ToArray()));

            int N = firstNumber.Length + secondNumber.Length;
            var ans = new List<int>();
            for (int i = 0; i < N; i++)
                ans.Add(0);

            for (int i = 0; i < secondNumber.Length; i++)
                ans = AddStrings(MultiplyOneDigit(firstNumber, secondNumber[i], i), ans);

            if (ans[ans.Count - 1] == 0)
                ans.Remove(ans.Count - 1);

            var answer = new StringBuilder();
            for (int i = ans.Count - 1; i >= 0; i--)
                answer.Append(ans[i]);

            return answer.ToString();
        }

        private List<int> AddStrings(List<int> num1, List<int> num2)
        {
            var ans = new List<int>();
            int carry = 0;

            for (int i = 0; i < num1.Count || i < num2.Count; i++)
            {
                int digit1 = i < num1.Count ? num1[i] : 0;
                int digit2 = i < num2.Count ? num2[i] : 0;
                int sum = digit1 + digit2 + carry;
                carry = sum / 10;
                ans.Add(sum % 10);
            }
            if (carry != 0)
                ans.Add(carry);
            return ans;
        }

        // Time complexity: O(MN)
        //Space complexity: O(M + N)
        public static string MultiplyV3(string num1, string num2)
        {
            if (num1.Equals("0") || num2.Equals("0"))
                return "0";

            var firstNumber = new StringBuilder(new string(num1.Reverse().ToArray()));
            var secondNumber = new StringBuilder(new string(num2.Reverse().ToArray()));

            int N = firstNumber.Length + secondNumber.Length;
            var answer = new StringBuilder();
            for (int i = 0; i < N; i++)
                answer.Append(0);

            for (int place2 = 0; place2 < secondNumber.Length; place2++)
            {
                int digit2 = secondNumber[place2] - '0';
                for (int place1 = 0; place1 < firstNumber.Length; place1++)
                {
                    int digit1 = firstNumber[place1] - '0';
                    int currentPos = place1 + place2;
                    int carry = answer[currentPos] - '0';
                    int multiplication = digit1 * digit2 + carry;
                    answer[currentPos] = (char)(multiplication % 10 + '0');
                    int value = (answer[currentPos + 1] - '0') + multiplication / 10;
                    answer[currentPos + 1] = (char)(value + '0');
                }
            }
            if (answer[answer.Length - 1] == '0')
                answer.Remove(answer.Length - 1, 1);

            return new string(answer.ToString().Reverse().ToArray());
        }

        public static void TestSolution()
        {
            var result = MultiplyV3("23", "45");
        }
    }
}
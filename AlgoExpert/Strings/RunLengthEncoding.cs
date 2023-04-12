using System.Text;

namespace AlgoExpert.Strings
{
    public class RunLengthEncoding
    {
        public static string RunLengthEncodingV1(string str)
        {
            var encoded = new StringBuilder();
            var currentRunLength = 1;
            for (int i = 1; i < str.Length; i++)
            {
                if (str[i] != str[i - 1] || currentRunLength == 9)
                {
                    AddRun(encoded, currentRunLength, str[i - 1]);
                    currentRunLength = 0;
                }
                currentRunLength += 1;
            }
            AddRun(encoded, currentRunLength, str[str.Length - 1]);
            return encoded.ToString();
        }

        private static void AddRun(StringBuilder encoded, int run, char character)
        {
            encoded.Append(run.ToString());
            encoded.Append(character);
        }

        public static void TestSolution()
        {
            var a = "AAAAAAAAAAAAA";
            var result = RunLengthEncodingV1(a);

            var b = "AAAAAAAAAAAAABBCCCCDD";
            result = RunLengthEncodingV1(b);

        }
    }
}

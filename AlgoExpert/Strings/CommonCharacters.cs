namespace AlgoExpert.Strings
{
    public class CommonCharacters
    {
        public static string[] FindCommonCharacters(string[] strings)
        {
            var hash = new Dictionary<char, int>();
            for (int i = 0; i < strings.Length; i++)
            {
                for (int j = 0; j < strings[i].Length; j++)
                {
                    if (!hash.ContainsKey(strings[i][j]))
                        hash.Add(strings[i][j], 1);
                    else
                        hash[strings[i][j]] = hash[strings[i][j]] + 1;
                }
            }

            var result = new List<string>();
            foreach (var item in hash)
            {
                if (item.Value == strings.Length)
                    result.Add(item.Key.ToString());
            }
            return result.ToArray();
        }

        public static void TestSolution()
        {
            var result = FindCommonCharacters(new string[] { "aa", "aa" });
        }
    }
}
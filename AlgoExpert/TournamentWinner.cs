namespace AlgoExpert
{
    internal class TournamentWinner
    {
        public static string GetTournamentWinner(List<List<string>> competitions, List<int> results)
        {
            var winner = new KeyValuePair<string, int>();
            var teamsPoints = new Dictionary<string, int>();

            for (int i = 0; i < competitions.Count; i++)
            {
                int winnerResultIndex = results[i] == 0 ? 1 : 0;
                string winnerTeam = competitions[i][winnerResultIndex];

                if (!teamsPoints.ContainsKey(winnerTeam))
                    teamsPoints[winnerTeam] = 3;
                else
                    teamsPoints[winnerTeam] += 3;

                if (teamsPoints[winnerTeam] > winner.Value)
                    winner = new KeyValuePair<string, int>(winnerTeam, teamsPoints[winnerTeam]);
            }
            return winner.Key;
        }

        public static void TestSolution()
        {
            var competitions = new List<List<string>>()
            {
                new List<string>() { "HTML", "Java" },
                new List<string>() { "Java", "Python" },
                new List<string>() { "Python", "HTML" },
                new List<string>() { "C#", "Python" },
                new List<string>() { "Java", "C#" },
                new List<string>() { "C#", "HTML" },
                new List<string>() { "SQL", "C#" },
                new List<string>() { "HTML", "SQL" },
                new List<string>() { "SQL", "Python" },
                new List<string>() { "SQL", "Java" }
            };
            var results = new List<int>() { 0, 1, 1, 1, 0, 1, 0, 1, 1, 0 };
            var winner = GetTournamentWinner(competitions, results);
        }
    }
}

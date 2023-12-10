namespace AOC_2023_Service.Day02
{
    public class GameList
    {
        private readonly List<Game> games;

        public int NumberOfGames => games.Count;

        private GameList(List<Game> games)
        {
            this.games = games;
        }

        public int SumPossibleGameIds(BallContainer bag)
        {
            return games
                .Select((game, index) => new { Game = game, Index = index + 1 })
                .Where(item => item.Game.IsPossible(bag))
                .Sum(item => item.Index);
        }

        public static GameList CreateGameList(List<string> lines)
        {
            var games = ParseToGameStrings(lines)
                .Select(gameStr => new Game(gameStr))
                .ToList();

            return new GameList(games);
        }

        public static List<string> ParseToGameStrings(List<string> lines)
        {
            return lines
                .Select(line => line.Split(":", StringSplitOptions.TrimEntries)[1])
                .ToList();
        }

        public int CalculateFewestNumberOfCubes()
        {
            int result = 0;
            foreach (var game in games)
            {
                var ballSpecs = CalculateMinNumberOfBalls(game);
                result += ballSpecs.Aggregate(1, (acc, ballSpec) => acc * ballSpec.Count);
            }
            return result;
        }

        private List<BallSpecification> CalculateMinNumberOfBalls(Game game)
        {
            return game.Rounds
                .SelectMany(round => round.ColorToNumbers)
                .GroupBy(ballSpec => ballSpec.Color)
                .Select(group => new BallSpecification(group.Key, group.Max(ballSpec => ballSpec.Count)))
                .ToList();
        }
    }
}


namespace AOC_2023_Service.Day02
{
    public class GameList
    {
        private List<Game> games;
        public int NumberOfGames => games.Count;

        private GameList(List<Game> games)
        {
            this.games = games;
        }

        public int SumPossibleGameIds(BallContainer bag)
        {
            return games
                .Select((game, index) => new { Game = game, Index = index })
                .Where(item => item.Game.IsPossible(bag))
                .Sum(item => item.Index + 1);
        }

        public static GameList CreateGameList(List<string> lines)
        {
            var games = ParseToGameStrings(lines).
                Select(gameStr => new Game(gameStr)).
                ToList();
            return new GameList(games);
        }

        public static List<string> ParseToGameStrings(List<string> lines)
        {
            return lines
                .Select(line => line.Split(":", StringSplitOptions.TrimEntries)[1])
                .ToList();
        }
    }
}

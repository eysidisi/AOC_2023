namespace AOC_2023_Service.Day02
{
    public class Game
    {
        private readonly List<BallContainer> rounds;

        public Game(string gameStr)
        {
            rounds = ParseRounds(gameStr);
        }

        private static List<BallContainer> ParseRounds(string gameStr)
        {
            return gameStr
                .Split(';', StringSplitOptions.RemoveEmptyEntries)
                .Select(roundStr => new BallContainer(roundStr.Trim()))
                .ToList();
        }

        public bool IsPossible(BallContainer bag)
        {
            return rounds.All(round => round.BagHasEnoughBalls(bag));
        }
    }
}

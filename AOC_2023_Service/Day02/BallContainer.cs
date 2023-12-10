
namespace AOC_2023_Service.Day02
{
    public class BallContainer
    {
        private List<BallSpecification> colorToNumbers;
        public IReadOnlyList<BallSpecification> ColorToNumbers => colorToNumbers;


        public BallContainer()
        {
            colorToNumbers = new List<BallSpecification>();
        }

        public BallContainer(string numbersToColors)
        {
            colorToNumbers = BallSpecification.ParseBallSpecifications(numbersToColors);
        }

        public bool BagHasEnoughBalls(BallContainer bag)
        {
            return colorToNumbers.All(colorToNumber => bag.NumberOfBalls(colorToNumber.Color) >= colorToNumber.Count);
        }

        public int NumberOfBalls(string color)
        {
            var matchingColorToNumber = colorToNumbers.Find(colorToNumber => colorToNumber.Color == color);
            return matchingColorToNumber?.Count ?? 0;
        }
    }
}

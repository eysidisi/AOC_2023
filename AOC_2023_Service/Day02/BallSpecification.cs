namespace AOC_2023_Service.Day02
{
    public class BallSpecification
    {
        public string Color { get; }
        public int Count { get; }

        private BallSpecification(string color, int count)
        {
            Color = color;
            Count = count;
        }

        // Parses input such as "4 red, 1 green, 15 blue" and returns a list of BallSpecifications
        public static List<BallSpecification> ParseBallSpecifications(string inputString)
        {
            var ballSpecifications = new List<BallSpecification>();
            var parsed = inputString.Split(',');
            foreach (var specificationString in parsed)
            {
                var ballSpecification = ParseSingleSpecification(specificationString.Trim());
                ballSpecifications.Add(ballSpecification);
            }

            return ballSpecifications;
        }

        private static BallSpecification ParseSingleSpecification(string specificationString)
        {
            var parts = specificationString.Split(' ');
            if (parts.Length != 2)
            {
                throw new ArgumentException("Invalid format for specificationString. Expected format: 'count color'.");
            }

            var color = parts[1];
            var count = int.Parse(parts[0]);

            return new BallSpecification(color, count);
        }
    }
}

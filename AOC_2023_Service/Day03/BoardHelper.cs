

namespace AOC_2023_Service.Day03
{
    public class BoardHelper
    {
        public static int FindPartNumbersSum(Board newBoard)
        {
            var numbers = newBoard.FindNumbers();
            var potentialCoords = newBoard.FindAdjacentCoordsToSymbols();
            int sum = 0;

            foreach (var number in numbers)
            {
                foreach (var potential in potentialCoords)
                {
                    if (number.OverLaps(potential))
                    {
                        sum += number.Val;
                        break;
                    }
                }
            }

            return sum;
        }

        public static char[][] ReadBoard(string filePath)
        {
            var fileContents = File.ReadAllLines(filePath).ToList();

            char[][] actualBoard = new char[fileContents.Count][];
            for (int i = 0; i < fileContents.Count; i++)
            {
                actualBoard[i] = [.. fileContents[i]];
            }

            return actualBoard;
        }

        public static long FindSumGearRatio(Board board)
        {
            List<Coordinate> startCoordinates = board.FindStartCoordinates();
            var numbers = board.FindNumbers();

            long result = 0;

            foreach (var starCoord in startCoordinates)
            {
                var possibleCoords = board.CreateAdjacentCoords(starCoord.X, starCoord.Y);

                var overlappingNumbers =
                    numbers.Where(number =>
                   possibleCoords.Any(number.OverLaps)).ToList();

                if (overlappingNumbers.Count() == 2)
                {
                    result += overlappingNumbers[0].Val * overlappingNumbers[1].Val;
                }
            }
            
            return result;
        }
    }
}

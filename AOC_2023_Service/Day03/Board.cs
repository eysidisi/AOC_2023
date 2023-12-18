namespace AOC_2023_Service.Day03
{
    public class Board
    {
        char[][] board;
        int currentElementFirstDim;
        int currentElementSecondDim;

        public Board(char[][] board)
        {
            this.board = board;
            currentElementFirstDim = 0;
            currentElementSecondDim = 0;
        }

        public List<Coordinate> FindAdjacentCoordsToSymbols()
        {
            var symbolCoordinates = FindSymbolCoords();
            var result = new HashSet<Coordinate>();

            foreach (var symbolCoord in symbolCoordinates)
            {
                var newCoords = CreateAdjacentCoords(symbolCoord.X, symbolCoord.Y);
                newCoords.ForEach(coord => result.Add(coord));
            }

            return result.ToList();
        }

        public List<Number> FindNumbers()
        {
            var result = new List<Number>();

            while (CurrentElement != null)
            {
                if (int.TryParse(CurrentElement, out int _))
                {
                    var numberStartingCoord = new Coordinate(currentElementFirstDim, currentElementSecondDim);

                    while (int.TryParse(PeekNextElementInRow(), out int _))
                    {
                        MoveToNextElement();
                    }

                    var numberEndingCoord = new Coordinate(currentElementFirstDim, currentElementSecondDim);

                    int num = CreateNum(numberStartingCoord, numberEndingCoord);

                    result.Add(new Number(num, numberStartingCoord, numberEndingCoord));
                }

                MoveToNextElement();
            }
            ResetIndices();

            return result;
        }

        private HashSet<Coordinate> FindSymbolCoords()
        {
            var result = new HashSet<Coordinate>();

            while (CurrentElement != null)
            {
                if (int.TryParse(CurrentElement, out int _) == false && CurrentElement != ".")
                {
                    result.Add(new Coordinate(currentElementFirstDim, currentElementSecondDim));
                }

                MoveToNextElement();
            }
            ResetIndices();
            return result;
        }

        private string? PeekNextElementInRow()
        {
            if (currentElementSecondDim >= board[currentElementFirstDim].Length - 1)
            {
                return null;
            }
            return board[currentElementFirstDim][currentElementSecondDim + 1].ToString();
        }

        private int CreateNum(Coordinate startingCoord, Coordinate endingCoord)
        {
            var result = board[startingCoord.X][startingCoord.Y].ToString();

            var y = startingCoord.Y;

            while (y != endingCoord.Y)
            {
                y++;
                result += board[startingCoord.X][y];
            }

            return int.Parse(result);
        }

        private string? CurrentElement
        {
            get
            {
                if (AreIndicesOutBoardOfBoundary())
                {
                    return null;
                }

                return board[currentElementFirstDim][currentElementSecondDim].ToString();
            }
        }

        private void MoveToNextElement()
        {
            if (AreIndicesOutBoardOfBoundary())
            {
                return;
            }

            if (currentElementSecondDim >= board[currentElementFirstDim].Length - 1)
            {
                currentElementFirstDim++;
                currentElementSecondDim = 0;
            }

            else
            {
                currentElementSecondDim++;
            }
        }

        private bool AreIndicesOutBoardOfBoundary()
        {
            return currentElementFirstDim >= board.Length || currentElementSecondDim >= board[currentElementFirstDim].Length;
        }

        private void ResetIndices()
        {
            currentElementFirstDim = 0;
            currentElementSecondDim = 0;
        }
        public List<Coordinate> CreateAdjacentCoords(int dim1, int dim2)
        {
            int left = Math.Max(dim2 - 1, 0);
            int right = Math.Min(dim2 + 1, board[dim1].Length - 1);
            int up = Math.Max(dim1 - 1, 0);
            int down = Math.Min(dim1 + 1, board.Length - 1);

            var result = new List<Coordinate>()
            {
                new Coordinate(dim1,left ),
                new Coordinate(dim1, right),
                new Coordinate(up, dim2),
                new Coordinate(down, dim2),
                new Coordinate(up, left),
                new Coordinate(down, left),
                new Coordinate(up, right),
                new Coordinate(down, right),
            };

            return result.Except(new List<Coordinate>() { new Coordinate(dim1, dim2) }).ToList();
        }

        public List<Coordinate> FindStartCoordinates()
        {
            var result = new HashSet<Coordinate>();

            while (CurrentElement != null)
            {
                if (CurrentElement == "*")
                {
                    result.Add(new Coordinate(currentElementFirstDim, currentElementSecondDim));
                }

                MoveToNextElement();
            }
            ResetIndices();
            
            return result.ToList();
        }
    }
}

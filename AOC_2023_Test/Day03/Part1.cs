using AOC_2023_Service.Day03;
using FluentAssertions;

namespace AOC_2023_Test.Day03
{
    public class Part1
    {
        [Fact]
        public void FindNumbersTest()
        {
            char[][] input =
            [
                ['1', '.', '.'],
                ['/', '.', '.'],
                ['.', '.', '5'],
            ];

            var newBoard = new Board(input);
            var actualNumbers = newBoard.FindNumbers();

            var expectedNumbers = new List<Number>()
            {
                new Number(1,new Coordinate(0,0)),
                new Number(5,new Coordinate(2,2))
            };

            Assert.Equal(2, actualNumbers.Count);
            expectedNumbers.Should().BeEquivalentTo(actualNumbers);
        }

        [Fact]
        public void FindNumbersMultipleDigit()
        {
            char[][] input =
            [
                ['1', '2', '3'],
                ['/', '3', '1'],
                ['.', '.', '5'],
            ];

            var newBoard = new Board(input);
            var actualNumbers = newBoard.FindNumbers();

            var expectedNumbers = new List<Number>()
            {
                new Number(123,new Coordinate(0,0),new Coordinate(0,2)),
                new Number(31,new Coordinate(1,1),new Coordinate(1,2)),
                new Number(5,new Coordinate(2,2),new Coordinate(2,2))
            };

            Assert.Equal(3, actualNumbers.Count);
            expectedNumbers.Should().BeEquivalentTo(actualNumbers);
        }


        [Fact]
        public void FindAdjacentCoords()
        {
            char[][] input =
            [
                ['.', '.', '.'],
                ['.', '#', '.'],
                ['.', '.', '/'],
            ];

            var board = new Board(input);
            var actualPotentialCoords = board.FindAdjacentCoordsToSymbols();

            var expectedPotentialCoords = new List<Coordinate>()
            {
                new Coordinate(0,0),
                new Coordinate(1,0),
                new Coordinate(2,0),
                new Coordinate(0,1),
                new Coordinate(1,1),
                new Coordinate(2,1),
                new Coordinate(0,2),
                new Coordinate(1,2),
                new Coordinate(2,2),
            };

            expectedPotentialCoords.Should().BeEquivalentTo(actualPotentialCoords);
        }

        [Fact]
        public void ReadBoardTest()
        {
            char[][] expectedBoard =
            [
                ['4', '6', '7', '.', '.', '1', '1', '4', '.', '.'],
                ['.', '.', '.', '*', '.', '.', '.', '.', '.', '.'],
                ['.', '.', '3', '5', '.', '.', '6', '3', '3', '.'],
                ['.', '.', '.', '.', '.', '.', '#', '.', '.', '.'],
                ['6', '1', '7', '*', '.', '.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.', '+', '.', '5', '8', '.'],
                ['.', '.', '5', '9', '2', '.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.', '.', '7', '5', '5', '.'],
                ['.', '.', '.', '$', '.', '*', '.', '.', '.', '.'],
                ['.', '6', '6', '4', '.', '5', '9', '8', '.', '.'],
            ];

            var filePath = Path.Combine(AppContext.BaseDirectory, "Day03/SmallBoard.txt");
            var actualBoard = BoardHelper.ReadBoard(filePath);
            expectedBoard.Should().BeEquivalentTo(actualBoard);
        }


        [Fact]
        public void FindPartNumbersSum()
        {
            char[][] input =
            [
                ['1', '.', '.'],
                ['/', '.', '.'],
                ['.', '.', '5'],
            ];

            var board = new Board(input);
            var actualSum = BoardHelper.FindPartNumbersSum(board);

            Assert.Equal(1, actualSum);
        }

        [Fact]
        public void AcceptanceTest_SmallInput()
        {
            char[][] input =
            [
                ['4', '6', '7', '.', '.', '1', '1', '4', '.', '.'],
                ['.', '.', '.', '*', '.', '.', '.', '.', '.', '.'],
                ['.', '.', '3', '5', '.', '.', '6', '3', '3', '.'],
                ['.', '.', '.', '.', '.', '.', '#', '.', '.', '.'],
                ['6', '1', '7', '*', '.', '.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.', '+', '.', '5', '8', '.'],
                ['.', '.', '5', '9', '2', '.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.', '.', '7', '5', '5', '.'],
                ['.', '.', '.', '$', '.', '*', '.', '.', '.', '.'],
                ['.', '6', '6', '4', '.', '5', '9', '8', '.', '.'],
            ];

            var board = new Board(input);
            var actualSum = BoardHelper.FindPartNumbersSum(board); 

            Assert.Equal(4361, actualSum);
        }

        [Fact]
        public void AcceptanceTest_FullInput()
        {
            var filePath = Path.Combine(AppContext.BaseDirectory, "Day03/Input.txt");
            var boardArr = BoardHelper.ReadBoard(filePath);
            var board = new Board(boardArr);

            var sum = BoardHelper.FindPartNumbersSum(board);

            Assert.Equal(531932, sum);
        }
    }
}

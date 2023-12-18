using AOC_2023_Service.Day03;
using FluentAssertions;
using System.Text;
using Xunit;

namespace AOC_2023_Test.Day03
{
    public class Part2
    {
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

            Board newBoard = new Board(input);

            long actualSum = BoardHelper.FindSumGearRatio(newBoard);

            Assert.Equal(467835, actualSum);
        }

        [Fact]
        public void AcceptanceTest_FullInput()
        {
            var filePath = Path.Combine(AppContext.BaseDirectory, "Day03/Input.txt");
            var boardArr = BoardHelper.ReadBoard(filePath);
            var board = new Board(boardArr);

            var sum = BoardHelper.FindSumGearRatio(board);

            Assert.Equal(73646890, sum);
        }
    }
}

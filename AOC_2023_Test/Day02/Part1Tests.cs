using AOC_2023_Service.Day02;
using FluentAssertions;
using System.Text;
using Xunit;

namespace AOC_2023_Test.Day02
{
    public class RoundTests
    {
        [Fact]
        public void EmptyBag_NonEmptyRound_ShouldBeFalse()
        {
            // Arrange
            var round = new BallContainer("1 red");
            var bag = new BallContainer();

            // Act
            bool actualResult = round.BagHasEnoughBalls(bag);

            // Assert
            actualResult.Should().BeFalse();
        }

        [Fact]
        public void SingleBallInBagAndRoundOfSameColor_ShouldBeTrue()
        {
            // Arrange
            var round = new BallContainer("1 red");
            var bag = new BallContainer("1 red");

            // Act
            bool actualResult = round.BagHasEnoughBalls(bag);

            // Assert
            actualResult.Should().BeTrue();
            bag.NumberOfBalls("red").Should().Be(1);
            bag.NumberOfBalls("green").Should().Be(0);
        }

        [Theory]
        [InlineData("2 red, 3 green", "3 green", false, 0, 3)]
        [InlineData("2 red", "3 green,2 red", true, 2, 3)]
        [InlineData("2 red, 3 green", "3 green,2 red", true, 2, 3)]
        [InlineData("3 red, 2 green", "3 green,2 red", false, 2, 3)]
        public void DifferentColorCombinations_ShouldReturnExpectedResults(
            string roundInput, string bagInput, bool expectedIsPossible, int expectedRedCount, int expectedGreenCount)
        {
            // Arrange
            var round = new BallContainer(roundInput);
            var bag = new BallContainer(bagInput);

            // Act
            bool actualResult = round.BagHasEnoughBalls(bag);

            // Assert
            actualResult.Should().Be(expectedIsPossible);
            bag.NumberOfBalls("red").Should().Be(expectedRedCount);
            bag.NumberOfBalls("green").Should().Be(expectedGreenCount);
        }

        [Theory]
        [InlineData("3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", "12 red, 13 green, 14 blue")]
        [InlineData("1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue", "12 red, 13 green, 14 blue")]
        [InlineData("6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green", "12 red, 13 green, 14 blue")]
        public void SomePossibleGames_ShouldBePossible(string gameStr, string bagStr)
        {
            // Act
            var game = new Game(gameStr);
            var bag = new BallContainer(bagStr);

            // Assert
            game.IsPossible(bag).Should().BeTrue();
        }

        [Theory]
        [InlineData("8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red", "12 red, 13 green, 14 blue")]
        [InlineData("1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red", "12 red, 13 green, 14 blue")]
        public void SomeNotPossibleGames_ShouldNotBePossible(string gameStr, string bagStr)
        {
            // Act
            var game = new Game(gameStr);
            var bag = new BallContainer(bagStr);

            // Assert
            game.IsPossible(bag).Should().BeFalse();
        }

        [Fact]
        public void FileParser_ShouldParseToGameStrings()
        {
            // Arrange
            string filePath = Path.Combine(AppContext.BaseDirectory, "Day02/FiveGames.txt");
            var fileContents = File.ReadAllLines(filePath).ToList();

            // Act
            List<string> actualContents = GameList.ParseToGameStrings(fileContents);

            // Assert
            actualContents.Should().BeEquivalentTo(
                "3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
                "1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
                "8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
                "1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
                "6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green");
        }

        [Fact]
        public void CreateGameListTest()
        {
            // Arrange
            string filePath = Path.Combine(AppContext.BaseDirectory, "Day02/FiveGames.txt");
            var fileContents = File.ReadAllLines(filePath).ToList();
            var gameList = GameList.CreateGameList(fileContents);

            // Assert
            gameList.NumberOfGames.Should().Be(5);
        }

        [Fact]
        public void CalculateSumOfIds()
        {
            // Arrange
            string filePath = Path.Combine(AppContext.BaseDirectory, "Day02/FiveGames.txt");
            var fileContents = File.ReadAllLines(filePath).ToList();
            var gameList = GameList.CreateGameList(fileContents);

            var bag = new BallContainer("12 red, 13 green, 14 blue");

            // Act
            int sum = gameList.SumPossibleGameIds(bag);

            // Assert
            sum.Should().Be(8);
        }

        [Fact]
        public void AcceptanceCase()
        {
            // Arrange
            string filePath = Path.Combine(AppContext.BaseDirectory, "Day02/Input.txt");
            var fileContents = File.ReadAllLines(filePath).ToList();
            var gameList = GameList.CreateGameList(fileContents);

            var bag = new BallContainer("12 red, 13 green, 14 blue");

            // Act
            int sum = gameList.SumPossibleGameIds(bag);

            // Assert
            sum.Should().Be(2237);
        }
    }
}

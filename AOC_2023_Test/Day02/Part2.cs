using AOC_2023_Service.Day02;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace AOC_2023_Test.Day02
{
    public class Part2
    {
        [Fact]
        public void CalculateFewestNumberOfCubes_OneGame_ShouldReturnCorrectResult()
        {
            // Arrange
            string gameListStr = "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green";
            var gameList = GameList.CreateGameList(new List<string> { gameListStr });

            // Act
            int result = gameList.CalculateFewestNumberOfCubes();

            // Assert
            result.Should().Be(48);
        }

        [Fact]
        public void CalculateFewestNumberOfCubes_FiveGamesFromFile_ShouldReturnCorrectResult()
        {
            // Arrange
            string filePath = Path.Combine(AppContext.BaseDirectory, "Day02/FiveGames.txt");
            var fileContents = File.ReadAllLines(filePath);
            var gameList = GameList.CreateGameList(new List<string>(fileContents));

            // Act
            int result = gameList.CalculateFewestNumberOfCubes();

            // Assert
            result.Should().Be(2286);
        }

        [Fact]
        public void AcceptanceCase()
        {
            // Arrange
            string filePath = Path.Combine(AppContext.BaseDirectory, "Day02/Input.txt");
            var fileContents = File.ReadAllLines(filePath).ToList();
            var gameList = GameList.CreateGameList(fileContents);

            // Act
            int result = gameList.CalculateFewestNumberOfCubes();

            // Assert
            result.Should().Be(66681);
        }

    }
}

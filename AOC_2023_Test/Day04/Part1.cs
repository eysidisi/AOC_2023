using AOC_2023_Service.Day04;
using FluentAssertions;

namespace AOC_2023_Test.Day04
{
    public class Part1
    {
        [Fact]
        public void CalculateScore_NoNumbers()
        {
            List<int> winningNumbers = new List<int>();
            List<int> numbersIHave = new List<int>();
            var card = CreateCard(winningNumbers, numbersIHave);

            int actualScore = card.CalculatePoints();

            Assert.Equal(0, actualScore);
        }

        [Fact]
        public void CalculateScore_NoMatches()
        {
            List<int> winningNumbers = new List<int>() { 1 };
            List<int> numbersIHave = new List<int>() { 2 };
            var card = CreateCard(winningNumbers, numbersIHave);

            int actualScore = card.CalculatePoints();

            Assert.Equal(0, actualScore);
        }

        [Fact]
        public void CalculateScore_OneMatch()
        {
            List<int> winningNumbers = new List<int>() { 1, 2, 3 };
            List<int> numbersIHave = new List<int>() { 1, 5 };
            var card = CreateCard(winningNumbers, numbersIHave);

            int actualScore = card.CalculatePoints();

            Assert.Equal(1, actualScore);
        }

        [Fact]
        public void CalculateScore_ThreeMatches()
        {
            List<int> winningNumbers = new List<int>() { 1, 2, 3 };
            List<int> numbersIHave = new List<int>() { 1, 2, 3 };
            var card = CreateCard(winningNumbers, numbersIHave);

            int actualScore = card.CalculatePoints();

            Assert.Equal(4, actualScore);
        }

        [Fact]
        public void ConvertStringToCard()
        {
            string cardStr = "Card   1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53";

            List<int> winningNumbers = new List<int>()
            {
                41,48,83,86,17
            };

            List<int> numbersIHave = new List<int>()
            {
                83, 86,6,31,17,9,48,53
            };

            Card expectedCard = CreateCard(winningNumbers, numbersIHave);

            Card actualCard = CardParser.ParseCard(cardStr);

            Assert.True(expectedCard.Equals(actualCard));
            Assert.Equal(1, actualCard.Id);
        }

        [Fact]
        public void CalculateTotalScore_SmallInput()
        {
            List<Card> cards = CardParser.ReadCards("Day04/SmallInput.txt");
            int sum = GetTotalScoreOfCards(cards);
            Assert.Equal(13, sum);
        }

        [Fact]
        public void AcceptanceTest_FullInput()
        {
            List<Card> cards = CardParser.ReadCards("Day04/Input.txt");
            int sum = GetTotalScoreOfCards(cards);
            Assert.Equal(27845, sum);
        }

        private static int GetTotalScoreOfCards(List<Card> cards)
        {
            int sum = 0;

            foreach (var card in cards)
            {
                sum += card.CalculatePoints();
            }

            return sum;
        }

        private Card CreateCard(List<int> winningNumbers, List<int> numbersIHave)
        {
            return new Card(winningNumbers, numbersIHave);
        }
    }
}

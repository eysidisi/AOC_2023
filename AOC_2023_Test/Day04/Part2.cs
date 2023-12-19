using FluentAssertions;
using AOC_2023_Service.Day04;

namespace AOC_2023_Test.Day04
{
    public class Part2
    {
        [Fact]
        public void NoMatchIncard_ReturnsEmpty()
        {
            string cardStr = "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11";
            var card = CardParser.ParseCard(cardStr);
            List<int> cards = card.CalculateWonCardIds();
            Assert.Empty(cards);
        }

        [Fact]
        public void TwoMatchesInCard_ReturnsTwoConsecutiveIds()
        {
            var cardStr = "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19";
            var card = CardParser.ParseCard(cardStr);

            var cardIds = card.CalculateWonCardIds();
            var expectedIds = new List<int>()
            {
                3,4
            };

            expectedIds.Should().BeEquivalentTo(cardIds);
        }

        [Fact]
        public void CalculateTotalNumberOfCards_SmallInput()
        {
            Dictionary<int, int> cardIdToNumber = CalculateCardIdsToNumbers("Day04/SmallInput.txt");
            Assert.Equal(30, cardIdToNumber.Values.Sum());
        }

        [Fact]
        public void CalculateTotalNumberOfCards_Normal()
        {
            Dictionary<int, int> cardIdToNumber = CalculateCardIdsToNumbers("Day04/Input.txt");
            Assert.Equal(9496801, cardIdToNumber.Values.Sum());
        }

        private Dictionary<int, int> CalculateCardIdsToNumbers(string fileName)
        {
            List<Card> cards = CardParser.ReadCards(fileName);
            int maxId = cards.Select(c => c.Id).Max();
            int minId = cards.Select(c => c.Id).Min();

            Dictionary<int, int> cardIdToNumber = new Dictionary<int, int>();

            for (int i = minId; i <= maxId; i++)
            {
                cardIdToNumber.Add(i, 1);
            }

            foreach (var card in cards)
            {
                int numberOfCards = cardIdToNumber[card.Id];

                var createdCardIs = card.CalculateWonCardIds();

                foreach (var createdCardId in createdCardIs)
                {
                    cardIdToNumber[createdCardId] += numberOfCards;
                }
            }

            return cardIdToNumber;
        }
    }
}

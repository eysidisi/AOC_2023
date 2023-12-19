
namespace AOC_2023_Service.Day04
{
    public class CardParser
    {
        public static Card ParseCard(string cardStr)
        {
            List<int> winningNumbers = ParseWinningNumbers(cardStr);
            List<int> numbersIHave = ParseNumbersIHave(cardStr);
            int cardId = ParseCardId(cardStr);
            return new Card(winningNumbers, numbersIHave, cardId);
        }

        private static int ParseCardId(string cardStr)
        {
            var cardAndId = cardStr.Split(':', StringSplitOptions.TrimEntries)[0];
            var cardId = cardAndId.Split(' ', StringSplitOptions.RemoveEmptyEntries)[1];
            return int.Parse(cardId);
        }

        public static List<Card> ReadCards(string fileName)
        {
            var filePath = Path.Combine(AppContext.BaseDirectory, fileName);

            var fileContents = File.ReadAllLines(filePath).ToList();

            List<Card> cards = new List<Card>();

            foreach (var cardStr in fileContents)
            {
                cards.Add(ParseCard(cardStr));
            }

            return cards;
        }

        private static List<int> ParseNumbersIHave(string cardStr)
        {
            var numbers = cardStr.Split(':', StringSplitOptions.TrimEntries)[1];
            var winningNumbersStr = numbers.Split('|')[1];

            List<int> result = new List<int>();

            foreach (var number in winningNumbersStr.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            {
                result.Add(int.Parse(number));
            }

            return result;
        }

        private static List<int> ParseWinningNumbers(string cardStr)
        {
            var numbers = cardStr.Split(':', StringSplitOptions.TrimEntries)[1];
            var winningNumbersStr = numbers.Split('|')[0];

            List<int> result = new List<int>();

            foreach (var number in winningNumbersStr.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            {
                result.Add(int.Parse(number));
            }

            return result;
        }
    }
}
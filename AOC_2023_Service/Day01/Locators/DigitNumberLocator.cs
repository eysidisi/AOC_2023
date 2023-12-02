using AOC_2023_Service.Day1.NumericPairs;

namespace AOC_2023_Service.Day1.Locators
{
    public static class DigitNumberLocator
    {
        public static NumberIndexPair? FindFirstNumber(string str)
        {
            var result = str
                .Select((ch, i) => new { Char = ch, Index = i })
                .FirstOrDefault(item => char.IsDigit(item.Char));

            return result != null
                ? new NumberIndexPair(int.Parse(result.Char.ToString()), result.Index)
                : null;
        }

        public static NumberIndexPair? FindLastNumber(string str)
        {
            var result = str
                .Select((ch, i) => new { Char = ch, Index = i })
                .LastOrDefault(item => char.IsDigit(item.Char));

            return result != null
                ? new NumberIndexPair(int.Parse(result.Char.ToString()), result.Index)
                : null;
        }
    }
}

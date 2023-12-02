

namespace AOC_2023_Service.Day1
{
    internal class IntDigitFinder
    {
        public IntDigitFinder()
        {
        }

        public NumberAndIndex? FindFirstNumber(string str)
        {
            var result = str
                .Select((ch, i) => new { Char = ch, Index = i })
                .FirstOrDefault(item => char.IsDigit(item.Char));

            return result != null
                ? new NumberAndIndex(int.Parse(result.Char.ToString()), result.Index)
                : null;
        }

        public NumberAndIndex? FindLastNumber(string str)
        {
            var result = str
                .Select((ch, i) => new { Char = ch, Index = i })
                .LastOrDefault(item => char.IsDigit(item.Char));

            return result != null
                ? new NumberAndIndex(int.Parse(result.Char.ToString()), result.Index)
                : null;
        }
    }
}

using AOC_2023_Service.Day01.NumericPairs;

namespace AOC_2023_Service.Day01.Locators
{
    public static class StringNumberLocator
    {
        public static NumberIndexPair? FindFirstNumber(string firstStr)
        {
            NumberIndexPair? result = null;

            foreach (var numberObj in NumberStringPair.GetNumberObjects())
            {
                int currentNumberIndex = firstStr.IndexOf(numberObj.StrVal);
                if (NumberStringExists(currentNumberIndex) && ComesBeforeTheResult(result, currentNumberIndex))
                {
                    result = new NumberIndexPair(numberObj.IntVal, currentNumberIndex);
                }
            }

            return result;
        }

        public static NumberIndexPair? FindLastNumber(string firstStr)
        {
            NumberIndexPair? result = null;

            foreach (var numberObj in NumberStringPair.GetNumberObjects())
            {
                int currentNumberIndex = firstStr.LastIndexOf(numberObj.StrVal);
                if (NumberStringExists(currentNumberIndex) && ComesAfterTheResult(result, currentNumberIndex))
                {
                    result = new NumberIndexPair(numberObj.IntVal, currentNumberIndex);
                }
            }

            return result;
        }

        private static bool ComesAfterTheResult(NumberIndexPair? result, int currentNumberIndex)
        {
            return result == null || result.Index < currentNumberIndex;
        }

        private static bool NumberStringExists(int currentNumberIndex)
        {
            return currentNumberIndex > -1;
        }

        private static bool ComesBeforeTheResult(NumberIndexPair? result, int currentNumberIndex)
        {
            return result == null || result.Index > currentNumberIndex;
        }
    }
}

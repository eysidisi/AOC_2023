
namespace AOC_2023_Service.Day1
{
    public class StringDigitFinder
    {
        private readonly List<NumberObject> numberObjects;

        public StringDigitFinder()
        {
            numberObjects = NumberObjectFactory.CreateNumberObjects();
        }

        public NumberAndIndex? FindFirstNumber(string firstStr)
        {
            NumberAndIndex? result = null;

            foreach (var numberObj in numberObjects)
            {
                int currentNumberIndex = firstStr.IndexOf(numberObj.StrVal);
                if (NumberStringExists(currentNumberIndex) && ComesBeforeTheResult(result, currentNumberIndex))
                {
                    result = new NumberAndIndex(numberObj.IntVal, currentNumberIndex);
                }
            }

            return result;
        }

        public NumberAndIndex? FindLastNumber(string firstStr)
        {
            NumberAndIndex? result = null;

            foreach (var numberObj in numberObjects)
            {
                int currentNumberIndex = firstStr.IndexOf(numberObj.StrVal);
                if (NumberStringExists(currentNumberIndex) && ComesAfterTheResult(result, currentNumberIndex))
                {
                    result = new NumberAndIndex(numberObj.IntVal, currentNumberIndex);
                }
            }

            return result;
        }

        private bool ComesAfterTheResult(NumberAndIndex? result, int currentNumberIndex)
        {
            return (result == null || result.Index < currentNumberIndex);
        }

        private bool NumberStringExists(int currentNumberIndex)
        {
            return currentNumberIndex > -1;
        }

        private bool ComesBeforeTheResult(NumberAndIndex result, int currentNumberIndex)
        {
            return (result == null || result.Index > currentNumberIndex);
        }
    }
}

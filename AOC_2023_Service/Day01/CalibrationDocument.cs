using AOC_2023_Service.Day01.Locators;
using AOC_2023_Service.Day01.NumericPairs;

namespace AOC_2023_Service.Day01
{
    public class CalibrationDocument
    {
        public int CalculatePart1TotalCalibrationValue(List<string> input)
        {
            var result = 0;

            foreach (string str in input)
            {
                result += CalculatePart1CalibrationForString(str);
            }
            return result;
        }

        private int CalculatePart1CalibrationForString(string str)
        {
            var firstNum = DigitNumberLocator.FindFirstNumber(str);
            var lastNum = DigitNumberLocator.FindLastNumber(str);

            if (firstNum == null || lastNum == null)
            {
                throw new IncorrectInputException();
            }

            return CombineDigits(firstNum.Number, lastNum.Number);
        }

        public int CalculatePart2TotalCalibrationValue(List<string> input)
        {
            var result = 0;

            foreach (string str in input)
            {
                result += CalculatePart2CalibrationForString(str);
            }
            return result;
        }

        private int CalculatePart2CalibrationForString(string str)
        {
            var firstStringNumAndIndex = StringNumberLocator.FindFirstNumber(str);
            var lastStringNumAndIndex = StringNumberLocator.FindLastNumber(str);

            var firstDigitNumberAndIndex = DigitNumberLocator.FindFirstNumber(str);
            var lastDigitNumAndIndex = DigitNumberLocator.FindLastNumber(str);

            if (InvalidInput(firstStringNumAndIndex, lastStringNumAndIndex, firstDigitNumberAndIndex, lastDigitNumAndIndex))
            {
                throw new IncorrectInputException();
            }

            int firstNum = GetFirstNumber(firstStringNumAndIndex, firstDigitNumberAndIndex);
            int lastNum = GetLastNumber(lastStringNumAndIndex, lastDigitNumAndIndex);

            return CombineDigits(firstNum, lastNum);
        }

        private int GetLastNumber(NumberIndexPair? numberAndIndex1, NumberIndexPair? numberAndIndex2)
        {
            if (numberAndIndex1 == null)
            {
                return numberAndIndex2.Number;
            }
            if (numberAndIndex2 == null)
            {
                return numberAndIndex1.Number;
            }
            return numberAndIndex1.Index > numberAndIndex2.Index ? numberAndIndex1.Number : numberAndIndex2.Number;
        }

        private int GetFirstNumber(NumberIndexPair? numberAndIndex1, NumberIndexPair? numberAndIndex2)
        {
            if (numberAndIndex1 == null)
            {
                return numberAndIndex2.Number;
            }
            if (numberAndIndex2 == null)
            {
                return numberAndIndex1.Number;
            }
            return numberAndIndex1.Index < numberAndIndex2.Index ? numberAndIndex1.Number : numberAndIndex2.Number;
        }

        private bool InvalidInput(NumberIndexPair? firstStringNum, NumberIndexPair? lastStringNumber, NumberIndexPair? firstDigitNum, NumberIndexPair? lastDigitNum)
        {
            return (firstDigitNum == null && firstStringNum == null) || (lastDigitNum == null && lastStringNumber == null);
        }

        private int CombineDigits(int firstNum, int secondNum)
        {
            return int.Parse($"{firstNum}{secondNum}");
        }
    }
}

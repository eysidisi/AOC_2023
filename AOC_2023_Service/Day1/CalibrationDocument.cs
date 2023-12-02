


namespace AOC_2023_Service.Day1
{
    public class CalibrationDocument
    {
        public int FindTotalCalibrationValueV1(List<string> input)
        {
            var result = 0;

            foreach (string str in input)
            {
                result += FindCalibrationForStringV1(str);
            }
            return result;
        }

        public int FindTotalCalibrationValueV2(List<string> input)
        {
            var result = 0;

            foreach (string str in input)
            {
                result += FindCalibrationForStringV2(str);
            }
            return result;
        }

        private int FindCalibrationForStringV2(string str)
        {
            var finder = new StringDigitFinder();
            var firstStringNumAndIndex = finder.FindFirstNumber(str);
            var lastStringNumAndIndex = finder.FindLastNumber(str);

            var intDigitFinder = new IntDigitFinder();
            var firstDigitNumberAndIndex = intDigitFinder.FindFirstNumber(str);
            var lastDigitNumAndIndex = intDigitFinder.FindLastNumber(str);

            if (InvalidInput(firstStringNumAndIndex, lastStringNumAndIndex, firstDigitNumberAndIndex, lastDigitNumAndIndex))
            {
                throw new IncorrectInputException();
            }

            int firstNum = GetFirstNumber(firstStringNumAndIndex, firstDigitNumberAndIndex);
            int lastNum = GetLastNumber(lastStringNumAndIndex, lastDigitNumAndIndex);

            return ConcatNumbers(firstNum, lastNum);
        }

        private int GetLastNumber(NumberAndIndex? numberAndIndex1, NumberAndIndex? numberAndIndex2)
        {
            if (numberAndIndex1 == null)
            {
                return numberAndIndex2.Val;
            }
            if (numberAndIndex2 == null)
            {
                return numberAndIndex1.Val;
            }
            return numberAndIndex1.Index > numberAndIndex2.Index ? numberAndIndex1.Val : numberAndIndex2.Val;
        }

        private int GetFirstNumber(NumberAndIndex? numberAndIndex1, NumberAndIndex? numberAndIndex2)
        {
            if (numberAndIndex1 == null)
            {
                return numberAndIndex2.Val;
            }
            if (numberAndIndex2 == null)
            {
                return numberAndIndex1.Val;
            }
            return numberAndIndex1.Index < numberAndIndex2.Index ? numberAndIndex1.Val : numberAndIndex2.Val;
        }

        private static bool InvalidInput(NumberAndIndex? firstStringNum, NumberAndIndex? lastStringNumber, NumberAndIndex? firstDigitNum, NumberAndIndex? lastDigitNum)
        {
            return (firstDigitNum == null && firstStringNum == null) || (lastDigitNum == null && lastStringNumber == null);
        }

        private int FindCalibrationForStringV1(string str)
        {
            var intDigitFinder = new IntDigitFinder();
            var firstNum = intDigitFinder.FindFirstNumber(str);
            var lastNum = intDigitFinder.FindLastNumber(str);

            if (firstNum == null || lastNum == null)
            {
                throw new IncorrectInputException();
            }

            return ConcatNumbers(firstNum.Val, lastNum.Val);
        }

        private int ConcatNumbers(int firstNum, int secondNum)
        {
            return int.Parse(firstNum.ToString() + secondNum.ToString());
        }
    }
}

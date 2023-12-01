namespace AOC_2023_Service.Day1
{
    public class CalibrationDocument
    {
        public int FindTotalCalibrationValue(List<string> input)
        {
            var result = 0;

            foreach (string str in input)
            {
                result += FindCalibrationForString(str);
            }
            return result;
        }

        private int FindCalibrationForString(string str)
        {
            try
            {
                var firstNum = FindFirstNumber(str);
                var secondNum = FindLastNumber(str);
                return ConcatNumbers(firstNum, secondNum);
            }
            catch (InvalidOperationException ex)
            {
                throw new IncorrectInputException(ex.Message);
            }
        }

        private char FindFirstNumber(string str)
        {
            return str.First(ch => int.TryParse(ch.ToString(), out int _));
        }

        private char FindLastNumber(string str)
        {
            return str.Last(ch => int.TryParse(ch.ToString(), out int _));
        }

        private int ConcatNumbers(char firstNum, char secondNum)
        {
            return int.Parse($"{firstNum}{secondNum}");
        }
    }
}

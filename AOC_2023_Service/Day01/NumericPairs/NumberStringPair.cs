namespace AOC_2023_Service.Day01.NumericPairs
{
    public class NumberStringPair
    {
        private static List<NumberStringPair>? _numberObjects;

        public int IntVal { get; private set; }
        public string StrVal { get; private set; }

        private NumberStringPair(int integerVal, string strVal)
        {
            IntVal = integerVal;
            StrVal = strVal;
        }

        public static List<NumberStringPair> GetNumberObjects()
        {
            if (_numberObjects == null)
            {
                InitializeNumberObjects();
            }
            return _numberObjects;
        }

        private static void InitializeNumberObjects()
        {
            _numberObjects = new List<NumberStringPair>()
            {
                new NumberStringPair(1, "one"),
                new NumberStringPair(2, "two"),
                new NumberStringPair(3, "three"),
                new NumberStringPair(4, "four"),
                new NumberStringPair(5, "five"),
                new NumberStringPair(6, "six"),
                new NumberStringPair(7, "seven"),
                new NumberStringPair(8, "eight"),
                new NumberStringPair(9, "nine"),
            };
        }
    }
}

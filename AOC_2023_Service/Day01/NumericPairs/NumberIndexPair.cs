namespace AOC_2023_Service.Day1.NumericPairs
{
    public class NumberIndexPair
    {
        public int Number { get; private set; }
        public int Index { get; private set; }

        public NumberIndexPair(int number, int index)
        {
            Number = number;
            Index = index;
        }
    }
}

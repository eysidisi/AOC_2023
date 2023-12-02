namespace AOC_2023_Service.Day1
{
    public class NumberAndIndex
    {
        public int Val { get; private set; }
        public int Index { get; private set; }

        public NumberAndIndex(int intVal, int currentNumberIndex)
        {
            Val = intVal;
            Index = currentNumberIndex;
        }
    }
}

namespace AOC_2023_Service.Day1
{
    public class NumberObject
    {
        public int IntVal { get; private set; }
        public string StrVal { get; private set; }

        public NumberObject(int integerVal, string strVal)
        {
            IntVal = integerVal;
            StrVal = strVal;
        }
    }
}

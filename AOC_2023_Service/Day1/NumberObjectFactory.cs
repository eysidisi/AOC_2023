namespace AOC_2023_Service.Day1
{
    public class NumberObjectFactory
    {
        public static List<NumberObject> CreateNumberObjects()
        {
            var numberObjects = new List<NumberObject>()
            {
                new NumberObject(1, "one"),
                new NumberObject(2, "two"),
                new NumberObject(3, "three"),
                new NumberObject(4, "four"),
                new NumberObject(5, "five"),
                new NumberObject(6, "six"),
                new NumberObject(7, "seven"),
                new NumberObject(8, "eight"),
                new NumberObject(9, "nine"),
            };
            return numberObjects;
        }
    }
}

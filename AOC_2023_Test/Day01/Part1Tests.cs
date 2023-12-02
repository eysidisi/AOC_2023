using AOC_2023_Service.Day1;
using System.Collections;

namespace AOC_2023_Test.Day1
{
    public class Part1Tests
    {
        private readonly CalibrationDocument calibrationDocument;

        public Part1Tests()
        {
            calibrationDocument = new CalibrationDocument();
        }

        [Theory]
        [ClassData(typeof(OneElementTestData))]
        public void OneElement(List<string> input, int expectedOutput)
        {
            if (expectedOutput >= 0)
            {
                int actualResult = calibrationDocument.CalculatePart1TotalCalibrationValue(input);
                Assert.Equal(expectedOutput, actualResult);
            }
            else
            {
                Assert.Throws<IncorrectInputException>(() => calibrationDocument.CalculatePart1TotalCalibrationValue(input));
            }
        }

        [Theory]
        [ClassData(typeof(MultipleElementTestData))]
        public void MultipleElement(List<string> input, int expectedOutput)
        {
            if (expectedOutput >= 0)
            {
                int actualResult = calibrationDocument.CalculatePart1TotalCalibrationValue(input);
                Assert.Equal(expectedOutput, actualResult);
            }
            else
            {
                Assert.Throws<IncorrectInputException>(() => calibrationDocument.CalculatePart1TotalCalibrationValue(input));
            }
        }

        [Fact]
        public void AcceptanceCase()
        {
            string filePath = Path.Combine(AppContext.BaseDirectory, "Day1/Input_1.txt");
            var fileContents = File.ReadAllLines(filePath).ToList();
            var actualResult = calibrationDocument.CalculatePart1TotalCalibrationValue(fileContents);

            Assert.Equal(53921, actualResult);
        }

        public class OneElementTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { new List<string> { "1" }, 11 };
                yield return new object[] { new List<string> { "1a2" }, 12 };
                yield return new object[] { new List<string> { "a" }, -1 }; // Indicate that an exception is expected
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        public class MultipleElementTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { new List<string> { "1", "1a2" }, 23 };
                yield return new object[]
                {
                    new List<string>
                    {
                        "1abc2",
                        "pqr3stu8vwx",
                        "a1b2c3d4e5f",
                        "treb7uchet"
                    },
                    142
                };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

    }
}

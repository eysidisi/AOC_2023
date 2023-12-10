using AOC_2023_Service.Day01;
using System.Collections;

namespace AOC_2023_Test.Day01
{
    public class Part2
    {
        private readonly CalibrationDocument calibrationDocument;

        public Part2()
        {
            calibrationDocument = new CalibrationDocument();
        }

        [Theory]
        [ClassData(typeof(OneElementTestData))]
        public void OneElement(List<string> input, int expectedOutput)
        {
            if (expectedOutput >= 0)
            {
                int actualResult = calibrationDocument.CalculatePart2TotalCalibrationValue(input);
                Assert.Equal(expectedOutput, actualResult);
            }
            else
            {
                Assert.Throws<IncorrectInputException>(() => calibrationDocument.CalculatePart2TotalCalibrationValue(input));
            }
        }

        [Theory]
        [ClassData(typeof(MultipleElementTestData))]
        public void MultipleElement(List<string> input, int expectedOutput)
        {
            if (expectedOutput >= 0)
            {
                int actualResult = calibrationDocument.CalculatePart2TotalCalibrationValue(input);
                Assert.Equal(expectedOutput, actualResult);
            }
            else
            {
                Assert.Throws<IncorrectInputException>(() => calibrationDocument.CalculatePart2TotalCalibrationValue(input));
            }
        }

        [Fact]
        public void AcceptanceTest()
        {
            string filePath = Path.Combine(AppContext.BaseDirectory, "Day1/Input_1.txt");
            var fileContents = File.ReadAllLines(filePath).ToList();
            var actualResult = calibrationDocument.CalculatePart2TotalCalibrationValue(fileContents);

            Assert.Equal(54676, actualResult);
        }

        public class OneElementTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { new List<string> { "one" }, 11 };
                yield return new object[] { new List<string> { "twothree" }, 23 };
                yield return new object[] { new List<string> { "fourfivesixseveneight" }, 48 };
                yield return new object[] { new List<string> { "fivesixasdnine" }, 59 };
                yield return new object[] { new List<string> { "a" }, -1 }; // Indicate that an exception is expected
                yield return new object[] { new List<string> { "1six" }, 16 };
                yield return new object[] { new List<string> { "1atwo" }, 12 };
                yield return new object[] { new List<string> { "67mcmfive1sixonefive" }, 65 };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        public class MultipleElementTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { new List<string> { "asdsix", "sevenasdfxesixasdeightaaa" }, (66 + 78) };
                yield return new object[]
                {
                    new List<string>
                    {
                        "two1nine",
                        "eightwothree",
                        "abcone2threexyz",
                        "xtwone3four",
                        "4nineeightseven2",
                        "zoneight234",
                        "7pqrstsixteen"
                    },
                        281
                    };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

    }
}

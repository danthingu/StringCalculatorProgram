using Moq;
using NUnit.Framework;
using StringCalculatorMainProgram;
using StringCalculatorMainProgram.Services;
using StringCalculatorMainProgram.Shares;

namespace StringCalculatorTestProgram
{
    public class Tests
    {
        private StringCalculatorMainApplication _stringCalculatorMainApplication;

        [SetUp]
        public void SetUp()
        {
            Mock<DetectDelimitersService> mockDelimiterService = new Mock<DetectDelimitersService>();
            Mock<DetectNegativeNumbersService> mockDetectNegativeNumbersService = new Mock<DetectNegativeNumbersService>();
            Mock<ValidateNumberService> mockValidateNumberService = new Mock<ValidateNumberService>();
            Mock<CleanedNumberStringService> mockCleanedNumberStringService = new Mock<CleanedNumberStringService>();

            _stringCalculatorMainApplication = new StringCalculatorMainApplication(mockValidateNumberService.Object, mockCleanedNumberStringService.Object, 
                mockDelimiterService.Object, mockDetectNegativeNumbersService.Object);
        }

        [TestCase("1", 1)]
        [TestCase("2", 2)]
        [TestCase("3", 3)]
        [TestCase("4", 4)]
        [TestCase("5", 5)]
        [TestCase("6", 6)]
        [TestCase("7", 7)]
        [TestCase("8", 8)]
        [TestCase("9", 9)]
        [TestCase("10", 10)]

        public void One_Number_Return_Itself(string numbers, int expected)
        {
            Assert.AreEqual(_stringCalculatorMainApplication.Add(numbers), expected);
        }

        [TestCase("", 0)]
        public void Empty_String_Return_Zero(string numbers, int expected)
        {
            Assert.AreEqual(_stringCalculatorMainApplication.Add(numbers), expected);
        }

        [TestCase("22, 33", 55)]
        [TestCase("33, 45", 78)]
        public void Two_Valid_Numbers_Returns_Valid_Sum(string numbers, int expected)
        {
            Assert.AreEqual(_stringCalculatorMainApplication.Add(numbers), expected);
        }

        [TestCase("11,22,33", 66)]
        [TestCase("1,1,1,1", 4)]
        public void Valid_Set_Of_Numbers_Returns_Valid_Sum(string numbers, int expected)
        {
            Assert.AreEqual(_stringCalculatorMainApplication.Add(numbers), expected);
        }

        [TestCase("2\n2", 4)]
        [TestCase("5,2\n3", 10)]
        [TestCase("9\n4,5", 18)]
        public void Valid_Set_Of_Numbers_With_Newline_Returns_Valid_Sum(string numbers, int expected)
        {
            Assert.AreEqual(_stringCalculatorMainApplication.Add(numbers), expected);

        }

        [TestCase("//s\n1s2", 3)]
        [TestCase("//;\n2;3;4", 9)]
        [TestCase("//**\n1**2", 3)]
        [TestCase("//####\n1####2", 3)]
        public void Valid_Set_Of_Numbers_With_Delimiters_Return_Valid_Sum(string numbers, int expected)
        {
            Assert.AreEqual(_stringCalculatorMainApplication.Add(numbers), expected);
        }

        [TestCase("1,-1", "Error! There is a negative number")]
        [TestCase("2,-4,-1", "Error! There is a negative number")]
        [TestCase("-1,-1", "Error! There is a negative number")]
        public void Negatives_Number_Throws_Exceptio(string numbers, string exceptionMessage)
        {
            var ex = Assert.Throws<NegativeNumberException>(() => _stringCalculatorMainApplication.Add(numbers));
            Assert.That(ex.Message, Is.EqualTo(exceptionMessage));
        }

        [TestCase("1,9991", 1)]
        [TestCase("1,1000", 1001)]
        public void Numbers_Greater_Than_1000_Will_Not_Be_Added(string numbers, int expected)
        {
            Assert.AreEqual(_stringCalculatorMainApplication.Add(numbers), expected);
        }
    }
}
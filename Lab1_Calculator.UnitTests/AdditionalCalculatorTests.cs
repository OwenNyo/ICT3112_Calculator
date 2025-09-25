using Moq;
using NUnit.Framework;
using Lab1_Calculator;

namespace Lab1_Calculator.UnitTests
{
    [TestFixture]
    public class AdditionalCalculatorTests
    {
        private Calculator _calculator;
        private Mock<IFileReader> _mockFileReader;

        [SetUp]
        public void SetUp()
        {
            _mockFileReader = new Mock<IFileReader>();
            _mockFileReader
                .Setup(fr => fr.Read("MagicNumbers.txt"))
                .Returns(new[] { "5", "-8", "0" });
            _calculator = new Calculator();
        }

        [Test]
        public void GenMagicNum_UsesMockedData_Index0_Positive()
        {
            var result = _calculator.GenMagicNum(0, _mockFileReader.Object);
            Assert.AreEqual(10, result); // 2 * 5
        }

        [Test]
        public void GenMagicNum_UsesMockedData_Index1_NegativeBecomesPositiveDouble()
        {
            var result = _calculator.GenMagicNum(1, _mockFileReader.Object);
            Assert.AreEqual(16, result); // 2 * | -8 |
        }

        [Test]
        public void GenMagicNum_UsesMockedData_IndexOutOfRange_ReturnsZero()
        {
            var result = _calculator.GenMagicNum(10, _mockFileReader.Object);
            Assert.AreEqual(0, result);
        }
    }
}

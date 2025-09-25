using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_Calculator.UnitTests
{
    [TestFixture]
    public class GenMagicNumTests
    {
        private const string FileName = "MagicNumbers.txt";
        private Calculator _calculator;
        private FileReader _fileReader;

        [SetUp]
        public void SetUp()
        {
            _calculator = new Calculator();
            _fileReader = new FileReader();

            // Create the file expected by FileReader.Read("MagicNumbers.txt")
            // Index: 0      1       2
            // Value:  5     -8       0
            File.WriteAllLines(FileName, new[] { "5", "-8", "0" });
        }

        [TearDown]
        public void TearDown()
        {
            if (File.Exists(FileName))
                File.Delete(FileName);
        }

        [Test]
        public void GenMagicNum_Index0_PositiveNumber_DoublesToPositive()
        {
            // choice = 0 -> "5" -> 2 * 5 = 10
            var result = _calculator.GenMagicNum(0, _fileReader);
            Assert.That(result, Is.EqualTo(10));
        }

        [Test]
        public void GenMagicNum_Index1_NegativeNumber_ReturnsDoubleOfAbsolute()
        {
            // choice = 1 -> "-8" -> 2 * |-8| = 16
            var result = _calculator.GenMagicNum(1, _fileReader);
            Assert.That(result, Is.EqualTo(16));
        }

        [Test]
        public void GenMagicNum_Index2_Zero_DoublesToZero()
        {
            // choice = 2 -> "0" -> 2 * 0 = 0
            var result = _calculator.GenMagicNum(2, _fileReader);
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void GenMagicNum_IndexOutOfRange_ReturnsZero()
        {
            // choice = 99 -> out of range => stays 0
            var result = _calculator.GenMagicNum(99, _fileReader);
            Assert.That(result, Is.EqualTo(0));
        }
    }
}

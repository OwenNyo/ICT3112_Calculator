using Lab1_Calculator;
using NUnit.Framework;
using System;
using System.IO;   // for File.ReadAllLines, File.WriteAllLines, etc.
using Moq;

namespace Lab1_Calculator.UnitTests
{
    public class CalculatorTests
    {
        private Calculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new Calculator();
        }

        // --- Basic ops ---

        [Test]
        public void Add_WhenAddingTwoNumbers_ResultEqualToSum()
        {
            double result = _calculator.Add(10, 20);
            Assert.That(result, Is.EqualTo(30));
        }

        [Test]
        public void Subtract_WhenSubtractingTwoNumbers_ResultEqualToDifference()
        {
            double result = _calculator.Subtract(20, 10);
            Assert.That(result, Is.EqualTo(10));
        }

        [Test]
        public void Multiply_WhenMultiplyingTwoNumbers_ResultEqualToProduct()
        {
            double result = _calculator.Multiply(3, 4);
            Assert.That(result, Is.EqualTo(12));
        }

        [Test]
        public void Divide_NormalInputs_ResultEqualToQuotient()
        {
            double result = _calculator.Divide(20, 5);
            Assert.That(result, Is.EqualTo(4));
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(0, 10)]
        [TestCase(10, 0)]
        public void Divide_WithZerosAsInputs_ResultThrowArgumentException(double a, double b)
        {
            Assert.That(() => _calculator.Divide(a, b), Throws.ArgumentException);
        }

        // --- Factorial ---

        [Test]
        [TestCase(0, 1)]
        [TestCase(1, 1)]
        [TestCase(5, 120)]
        public void Factorial_WithValidWholeNumberInputs_ReturnsExpected(double n, double expected)
        {
            double result = _calculator.Factorial(n);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Factorial_WithNegativeInput_ThrowsArgumentException()
        {
            Assert.That(() => _calculator.Factorial(-1), Throws.ArgumentException);
        }

        [Test]
        public void Factorial_WithNonIntegerInput_ThrowsArgumentException()
        {
            Assert.That(() => _calculator.Factorial(3.5), Throws.ArgumentException);
        }

        // --- UnknownFunctionA (nPr) ---

        [Test]
        public void UnknownFunctionA_WhenGivenTest0_Result()
        {
            double result = _calculator.UnknownFunctionA(5, 5);
            Assert.That(result, Is.EqualTo(120));
        }

        [Test]
        public void UnknownFunctionA_WhenGivenTest1_Result()
        {
            double result = _calculator.UnknownFunctionA(5, 4);
            Assert.That(result, Is.EqualTo(120));
        }

        [Test]
        public void UnknownFunctionA_WhenGivenTest2_Result()
        {
            double result = _calculator.UnknownFunctionA(5, 3);
            Assert.That(result, Is.EqualTo(60));
        }

        [Test]
        public void UnknownFunctionA_WhenGivenTest3_ResultThrowArgumentException()
        {
            Assert.That(() => _calculator.UnknownFunctionA(-4, 5), Throws.ArgumentException);
        }

        [Test]
        public void UnknownFunctionA_WhenGivenTest4_ResultThrowArgumentException()
        {
            Assert.That(() => _calculator.UnknownFunctionA(4, 5), Throws.ArgumentException);
        }

        // --- UnknownFunctionB (nCr) ---

        [Test]
        public void UnknownFunctionB_WhenGivenTest0_Result()
        {
            double result = _calculator.UnknownFunctionB(5, 5);
            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void UnknownFunctionB_WhenGivenTest1_Result()
        {
            double result = _calculator.UnknownFunctionB(5, 4);
            Assert.That(result, Is.EqualTo(5));
        }

        [Test]
        public void UnknownFunctionB_WhenGivenTest2_Result()
        {
            double result = _calculator.UnknownFunctionB(5, 3);
            Assert.That(result, Is.EqualTo(10));
        }

        [Test]
        public void UnknownFunctionB_WhenGivenTest3_ResultThrowArgumentException()
        {
            Assert.That(() => _calculator.UnknownFunctionB(-4, 5), Throws.ArgumentException);
        }

        [Test]
        public void UnknownFunctionB_WhenGivenTest4_ResultThrowArgumentException()
        {
            Assert.That(() => _calculator.UnknownFunctionB(4, 5), Throws.ArgumentException);
        }

        // --- TDD area functions ---

        [Test]
        [TestCase(10, 4, 20)]
        [TestCase(0, 5, 0)]
        [TestCase(7.5, 2, 7.5)]
        public void TriangleArea_WithValidInputs_ReturnsExpected(double h, double l, double expected)
        {
            double result = _calculator.TriangleArea(h, l);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(-1, 5)]
        [TestCase(3, -2)]
        public void TriangleArea_WithNegativeInputs_ThrowsArgumentException(double h, double l)
        {
            Assert.That(() => _calculator.TriangleArea(h, l), Throws.ArgumentException);
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(1, Math.PI)]
        [TestCase(2, 4 * Math.PI)]
        public void CircleArea_WithValidInputs_ReturnsExpected(double r, double expected)
        {
            double result = _calculator.CircleArea(r);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void CircleArea_WithNegativeRadius_ThrowsArgumentException()
        {
            Assert.That(() => _calculator.CircleArea(-1), Throws.ArgumentException);
        }

        // --- MTBF & Availability (Part 2 §17) ---
        [Test]
        public void MTBF_100_10_Returns110()
        {
            Assert.That(_calculator.MTBF(100, 10), Is.EqualTo(110));
        }

        [TestCase(100, 10, 0.9090909091)]
        [TestCase(50, 50, 0.5)]
        public void Availability_CommonCases(double mttf, double mttr, double expected)
        {
            Assert.That(_calculator.Availability(mttf, mttr), Is.EqualTo(expected).Within(1e-10));
        }

        // --- Basic Musa (Part 2 §18) ---
        [Test]
        public void MusaBasic_LambdaAndMu_Sample()
        {
            double lambda = _calculator.MusaBasic_FailureIntensity(10, 100, 5);
            double mu = _calculator.MusaBasic_ExpectedFailures(10, 100, 5);
            Assert.That(lambda, Is.EqualTo(9.51229424500714).Within(1e-9));
            Assert.That(mu, Is.EqualTo(4.877057549928598).Within(1e-9));
        }

        // --- Musa Logarithmic + Quality metrics (Part 3 client reqs) ---
        [Test]
        public void MusaLog_LambdaAndMu_Sample()
        {
            double lambda = _calculator.MusaLog_FailureIntensity(20, 0.02, 50);
            double mu = _calculator.MusaLog_ExpectedFailures(20, 0.02, 50);

            Assert.That(lambda, Is.EqualTo(0.9523809524).Within(1e-10));
            Assert.That(mu, Is.EqualTo(152.226121886).Within(1e-6));
        }

        [Test]
        public void DefectDensity_45Defects_120KLoc_Returns375PerKLoc()
        {
            Assert.That(_calculator.DefectDensity(45, 120), Is.EqualTo(0.375));
        }

        [Test]
        public void NewTotalSSI_Sample()
        {
            // prev=100000, added=12000, modified=3000, deleted=2000  => 113000
            Assert.That(_calculator.NewTotalSSI(100000, 12000, 3000, 2000), Is.EqualTo(113000));
        }
        
    }
}

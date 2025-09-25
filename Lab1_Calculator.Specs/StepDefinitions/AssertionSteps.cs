using Lab1_Calculator.Specs.Support;
using NUnit.Framework;
using Reqnroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_Calculator.Specs.StepDefinitions
{
    [Binding]
    public class AssertionSteps
    {
        private readonly CalculatorContext _ctx;
        public AssertionSteps(CalculatorContext ctx) => _ctx = ctx;

        [Then("the result should be {double}")]
        public void Then_Result_ShouldBe(double expected)
            => Assert.That(_ctx.LastResult, Is.EqualTo(expected));

        [Then("the result should equal {double} within {double}")]
        public void Then_Result_ShouldEqualWithin(double expected, double tol)
            => Assert.That(_ctx.LastResult, Is.EqualTo(expected).Within(tol));

        [Then("the result equals positive_infinity")]
        public void Then_Result_Equals_PositiveInfinity()
            => Assert.That(double.IsPositiveInfinity(_ctx.LastResult));

        [Then("the result text should be {string}")]
        public void Then_Result_Text_ShouldBe(string expected)
            => Assert.That(_ctx.LastResult.ToString("G10"), Is.EqualTo(expected));
    }
}

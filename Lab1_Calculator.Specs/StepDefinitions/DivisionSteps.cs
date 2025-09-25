using Lab1_Calculator.Specs.Support;
using Reqnroll;
using NUnit.Framework;

namespace Lab1_Calculator.Specs.StepDefinitions
{
    [Binding]
    public class DivisionSteps
    {
        private readonly CalculatorContext _ctx;
        public DivisionSteps(CalculatorContext ctx) => _ctx = ctx;

        [When("I divide {double} by {double}")]
        [When("I have entered {double} and {double} into the calculator and press divide")]
        public void WhenIDivide(double a, double b)
        {
            _ctx.LastResult = _ctx.Calculator.Divide(a, b);
        }

    }
}

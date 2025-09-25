using Lab1_Calculator.Specs.Support;
using Reqnroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_Calculator.Specs.StepDefinitions
{
    [Binding]
    public class AdditionSteps
    {
        private readonly CalculatorContext _ctx;
        public AdditionSteps(CalculatorContext ctx) => _ctx = ctx;

        // Lab wording
        [When("I have entered {double} and {double} into the calculator and press add")]
        public void WhenIHaveEnteredAndPressAdd(double a, double b)
        {
            _ctx.LastResult = _ctx.Calculator.Add(a, b);
        }

        // Optional alias if you also use the short phrasing elsewhere
        [When("I enter {double} and {double} then press add")]
        public void WhenIEnterAndPressAdd(double a, double b)
        {
            _ctx.LastResult = _ctx.Calculator.Add(a, b);
        }
    }
}

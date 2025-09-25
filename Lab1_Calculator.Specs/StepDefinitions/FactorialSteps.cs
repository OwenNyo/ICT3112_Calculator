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
    public class FactorialSteps
    {
        private readonly CalculatorContext _ctx;
        public FactorialSteps(CalculatorContext ctx) => _ctx = ctx;


        [When("I enter {int} then press factorial")]
        [When("I enter {int} and press factorial")]
        public void WhenIFactorial(int n)
        {
            _ctx.LastResult = _ctx.Calculator.Factorial(n);
        }

    }
}

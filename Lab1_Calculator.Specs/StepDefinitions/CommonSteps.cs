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
    public class CommonSteps
    {
        private readonly CalculatorContext _ctx;
        public CommonSteps(CalculatorContext ctx) => _ctx = ctx;

        [Given("I have a calculator")]
        public void GivenIHaveACalculator()
        {
            // Context already provides Calculator per scenario
        }
    }
}

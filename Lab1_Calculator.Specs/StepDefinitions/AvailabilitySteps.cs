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
    public class AvailabilitySteps
    {
        private readonly CalculatorContext _ctx;
        public AvailabilitySteps(CalculatorContext ctx) => _ctx = ctx;


        [When("I enter {double} and {double} then press MTBF")]
        [When("I have entered {double} and {double} into the calculator and press MTBF")]
        public void WhenIMTBF(double mttf, double mttr)
        {
            _ctx.LastResult = _ctx.Calculator.MTBF(mttf, mttr);
        }

        [When("I enter {double} and {double} then press Availability")]
        [When("I have entered {double} and {double} into the calculator and press Availability")]
        public void WhenIAvailability(double mttf, double mttr)
        {
            _ctx.LastResult = _ctx.Calculator.Availability(mttf, mttr);
        }

    }
}

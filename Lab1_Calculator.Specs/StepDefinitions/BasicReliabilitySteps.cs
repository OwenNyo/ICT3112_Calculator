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
    public class BasicReliabilitySteps
    {
        private readonly CalculatorContext _ctx;
        public BasicReliabilitySteps(CalculatorContext ctx) => _ctx = ctx;

        [When("I enter lambda0 {double}, nu {double}, tau {double} then press BasicMusaLambda")]
        public void WhenBasicLambda(double lambda0, double nu, double tau)
        {
            _ctx.LastResult = _ctx.Calculator.MusaBasic_FailureIntensity(lambda0, nu, tau);
        }

        [When("I enter lambda0 {double}, nu {double}, tau {double} then press BasicMusaMu")]
        public void WhenBasicMu(double lambda0, double nu, double tau)
        {
            _ctx.LastResult = _ctx.Calculator.MusaBasic_ExpectedFailures(lambda0, nu, tau);
        }

    }
}

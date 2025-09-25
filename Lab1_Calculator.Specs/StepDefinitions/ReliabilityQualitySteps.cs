using Lab1_Calculator.Specs.Support;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using Reqnroll;
using Reqnroll.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab1_Calculator.Specs.StepDefinitions
{
    [Binding]
    public class ReliabilityQualitySteps
    {
        private readonly CalculatorContext _ctx;
        public ReliabilityQualitySteps(CalculatorContext ctx) => _ctx = ctx;


        // Musa-Log
        [When("I enter lambda0 {double}, theta {double}, tau {double} then press MusaLogLambda")]
        [When("I enter lambda0 {double} theta {double} tau {double} then press MusaLogLambda")]
        public void WhenLogLambda(double lambda0, double theta, double tau)
        {
            _ctx.LastResult = _ctx.Calculator.MusaLog_FailureIntensity(lambda0, theta, tau);
        }

        [When("I enter lambda0 {double}, theta {double}, tau {double} then press MusaLogMu")]
        [When("I enter lambda0 {double} theta {double} tau {double} then press MusaLogMu")]
        public void WhenLogMu(double lambda0, double theta, double tau)
        {
            _ctx.LastResult = _ctx.Calculator.MusaLog_ExpectedFailures(lambda0, theta, tau);
        }

        // Quality metrics
        [When("I enter defects {double} and sizeKLoc {double} then press DefectDensity")]
        [When("I have entered defects {double} and sizeKLoc {double} into the calculator and press DefectDensity")]
        public void WhenDefectDensity(double defects, double sizeKLoc)
        {
            _ctx.LastResult = _ctx.Calculator.DefectDensity(defects, sizeKLoc);
        }

        [When("I enter prevTotal {long}, added {long}, modified {long}, deleted {long} then press NewTotalSSI")]
        [When("I have entered prevTotal {long} added {long} modified {long} deleted {long} into the calculator and press NewTotalSSI")]
        public void WhenNewTotalSsi(long prev, long added, long modified, long deleted)
        {
            _ctx.LastResult = _ctx.Calculator.NewTotalSSI(prev, added, modified, deleted);
        }


        // Issue 1: Floating-point precision made exact compares flaky
        // Issue: Musa-Log calculations return long decimals; strict equality fails intermittently.
        // Resolution: Added a tolerance assertion step — Then the result should equal<value> within <tol> — and the feature uses it for λ(τ) and μ(τ).



    }
}

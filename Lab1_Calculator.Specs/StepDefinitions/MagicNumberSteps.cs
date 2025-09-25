// File: Lab1_Calculator.Specs/StepDefinitions/MagicNumberSteps.cs
using System.IO;
using System.Linq;
using Lab1_Calculator;
using Lab1_Calculator.Specs.Support;
using Reqnroll;

namespace Lab1_Calculator.Specs.StepDefinitions
{
    [Binding]
    public class MagicNumberSteps
    {
        private readonly CalculatorContext _ctx;
        private const string FileName = "MagicNumbers.txt";
        public MagicNumberSteps(CalculatorContext ctx) => _ctx = ctx;

        [Given("a magic numbers file containing:")]
        public void GivenAMagicNumbersFileContaining(Table table)
        {
            // Expect a single column header: "value"
            var lines = table.Rows.Select(r => r["value"]).ToArray();
            File.WriteAllLines(FileName, lines);
        }

        [When("I generate the magic number from {double}")]
        public void WhenIGenerateTheMagicNumberFrom(double input)
        {
            var reader = new FileReader(); // real dependency
            _ctx.LastResult = _ctx.Calculator.GenMagicNum(input, reader);
        }

        [AfterScenario]
        public void Cleanup()
        {
            if (File.Exists(FileName))
                File.Delete(FileName);
        }
    }
}

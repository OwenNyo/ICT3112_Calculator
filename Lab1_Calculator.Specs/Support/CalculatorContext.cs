using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1_Calculator;

namespace Lab1_Calculator.Specs.Support
{
    public class CalculatorContext
    {
        public Calculator Calculator { get; } = new Calculator();
        public double LastResult { get; set; }
    }
}

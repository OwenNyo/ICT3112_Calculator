using System;

namespace Lab1_Calculator
{
    public class Calculator
    {
        public Calculator() { }

        public double DoOperation(double num1, double num2, string op)
        {
            double result = double.NaN;

            switch (op)
            {
                case "a":
                    result = Add(num1, num2);
                    break;
                case "s":
                    result = Subtract(num1, num2);
                    break;
                case "m":
                    result = Multiply(num1, num2);
                    break;
                case "d":
                    result = Divide(num1, num2);
                    break;
                case "f":
                    // Only the first number is used for factorial
                    result = Factorial(num1);
                    break;
                default:
                    // unknown op leaves result as NaN
                    break;
            }
            return result;
        }

        // Basic ops
        public double Add(double num1, double num2) => num1 + num2;
        public double Subtract(double num1, double num2) => num1 - num2;
        public double Multiply(double num1, double num2) => num1 * num2;

        // Divide: throw ArgumentException when either input is zero (per lab task & parameterized tests)
        public double Divide(double num1, double num2)
        {
            if (num1 == 0 || num2 == 0)
                throw new ArgumentException("Inputs to Divide must be non-zero.");
            return num1 / num2;
        }

        // Factorial: accepts only whole, non-negative numbers; throws ArgumentException otherwise
        public double Factorial(double n)
        {
            if (n < 0) throw new ArgumentException("Factorial undefined for negatives.");
            if (Math.Floor(n) != n) throw new ArgumentException("Factorial requires an integer.");

            // 0! = 1
            if (n == 0) return 1;

            double acc = 1;
            for (int i = 1; i <= (int)n; i++)
                acc *= i;
            return acc;
        }

        // UnknownFunctionA: nPr = n! / (n - r)!
        public double UnknownFunctionA(double n, double r)
        {
            ValidateNR(n, r);
            return Factorial(n) / Factorial(n - r);
        }

        // UnknownFunctionB: nCr = n! / (r! * (n - r)!)
        public double UnknownFunctionB(double n, double r)
        {
            ValidateNR(n, r);
            return Factorial(n) / (Factorial(r) * Factorial(n - r));
        }

        // TDD functions (area)
        public double TriangleArea(double height, double length)
        {
            if (height < 0 || length < 0)
                throw new ArgumentException("Triangle dimensions must be non-negative.");
            return 0.5 * height * length;
        }

        public double CircleArea(double radius)
        {
            if (radius < 0)
                throw new ArgumentException("Radius must be non-negative.");
            return Math.PI * radius * radius;
        }

        // Helpers
        private void ValidateNR(double n, double r)
        {
            if (n < 0 || r < 0) throw new ArgumentException("n and r must be non-negative.");
            if (Math.Floor(n) != n || Math.Floor(r) != r) throw new ArgumentException("n and r must be integers.");
            if (r > n) throw new ArgumentException("r cannot be greater than n.");
        }

        // --- Reliability & Quality metrics (Lab 2 Part 2 & 3) ---

        // MTBF and Availability  [Part 2 §17]
        public double MTBF(double mttf, double mttr) => mttf + mttr;

        public double Availability(double mttf, double mttr)
        {
            var denom = mttf + mttr;
            if (denom == 0) return 0;          // simple guard
            return mttf / denom;
        }

        // Basic Musa (execution-time) model  [Part 2 §18]
        public double MusaBasic_FailureIntensity(double lambda0, double nu, double tau)
        {
            if (nu <= 0) throw new ArgumentOutOfRangeException(nameof(nu));
            return lambda0 * Math.Exp(-(tau / nu));
        }

        public double MusaBasic_ExpectedFailures(double lambda0, double nu, double tau)
        {
            if (nu <= 0) throw new ArgumentOutOfRangeException(nameof(nu));
            return nu * (1 - Math.Exp(-(tau / nu)));
        }

        // Musa Logarithmic (Musa–Okumoto) model  [Part 3 client reqs]
        public double MusaLog_FailureIntensity(double lambda0, double theta, double tau)
        {
            if (theta < 0) throw new ArgumentOutOfRangeException(nameof(theta));
            double denom = 1.0 + lambda0 * theta * tau;
            return lambda0 / denom;
        }

        public double MusaLog_ExpectedFailures(double lambda0, double theta, double tau)
        {
            if (theta <= 0) throw new ArgumentOutOfRangeException(nameof(theta));
            return Math.Log(1.0 + lambda0 * theta * tau) / theta;
        }

        // Quality metrics: defect density & successive-release SSI  [Part 3 client reqs]
        public double DefectDensity(double defects, double sizeKLoc)
        {
            if (sizeKLoc <= 0) throw new ArgumentOutOfRangeException(nameof(sizeKLoc));
            return defects / sizeKLoc;          // defects per KLOC
        }

        public long NewTotalSSI(long prevTotal, long added, long modified, long deleted)
        {
            // interpret: total_N = prevTotal - deleted + added + modified
            checked { return prevTotal - deleted + added + modified; }
        }
    }
}

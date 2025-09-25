using Lab1_Calculator;
using System;

namespace Lab1_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;
            var _calculator = new Calculator();

            Console.WriteLine("Console Calculator in C#");
            Console.WriteLine("------------------------\n");

            while (!endApp)
            {
                string numInput1 = "";
                string numInput2 = "";
                double result = 0;

                Console.Write("Type a number, and then press Enter: ");
                numInput1 = Console.ReadLine();

                double cleanNum1 = 0;
                while (!double.TryParse(numInput1, out cleanNum1))
                {
                    Console.Write("This is not valid input. Please enter a numeric value: ");
                    numInput1 = Console.ReadLine();
                }

                Console.Write("Type another number, and then press Enter: ");
                numInput2 = Console.ReadLine();

                double cleanNum2 = 0;
                while (!double.TryParse(numInput2, out cleanNum2))
                {
                    Console.Write("This is not valid input. Please enter a numeric value: ");
                    numInput2 = Console.ReadLine();
                }

                Console.WriteLine("Choose an operator from the following list:");
                Console.WriteLine("\ta - Add");
                Console.WriteLine("\ts - Subtract");
                Console.WriteLine("\tm - Multiply");
                Console.WriteLine("\td - Divide");
                Console.WriteLine("\tf - Factorial (uses only the first number)");
                Console.WriteLine("\tb - MTBF (num1=MTTF, num2=MTTR)");
                Console.WriteLine("\tv - Availability (num1=MTTF, num2=MTTR)");
                Console.WriteLine("\tl - MusaLog (needs lambda0, theta, tau)");
                Console.WriteLine("\tg - MusaBasic (needs lambda0, nu, tau)");
                Console.WriteLine("\tdn - Defect Density (num1=defects, num2=KLOC)");
                Console.WriteLine("\tss - New Total SSI (prev, added+modified-deleted via extra prompts)");
                Console.Write("Your option? ");

                string op = Console.ReadLine();

                try
                {
                    switch (op)
                    {
                        // existing basic ops still go through DoOperation
                        case "a":
                        case "s":
                        case "m":
                        case "d":
                        case "f":
                            result = _calculator.DoOperation(cleanNum1, cleanNum2, op);
                            break;

                        // MTBF (num1=MTTF, num2=MTTR)
                        case "b":
                            result = _calculator.MTBF(cleanNum1, cleanNum2);
                            break;

                        // Availability (num1=MTTF, num2=MTTR)
                        case "v":
                            result = _calculator.Availability(cleanNum1, cleanNum2);
                            break;

                        // Basic Musa: lambda0=num1, nu=num2, tau=extra prompt
                        case "g":
                            {
                                Console.Write("Enter tau (execution time): ");
                                if (!double.TryParse(Console.ReadLine(), out var tau))
                                    throw new FormatException("Tau must be a number.");
                                result = _calculator.MusaBasic_FailureIntensity(cleanNum1, cleanNum2, tau);
                                break;
                            }

                        // Musa Log: lambda0=num1, theta=num2, tau=extra prompt
                        case "l":
                            {
                                Console.Write("Enter tau (execution time): ");
                                if (!double.TryParse(Console.ReadLine(), out var tau))
                                    throw new FormatException("Tau must be a number.");
                                result = _calculator.MusaLog_FailureIntensity(cleanNum1, cleanNum2, tau);
                                break;
                            }

                        // Defect Density: defects=num1, KLOC=num2
                        case "dn":
                            result = _calculator.DefectDensity(cleanNum1, cleanNum2);
                            break;

                        // New Total SSI: prev=num1, prompt for added/modified/deleted
                        case "ss":
                            {
                                Console.Write("Added: ");
                                if (!long.TryParse(Console.ReadLine(), out var added))
                                    throw new FormatException("Added must be an integer.");

                                Console.Write("Modified: ");
                                if (!long.TryParse(Console.ReadLine(), out var modified))
                                    throw new FormatException("Modified must be an integer.");

                                Console.Write("Deleted: ");
                                if (!long.TryParse(Console.ReadLine(), out var deleted))
                                    throw new FormatException("Deleted must be an integer.");

                                result = _calculator.NewTotalSSI((long)cleanNum1, added, modified, deleted);
                                break;
                            }

                        default:
                            throw new InvalidOperationException("Unknown option.");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Oh no! An exception occurred trying math.\n - Details: " + e.Message);
                }

                Console.WriteLine("------------------------\n");

                Console.Write("Press 'q' and Enter to quit the app, or press any other key and Enter to continue: ");
                if (Console.ReadLine() == "q") endApp = true;

                Console.WriteLine("\n");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Business;
using ConsoleApp1.Vat;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args) 
        {
            Console.WriteLine("Welcome to a calculator");
            Console.WriteLine("It supports basic arithmetic functions and vat calculations");
            Console.WriteLine("Please input 1 for the first mode and 2 for the second ");
            while (true) 
            { 
                int input = int.Parse(Console.ReadLine()); 
                switch (input) 
                { 
                    case 1:
                        CalculatorService calculator = new CalculatorService();
                        Console.WriteLine("Input the first number "); 
                        double a = double.Parse(Console.ReadLine()); 
                        Console.WriteLine("Input the second number "); 
                        double b = double.Parse(Console.ReadLine()); 
                        Console.WriteLine("Input an operation"); 
                        int operation = int.Parse(Console.ReadLine()); 
                        double result; 
                        switch (operation) 
                        {
                            case 1:
                                try
                                {
                                    result = calculator.Add(a, b);
                                    Console.WriteLine(result);
                                    break;
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Error: Please enter valid numbers.");
                                    break;
                                }
                            case 2:
                                try
                                {
                                    result = calculator.Subtract(a, b);
                                    Console.WriteLine(result);
                                    break;
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Error: Please enter valid numbers.");
                                    break;
                                }
                            case 3:
                                try
                                {
                                    result = calculator.Multiply(a, b);
                                    Console.WriteLine(result);
                                    break;
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Error: Please enter valid numbers.");
                                    break;
                                }
                            case 4:
                                try
                                {
                                    result = calculator.Divide(a, b);
                                    Console.WriteLine(result);
                                    break;
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Error: Please enter valid numbers.");
                                    break;
                                }
                                catch (DivideByZeroException ex)
                                {
                                    Console.WriteLine($"Error: {ex.Message}");
                                    break;
                                }
                            default: 
                                break; 
                        } 
                        break; 
                    case 2:
                        VatService vat = new VatService();
                        Console.WriteLine("Input the sum ");
                        double s = double.Parse(Console.ReadLine());
                        Console.WriteLine("Input the percentage ");
                        double p = double.Parse(Console.ReadLine());
                        Console.WriteLine("Input an operation");
                        string mode = Console.ReadLine();
                        double calculation;
                        switch (mode)
                        {
                            case "n":
                                calculation = vat.vatNetno(s, p);
                                break;
                            case "p":
                                calculation = vat.vatBez(s, p);
                                break;
                            default:
                                Console.WriteLine("Not a valid input");
                                break;
                        }
                        break; 
                    default: Console.WriteLine("Such a mode is not supported"); 
                        break; 
                } 
            } 
        }
    }
}

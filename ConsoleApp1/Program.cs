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
            List<string> database = new List<string>();
            bool on = true;
            Console.WriteLine("Welcome to a calculator");
            Console.WriteLine("It supports basic arithmetic functions and vat calculations");
            Console.WriteLine("Input 1 for a regulator calculator, 2 for a vat calculator, 3 to view last 3 operations and 4 to exit the program");
            CalculatorService calculator = new CalculatorService();
            VatService vat = new VatService();
            while (on) 
            { 
                int input = int.Parse(Console.ReadLine());
                switch (input) 
                { 
                    case 1:
                        Console.WriteLine("Input the first number "); 
                        double a = double.Parse(Console.ReadLine()); 
                        Console.WriteLine("Input the second number "); 
                        double b = double.Parse(Console.ReadLine()); 
                        Console.WriteLine("Input an operation (1 for plus, 2 for minus, 3 for multiplication, 4 for division)"); 
                        int operation = int.Parse(Console.ReadLine()); 
                        double result; 
                        switch (operation) 
                        {
                            case 1:
                                try
                                {
                                    result = calculator.Add(a, b);
                                    Console.WriteLine(result);
                                    database.Add($"{a} + {b} = {result}");
                                    if (database.Count > 3)
                                    {
                                        database.RemoveAt(0);
                                    }
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
                                    database.Add($"{a} - {b} = {result}");
                                    if (database.Count > 3)
                                    {
                                        database.RemoveAt(0);
                                    }
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
                                    database.Add($"{a} * {b} = {result}");
                                    if (database.Count > 3)
                                    {
                                        database.RemoveAt(0);
                                    }
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
                                    database.Add($"{a} / {b} = {result}");
                                    if (database.Count > 3)
                                    {
                                        database.RemoveAt(0);
                                    }
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
                                Console.WriteLine("Thats not a valid input operation");
                                break; 
                        } 
                        break; 
                    case 2:
                        Console.WriteLine("Input the sum ");
                        double s = double.Parse(Console.ReadLine());
                        Console.WriteLine("Input the percentage ");
                        double p = double.Parse(Console.ReadLine());
                        Console.WriteLine("Input an operation (n for netno, p for procentno)");
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
                    case 3:
                        Console.WriteLine("Here are the last 3 operations");
                        for (int i = 0; i < database.Count; i++)
                        {
                            Console.WriteLine(database[i]);
                        }
                        break;
                    case 4:
                        Console.WriteLine("Thank you for using our calculator");
                        on = false;
                        break;
                    default: Console.WriteLine("Such a mode is not supported"); 
                        break; 
                } 
            } 
        }
    }
}

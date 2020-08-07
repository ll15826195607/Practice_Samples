using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new Calc.CalculatorClient();
            if (client != null)
            {
                while (true)
                {
                    Console.Write("\nEnter a: ");
                    Int32 a = Convert.ToInt32(Console.ReadLine());
                    Console.Write("\nEnter b: ");
                    Int32 b = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(String.Format("a + b = {0}", client.Add(a, b)));
                    Console.WriteLine(String.Format("a - b = {0}", client.Subtract(a, b)));
                    Console.WriteLine(String.Format("a * b = {0}", client.Multiply(a, b)));
                    Console.WriteLine(String.Format("a / b = {0}", client.Division(a, b)));
                }
            }
        }
    }
}

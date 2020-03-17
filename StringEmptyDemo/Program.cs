using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringEmptyDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // These are identical, ie: they have true reference equality 
            Console.WriteLine(Object.ReferenceEquals(String.Empty, ""));

            // Build an empty string from code in a way that you know it's generated at runtime
            String empty = new String('a', 1).Trim('a');

            // These still are the same reference
            Console.WriteLine(Object.ReferenceEquals(String.Empty, empty));

            // As is:
            StringBuilder builder = new StringBuilder();
            Console.WriteLine(Object.ReferenceEquals("", builder.ToString()));

            // Force this to intern
            String interned = String.Intern("");
            Console.WriteLine(Object.ReferenceEquals("", interned));

            Console.WriteLine("Press key to exit:");
            Console.ReadKey();
        }
    }
}

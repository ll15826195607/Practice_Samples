using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipeClientDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 1000000; i++)
            {
                new PipeClient("localhost", "Request #" + i);
            }

            Console.ReadLine();
        }
    }
}

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
            new PipeClient(".", "Request #");
            //for (int i = 0; i < 10000; i++)
            //{
            //    new PipeClient("localhost", "Request #" + i);
            //}

            Console.ReadLine();
        }
    }
}

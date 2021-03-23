using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PipeServerDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                new PipeServer();

            }
            //Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Press <Enter> to terminate this server application");
            Console.ReadLine();
        }
    }
}

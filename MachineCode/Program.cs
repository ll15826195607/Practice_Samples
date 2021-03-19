using System;

namespace MachineCodeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Environment.MachineName);
            Console.WriteLine(Environment.OSVersion);
            Console.WriteLine(MachineCode.GetSystemId());
            Console.WriteLine(MachineCode.GetMachineCodeString());
            Console.WriteLine(MachineCode.GetSystemId());
            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClassDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger fileLogger = new FileLogger("FileLogger", true, LogLevel.Debug);
            fileLogger.Log(LogLevel.Debug, "你好, 抽象类");
            Logger consoleLogger = new ConsoleLogger("ConsoleLogger", true, LogLevel.Debug);
            consoleLogger.Log(LogLevel.Debug, "你好,抽象类");

            ShowDirectoryInfo();
            Console.ReadLine();
        }

        static void ShowDirectoryInfo()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(@".");
            Console.WriteLine(String.Format("FullName: {0}",directoryInfo.FullName));
            Console.WriteLine(String.Format("Name: {0}", directoryInfo.Name));
            Console.WriteLine(String.Format("Parent: {0}", directoryInfo.Parent));
            Console.WriteLine(String.Format("CreationTime: {0}", directoryInfo.CreationTime));
            Console.WriteLine(String.Format("LastAccessTime: {0}", directoryInfo.LastAccessTime));
            Console.WriteLine(String.Format("LastWriteTime: {0}", directoryInfo.LastWriteTime));
            Console.WriteLine(String.Format("Attributes: {0}", directoryInfo.Attributes));
            Console.WriteLine(String.Format("Root: {0}", directoryInfo.Root));
        }
    }
}

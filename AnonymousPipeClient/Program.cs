using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousPipeClient
{
    class Program
    {
        static void Main(string[] args)
        {
            using (PipeStream pipeClient = new AnonymousPipeClientStream(PipeDirection.In, args[0]))
            {

                using (StreamReader sr = new StreamReader(pipeClient))
                {
                    String temp = null;
                    Console.WriteLine("[client] wait for sync ...");
                    do
                    {
                        temp = sr.ReadLine();
                    } while (!temp.StartsWith("SYNC"));
                    Console.WriteLine("client in");
                    while ((temp = sr.ReadLine()) != null)
                    {
                        Console.WriteLine("[client] receive message: " + temp);
                        if (temp == "exit")
                        {
                            break;
                        }
                    }
                }
                Console.Write("[client] Press Enter to exist...");
                Console.ReadLine();
            }
        }
    }
}

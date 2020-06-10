using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousPipeServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Process pipeClient1 = new Process();
            pipeClient1.StartInfo.FileName = @"AnonymousPipeClient.exe";

            //AnonymousPipeServerStream is an one-way pipe. in other words it's only support PipeDirection.In or PipeDirection.Out.
            //in this program, we use PipeDirection.Out for send data to clients.
            using (AnonymousPipeServerStream pipeServer =
                new AnonymousPipeServerStream(PipeDirection.Out, HandleInheritability.Inheritable))
            {

                //send the client handle that from AnonymousPipeServerStream to client
                pipeClient1.StartInfo.Arguments = pipeServer.GetClientHandleAsString();
                pipeClient1.StartInfo.UseShellExecute = false;
                pipeClient1.Start();

                //closes the local copy of the AnonymousPipeClientStream object's handle
                //this method must be call after the client handle has been passed to the client
                //if this method isn't called, then the AnonymousPipeServerStream will not receive notice when client dispose of it's PipeStream object
                pipeServer.DisposeLocalCopyOfClientHandle();

                try
                {
                    using (StreamWriter sw = new StreamWriter(pipeServer))
                    {
                        //automatic flush
                        sw.AutoFlush = true;

                        sw.WriteLine("SYNC");
                        //it'll block util the other end of pipe has been read all send bytes
                        pipeServer.WaitForPipeDrain();

                        String temp = null;
                        while (true)
                        {
                            temp = Console.ReadLine();
                            //send message to pipeclient from console
                            sw.WriteLine(temp);
                            //it'll block util the other end of pipe has been read all send bytes
                            pipeServer.WaitForPipeDrain();
                            if (temp == "exit")
                            {
                                break;
                            }
                        }
                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine("[server] exception:{0}", e.Message);
                }
            }

            pipeClient1.WaitForExit();
            pipeClient1.Close();

        }
    }
}

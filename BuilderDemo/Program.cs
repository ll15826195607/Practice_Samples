using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            ResourcePoolConfig resourcePoolConfig = new ResourcePoolConfig.Builder()
                .setName("dbConnectionPool")
                .setMaxTotal(16)
                .setMaxIdle(12)
                .setMinIdle(8)
                .build();

            Console.WriteLine(resourcePoolConfig.GetName());

            Console.ReadLine();
        }
    }
}

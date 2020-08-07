using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterDesignPattern
{
    public class Adaptee
    {
        public void fa()
        {
            Console.WriteLine("fa");
        }

        public void fb()
        {
            Console.WriteLine("fb");
        }

        public void fc()
        {
            Console.WriteLine("fc");
        }
    }
}

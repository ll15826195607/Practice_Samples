using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterDesignPattern
{
    /// <summary>
    /// 对象适配器：基于组合
    /// </summary>
    public class Adaptor2 : ITarget
    {
        private Adaptee adaptee;
        public Adaptor2(Adaptee adaptee)
        {
            this.adaptee = adaptee;
        }

        public void f1()
        {
            adaptee.fa();
        }

        public void f2()
        {
            Console.WriteLine("f2");
        }

        public void fc()
        {
            adaptee.fc();
        }
    }
}

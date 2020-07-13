using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterDesignPattern
{
    /// <summary>
    /// 类适配器：基于继承
    /// </summary>
    public class Adaptor : Adaptee, ITarget
    {
        public void f1()
        {
            base.fa();
        }

        public void f2()
        {
            Console.WriteLine("f2");
        }
    }
}

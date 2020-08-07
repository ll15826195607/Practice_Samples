using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Adaptor adaptor = new Adaptor();
            adaptor.f2();
            Adaptor2 adaptor2 = new Adaptor2(new Adaptee());
            adaptor2.f2();
            //选择用对象适配器还是类适配器？判断的依据：1.Adaptee接口的个数；2.Adaptee和ITarget的契合程度
            Console.ReadLine();
        }
    }
}

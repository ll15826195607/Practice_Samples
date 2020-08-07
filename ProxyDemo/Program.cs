using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyDemo
{
    /// <summary>
    /// 参考https://www.codeproject.com/Articles/5511/Dynamic-Proxy-Creation-Using-C-Emit
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now.Ticks);
            IUserController userController = (IUserController)UserControllerProxy.CreateInstance(new UserController());
            userController.Login(String.Empty, String.Empty);
            userController.Register(String.Empty);

            Console.ReadLine();
        }
    }
}

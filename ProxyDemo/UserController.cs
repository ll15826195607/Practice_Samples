using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProxyDemo
{
    public class UserController : IUserController
    {
        public Boolean Login(string name, string password)
        {
            Console.WriteLine("登录");
            Thread.Sleep(100);
            return true;
        }

        public Boolean Register(string name)
        {
            Console.WriteLine("注册");
            Thread.Sleep(1000);
            return true;
        }
    }
}

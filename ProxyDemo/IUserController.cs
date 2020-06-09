using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyDemo
{
    public interface IUserController
    {
        Boolean Login(String name, String password);
        Boolean Register(String name);
    }
}

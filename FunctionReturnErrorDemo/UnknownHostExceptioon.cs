using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionReturnErrorDemo
{
    public class UnknownHostExceptioon : Exception
    {
        public UnknownHostExceptioon(String message) : base(message)
        {
        }
    }
}

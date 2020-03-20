using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionReturnErrorDemo
{
    public class IdGenerationFailureException : Exception
    {
        public IdGenerationFailureException(String message):base(message)
        {
        }
    }
}

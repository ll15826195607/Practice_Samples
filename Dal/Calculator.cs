using IDal;
using System;

namespace Dal
{
    public class Calculator : ICalculator
    {
        public Int32 Add(Int32 a, Int32 b)
        {
            return a + b;
        }

        public Int32 Division(Int32 a, Int32 b)
        {
            return a / b;
        }

        public Int32 Multiply(Int32 a, Int32 b)
        {
            return a * b;
        }

        public Int32 Subtract(Int32 a, Int32 b)
        {
            return a - b;
        }
    }
}

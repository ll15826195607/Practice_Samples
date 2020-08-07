using System;
using System.ServiceModel;

namespace IDal
{
    [ServiceContract]
    public interface ICalculator
    {
        [OperationContract]
        Int32 Add(Int32 a, Int32 b);

        [OperationContract]
        Int32 Subtract(Int32 a, Int32 b);

        [OperationContract]
        Int32 Multiply(Int32 a, Int32 b);

        [OperationContract]
        Int32 Division(Int32 a, Int32 b);
    }
}

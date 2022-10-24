using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADPTest.SharedKernel.Interfaces
{
    public interface IOperationService
    {
        OperationType DefineOperationType(string operation);
        decimal DoSubtraction(long left, long right);
        decimal DoMultiplication(long left, long right);
        decimal DoAddition(long left, long right);
        decimal DoDivision(long left, long right);
        decimal DoRemainder(long left, long right);

    }
}

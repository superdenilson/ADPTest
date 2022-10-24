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
        double DoSubtraction(double left, double right);
        double DoMultiplication(double left, double right);
        double DoAddition(double left, double right);
        double DoDivision(double left, double right);
        double DoRemainder(double left, double right);

    }
}

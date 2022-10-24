using ADPTest.SharedKernel;
using ADPTest.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADPTest.Infrastructure.Services
{
    public class OperationService: IOperationService
    {
        public OperationType DefineOperationType(string operation)
        {
            switch (operation.ToLower())
            {
                case "addition": return OperationType.addition;
                case "subtraction": return OperationType.subtraction;
                case "division": return OperationType.division;
                case "multiplication": return OperationType.multiplication;
                case "remainder": return OperationType.remainder;
                default: return OperationType.notfound;
            }
        }
        public double DoSubtraction(double left, double right) { return left - right; }

        public double DoMultiplication(double left, double right) { return left * right; }

        public double DoAddition(double left, double right) { return left + right; }
        public double DoDivision(double left, double right)
        {
            if (right != 0)
                return left / right;
            else
                throw new DivideByZeroException("Can't divide by zero");
        }

        public double DoRemainder(double left, double right) { return left % right; }

    }
}

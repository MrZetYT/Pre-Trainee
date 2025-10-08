using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class AdditionOperation : IOperation
    {
        public double Execute(double a, double b) => a + b;
    }

    public class SubtractionOperation : IOperation
    {
        public double Execute(double a, double b) => a - b;
    }

    public class MultiplicationOperation : IOperation
    {
        public double Execute(double a, double b) => a * b;
    }

    public class DivisionOperation : IOperation
    {
        public double Execute(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException("Ошибка: деление на ноль!");
            return a / b;
        }
    }
}

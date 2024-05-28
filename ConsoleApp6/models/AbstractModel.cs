using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6.models
{
    public abstract class AbstractModel
    {
        public abstract double[][] LeastSquares(List<double> x, List<double> y);
        public abstract double Func(double a0, double a1, double x);
        public abstract string Result(double a0, double a1);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6.models
{
    public class Squared : AbstractModel
    {
        public override double[][] LeastSquares(List<double> x, List<double> y)
        {
            return new double[][]
            {
            new double[] { x.Count, x.Sum(i => i * i), y.Sum() },
            new double[] { x.Sum(i => i * i), x.Sum(i => i * i * i * i), x.Zip(y, (i, j) => j * i * i).Sum() }
            };
        }

        public override double Func(double a0, double a1, double x)
        {
            return a0 + a1 * x * x;
        }

        public override string Result(double a0, double a1)
        {
            return $"y = {a0:F2} + {a1:F2} * x ^ 2";
        }
    }
}

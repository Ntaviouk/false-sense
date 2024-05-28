using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6.models
{
    public class Hyperbolic : AbstractModel
    {
        public override double[][] LeastSquares(List<double> x, List<double> y)
        {
            return new double[][]
            {
            new double[] { x.Count, x.Sum(), y.Sum(i => 1 / i) },
            new double[] { x.Sum(), x.Sum(i => i * i), x.Zip(y, (i, j) => i / j).Sum() }
            };
        }

        public override double Func(double a0, double a1, double x)
        {
            return 1 / (a0 + a1 / x);
        }

        public override string Result(double a0, double a1)
        {
            return $"y = 1 / ({a0:F2} + {a1:F2} / x)";
        }
    }
}

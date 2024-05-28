using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6.models
{
    public class Result
    {
        public List<double> x = new List<double>();
        public List<double> y = new List<double>();
        public List<double> calculated_y = new List<double>();
        public double[][] least_squares = null;
        public double[] roots = null;
        public double summ = 0;
        public Func<double, double, double, double> func = null;
        public string res = null;

        public double SumSquaresMismatches()
        {
            summ = 0;
            for (int i = 0; i < x.Count; i++)
            {
                summ += Math.Pow(Math.Abs(y[i]) - Math.Abs(calculated_y[i]), 2);
            }
            return summ;
        }

        public string GetInfo()
        {
            return $"x: {string.Join(", ", x)}\n" +
                   $"y: {string.Join(", ", y)}\n" +
                   $"calculated_y: {string.Join(", ", calculated_y)}\n" +
                   $"least_squares: [{string.Join(", ", least_squares[0])}]\n" +
                   $"roots: {string.Join(", ", roots)}\n" +
                   $"summ: {summ}\n" +
                   $"func: {func}\n" +
                   $"res: {res}\n";
        }

        public void Clear()
        {
            calculated_y.Clear();
            least_squares = null;
            roots = null;
            summ = 0;
            func = null;
            res = null;
        }
    }
}

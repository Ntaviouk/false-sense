using ConsoleApp6.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace ConsoleApp6
{
    internal class Program
    {
        static double[] Gauss(double[][] A)
        {
            int n = A.Length;
            var matrix = DenseMatrix.OfArray(new double[n, n]);
            var vector = new double[n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = A[i][j];
                }
                vector[i] = A[i][n];
            }

            var solution = matrix.Solve(DenseVector.OfArray(vector));
            return solution.ToArray();
        }

        static void Main(string[] args)
        {
            Random randomGenerator = new Random();

            Result r = new Result();
            Result result = new Result();
            List<AbstractModel> models = new List<AbstractModel>
            {
                new Linear(),
                new Feedback(),
                new Hyperbolic(),
                new Squared(),
                new Rational()
            };

            Console.Write("Введiть N: ");
            int N = int.Parse(Console.ReadLine());
            for (int i = 0; i < N; i++)
            {
                Console.Write("x = ");
                r.x.Add(double.Parse(Console.ReadLine()));
            }
            for (int i = 0; i < N; i++)
            {
                Console.Write($"y({r.x[i]}) = ");
                r.y.Add(double.Parse(Console.ReadLine()));
            }
            Console.WriteLine();
            Console.WriteLine("{0,-15} {1,-30} {2}", "Коренi", "Функцiя", "Сума квадратiв нев'язок");
            foreach (var model in models)
            {
                r.least_squares = model.LeastSquares(r.x, r.y);
                r.roots = Gauss(r.least_squares);

                foreach (var xi in r.x)
                {
                    r.calculated_y.Add(model.Func(r.roots[0], r.roots[1], xi));
                }

                r.res = model.Result(r.roots[0], r.roots[1]);
                r.func = model.Func;
                r.SumSquaresMismatches();

                Console.WriteLine("{0,-15:F2} {1,-30} {2}", $"{r.roots[0]:F2} {r.roots[1]:F2}", r.res, r.summ);

                if (result.summ == 0 || result.summ > r.summ)
                {
                    result = new Result
                    {
                        x = new List<double>(r.x),
                        y = new List<double>(r.y),
                        calculated_y = new List<double>(r.calculated_y),
                        least_squares = r.least_squares.Select(arr => arr.ToArray()).ToArray(),
                        roots = (double[])r.roots.Clone(),
                        summ = r.summ,
                        func = r.func,
                        res = r.res
                    };
                    r.Clear();
                }

                r.Clear();
            }
            Console.WriteLine("\n Результат");
            Console.WriteLine(result.res);
            Console.ReadKey();
        }
    }
}

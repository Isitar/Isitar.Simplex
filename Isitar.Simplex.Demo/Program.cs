using System;
using System.Linq;
using System.Threading.Tasks;
using Isitar.Simplex.Common.Models;

namespace Isitar.Simplex.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var variables = Enumerable.Range(1, 100).AsParallel().Select(i => new Variable()).ToList();
            var x1 = new Variable();
            var x2 = new Variable();
            var x3 = new Variable();
            var x4 = new Variable();

            var constraint = 4 * x1 + 2 * x2 >= 2 * x3 + 4 * x4 - 2 + 1 * x1;

            Console.WriteLine(constraint);
        }
    }
}
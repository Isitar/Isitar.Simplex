using Isitar.Simplex.Common.Models;

namespace Isitar.Simplex.Common.Contracts
{
    public interface ISolver
    {
        /// <summary>
        /// Solves a given problem p and returns a ProblemResult
        /// </summary>
        /// <param name="p">The problem to be solved</param>
        /// <returns>The result for the given problem</returns>
        ProblemResult Solve(Problem p);
    }
}
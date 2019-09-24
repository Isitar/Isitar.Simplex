using System.Diagnostics;
using System.Threading;
using Isitar.Simplex.Common.Models.Constraint;

namespace Isitar.Simplex.Common.Models
{
    public class Variable
    {
        private static int objectCounter = 0;
        public int Id { get; }

        public Variable(int id = -1)
        {
            if (id == -1)
            {
                id = Interlocked.Increment(ref objectCounter);
            }

            Id = id;
        }

        public static ConstraintVariable operator *(double c, Variable v)
        {
            return new ConstraintVariable(c, v);
        }

        public static ConstraintVariable operator *(Variable v, double d)
        {
            return d * v;
        }

        public override string ToString()
        {
            return $"x_{Id}";
        }
    }
}
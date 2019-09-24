using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Reflection.PortableExecutable;
using System.Text;

namespace Isitar.Simplex.Common.Models.Constraint
{
    public class Constraint
    {
        public double Rhs { get; }
        public IImmutableDictionary<int, double> Variables { get; }
        public ConstraintType ConstraintType { get; }


        public Constraint(IImmutableDictionary<int, double> variables, ConstraintType constraintType, double rhs)
        {
            Rhs = rhs;
            Variables = variables;
            ConstraintType = constraintType;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var variable in Variables)
            {
                sb.Append($"{variable.Value:+0;-#}x_{variable.Key}");
            }

            switch (ConstraintType)
            {
                case ConstraintType.Lt:
                    sb.Append(" < ");
                    break;
                case ConstraintType.Leq:
                    sb.Append(" <= ");
                    break;
                case ConstraintType.Gt:
                    sb.Append(" > ");
                    break;
                case ConstraintType.Geq:
                    sb.Append(" >= ");
                    break;
                case ConstraintType.Eq:
                    sb.Append(" = ");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            sb.Append($"{Rhs:+0;-#}");
            return sb.ToString();
        }
    }
}
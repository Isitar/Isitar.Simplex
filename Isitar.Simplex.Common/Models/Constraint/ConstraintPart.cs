using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks.Sources;

namespace Isitar.Simplex.Common.Models.Constraint
{
    public class ConstraintPart
    {
        private readonly Dictionary<int, double> constraintVariables;
        private readonly double b;

        public ConstraintPart(Dictionary<int, double> constraintVariables = null, double b = 0)
        {
            if (constraintVariables == null)
            {
                constraintVariables = new Dictionary<int, double>();
            }

            this.constraintVariables = constraintVariables;
            this.b = b;
        }

        #region Builder Methods

        private void AddPositive(Dictionary<int, double> dict, int variableId, double coefficient)
        {
            if (dict.ContainsKey(variableId))
            {
                dict[variableId] += coefficient;
            }
            else
            {
                dict[variableId] = coefficient;
            }
        }

        public ConstraintPart AddPositive(params ConstraintVariable[] vs)
        {
            var dict = new Dictionary<int, double>(constraintVariables);
            foreach (var v in vs)
            {
                AddPositive(dict, v.Variable.Id, v.Coefficient);
            }

            return new ConstraintPart(dict, b);
        }

        public ConstraintPart AddPositive(ConstraintPart cp)
        {
            var dict = new Dictionary<int, double>(constraintVariables);
            foreach (var constraintVariable in cp.constraintVariables)
            {
                AddPositive(dict, constraintVariable.Key, constraintVariable.Value);
            }

            return new ConstraintPart(dict, b + cp.b);
        }

        public ConstraintPart AddNegative(params ConstraintVariable[] vs)
        {
            var dict = new Dictionary<int, double>(constraintVariables);
            foreach (var v in vs)
            {
                AddPositive(dict, v.Variable.Id, -v.Coefficient);
            }

            return new ConstraintPart(dict, b);
        }

        public ConstraintPart AddNegative(ConstraintPart cp)
        {
            var dict = new Dictionary<int, double>(constraintVariables);
            foreach (var constraintVariable in cp.constraintVariables)
            {
                AddPositive(dict, constraintVariable.Key, -constraintVariable.Value);
            }

            return new ConstraintPart(dict, b - cp.b);
        }

        #endregion


        #region operators

        public static ConstraintPart operator +(ConstraintPart cp, ConstraintPart cp2)
        {
            return cp.AddPositive(cp2);
        }

        public static ConstraintPart operator -(ConstraintPart cp, ConstraintPart cp2)
        {
            return cp.AddNegative(cp2);
        }

        public static ConstraintPart operator +(ConstraintPart cp, double d)
        {
            return cp + new ConstraintPart(null, d);
        }

        public static ConstraintPart operator +(double d, ConstraintPart cp)
        {
            return cp + d;
        }

        public static ConstraintPart operator -(double d, ConstraintPart cp)
        {
            return new ConstraintPart(null, d) - cp;
        }

        public static ConstraintPart operator -(ConstraintPart cp, double d)
        {
            return cp - new ConstraintPart(null, d);
        }

        public static Constraint operator <=(ConstraintPart cp, ConstraintPart cp2)
        {
            var combined = cp - cp2;
            return
                new Constraint(combined.constraintVariables.ToImmutableDictionary(), ConstraintType.Leq, -combined.b);
        }

        public static Constraint operator >=(ConstraintPart cp, ConstraintPart cp2)
        {
            var combined = cp - cp2;
            return
                new Constraint(combined.constraintVariables.ToImmutableDictionary(), ConstraintType.Geq, -combined.b);
        }

        public static Constraint operator ==(ConstraintPart cp, ConstraintPart cp2)
        {
            var combined = cp - cp2;
            return
                new Constraint(combined.constraintVariables.ToImmutableDictionary(), ConstraintType.Eq, -combined.b);
        }

        public static Constraint operator !=(ConstraintPart cp, ConstraintPart cp2)
        {
            throw new NotSupportedException("this constraint type is currently not supported");
        }

        public static Constraint operator <(ConstraintPart cp, ConstraintPart cp2)
        {
            var combined = cp - cp2;
            return
                new Constraint(combined.constraintVariables.ToImmutableDictionary(), ConstraintType.Lt, -combined.b);
        }

        public static Constraint operator >(ConstraintPart cp, ConstraintPart cp2)
        {
            var combined = cp - cp2;
            return
                new Constraint(combined.constraintVariables.ToImmutableDictionary(), ConstraintType.Gt, -combined.b);
        }

        #endregion

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var constraintVariable in constraintVariables)
            {
                sb.Append(
                    $"{constraintVariable.Value:+0;-#}x_{constraintVariable.Key}");
            }

            sb.Append($"{b:+0;-#}");
            return sb.ToString();
        }
    }
}
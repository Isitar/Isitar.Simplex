namespace Isitar.Simplex.Common.Models.Constraint
{
    public class ConstraintVariable
    {
        public double Coefficient { get; }
        public Variable Variable { get; }

        public ConstraintVariable(double coefficient, Variable variable)
        {
            Variable = variable;
            Coefficient = coefficient;
        }

        #region v v

        public static ConstraintPart operator +(ConstraintVariable v1, ConstraintVariable v2)
        {
            return new ConstraintPart().AddPositive(v1, v2);
        }

        public static ConstraintPart operator -(ConstraintVariable v1, ConstraintVariable v2)
        {
            return new ConstraintPart().AddPositive(v1).AddNegative(v2);
        }

        #endregion

        #region cp v

        public static ConstraintPart operator +(ConstraintPart cp, ConstraintVariable v)
        {
            return cp.AddPositive(v);
        }

        public static ConstraintPart operator -(ConstraintPart cp, ConstraintVariable v)
        {
            return cp.AddNegative(v);
        }

        public static ConstraintPart operator +(ConstraintVariable v, ConstraintPart cp)
        {
            return cp + v;
        }

        public static ConstraintPart operator -(ConstraintVariable v, ConstraintPart cp)
        {
            return new ConstraintPart().AddPositive(v) - cp;
        }

        #endregion

        #region v double

        public static ConstraintPart operator +(double d, ConstraintVariable v)
        {
            return new ConstraintPart(null, d) + v;
        }

        public static ConstraintPart operator -(double d, ConstraintVariable v)
        {
            return new ConstraintPart(null, d) - v;
        }

        public static ConstraintPart operator +(ConstraintVariable v, double d)
        {
            return d + v;
        }

        public static ConstraintPart operator -(ConstraintVariable v, double d)
        {
            return new ConstraintPart(null, -d) + v;
        }

        public static ConstraintVariable operator *(ConstraintVariable v, double d)
        {
            return new ConstraintVariable(v.Coefficient * d, v.Variable);
        }

        public static ConstraintVariable operator *(double d, ConstraintVariable v)
        {
            return v * d;
        }

        #endregion
    }
}
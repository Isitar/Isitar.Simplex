using System.Collections.Generic;

namespace Isitar.Simplex.Common.Models
{
    public class Problem
    {
        private List<Constraint.Constraint> constraints = new List<Constraint.Constraint>();
        public IReadOnlyList<Constraint.Constraint> Constraints => constraints.AsReadOnly();
        private List<Variable> variables = new List<Variable>();
        public IReadOnlyList<Variable> Variables => variables.AsReadOnly();
    }
}
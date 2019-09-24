using System;
using Isitar.Simplex.Common.Models;
using Xunit;

namespace Isitar.Simplex.Common.Tests
{
    public class ConstriantBuilderTest
    {
        [Fact]
        public void TestVariableMultiplication()
        {
            var x1 = new Variable();
            var z = x1 * 2 ;
        }
    }
}
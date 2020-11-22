using System;
using NUnit.Framework;

namespace UITestingDemo.UnitTests
{
    public static class AssertExtension
    {
        public static TExpected IsType<TExpected>(this object actual, string message = null)
            where TExpected : class
        {
            TExpected result = actual as TExpected;
            Assert.IsNotNull(result, message);
            return result;
        }
    }
}

using NUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = NUnit.Framework.Assert;

namespace Tests
{
    [TestClass]
    public class TriangleTests
    {
       [TestMethod]
       public void IsRightTriangle()
        {
            Assert.IsTrue(Triangles.Triangle.IsTriangle(5, 5, 5));
        }

        [TestMethod]
        public void AllSidesIsZero()
        {
            Assert.IsFalse(Triangles.Triangle.IsTriangle(0, 0, 0));
        }
    }
}
using NUnit.Framework;
using Triangles;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void IsRightTriangle()
        {
            Assert.IsTrue(Triangle.IsTriangle(2, 6, 7));
        }

        [Test]
        public void AllSidesAreEqual()
        {
            Assert.IsTrue(Triangle.IsTriangle(5, 5, 5));
        }

        [Test]
        public void EgyptTriangle()
        {
            Assert.IsTrue(Triangle.IsTriangle(3, 4, 5));
        }

        [Test]
        public void TwoSidesAreEqual()
        {
            Assert.IsTrue(Triangle.IsTriangle(8, 8, 10));
        }

        [Test]
        public void HugeTriangle()
        {
            Assert.IsTrue(Triangle.IsTriangle(57961, 41335, 37546));
        }

        [Test]
        public void OneSideIsZero()
        {
            Assert.IsFalse(Triangle.IsTriangle(0, 2, 4));
        }

        [Test]
        public void AllSidesAreZero()
        {
            Assert.IsFalse(Triangle.IsTriangle(0, 0, 0));
        }

        [Test]
        public void OneSideIsNegative()
        {
            Assert.IsFalse(Triangle.IsTriangle(-3, 4, 5));
        }

        [Test]
        public void AllSidesAreNegaive()
        {
            Assert.IsFalse(Triangle.IsTriangle(-3, -4, -5));
        }

        [Test]
        public void ImpossibleTriangle()
        {
            Assert.IsFalse(Triangle.IsTriangle(10, 1, 124));
        }
        
        
       
    }
}
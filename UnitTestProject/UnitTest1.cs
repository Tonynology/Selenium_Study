using Calculator;
using NUnit.Framework;

namespace UnitTestProject
{
    public class Tests
    {
        [Test]
        public void AddMethodTest()
        {
            Calc obj = new Calc();
            double actualResult = obj.Add(-1, -1);

            Assert.AreEqual(2, actualResult); // verify the output
        }
        [Test]
        public void AddMethodsTest(double a, double b, double expectedValue)
        {
            Calc obj = new Calc();
            double actualResult = obj.Add(-1, -1);

            Assert.AreEqual(2, actualResult); // verify the output
        }
        [Test]
        public void SubTest([Random(-100,200,5)] double a, [Random(100, 200, 5)] double b)
        {
            Calc obj = new Calc();
            double actualResult = obj.Sub(a, b);

            Assert.AreEqual(a-b, actualResult); // verify the output
        }
        [Test]
        public void RangeTest([Range(111111,555555)] int a)
        {
          
        }
    }
}
using MathsModule;
namespace MyUnitTestProj
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //preapre
            var a =4;
            var b = 2;
            var mathEngine = new MathEngine();

            var expectedResult = 8;

            //act
            var ActulaResult = mathEngine.Multiply(a, b);
            //assert
            Assert.AreEqual(expectedResult, ActulaResult, "The addition result is not as expected.");
        }
    }
}

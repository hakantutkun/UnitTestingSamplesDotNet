using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sparky;

namespace SparkyMSTest
{
    [TestClass]
    public class CalculatorMSTests
    {
        [TestMethod]
        public void AddNumbers_InputTwoInt_GetCorrectAddition()
        {
            // Arrange -> All the initializations should be arranged this phase.
            // Create an object of the class that will be tested.
            Calculator calc = new();

            // Act -> The phase that actually should invoke any methods that are needed that will give us some output.
            int result = calc.AddNumbers(10,20);

            // Assert -> The phase that we should actually check that the result is exactly the same as we expected.
            Assert.AreEqual(30, result);
        }
    }
}
   
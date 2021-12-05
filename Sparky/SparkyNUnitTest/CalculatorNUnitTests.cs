using NUnit.Framework;
using Sparky;

namespace SparkyNUnitTest
{
    /// <summary>
    /// Unit Tests for Calculator class
    /// </summary>
    [TestFixture]
    public class CalculatorNUnitTests
    {
        #region AddNumbers Tests

        /// <summary>
        /// Addition Method Test
        /// </summary>
        [Test]
        public void AddNumbers_InputTwoInt_GetCorrectAddition()
        {
            // Arrange -> All the initializations should be arranged this phase.
            // Create an object of the class that will be tested.
            Calculator calc = new();

            // Act -> The phase that actually should invoke any methods that are needed that will give us some output.
            int result = calc.AddNumbers(10, 20);

            // Assert -> The phase that we should actually check that the result is exactly the same as we expected.
            Assert.AreEqual(30, result);
        }

        #endregion

        #region IsOddNumber Tests

        // Method can return true or false. So we have to test both situations.

        /// <summary>
        /// IsOddNumber False Checker
        /// </summary>
        [Test]
        public void IssOddNumber_InputEvenNumber_ReturnsFalse()
        {
            // Arrange
            Calculator calc = new();

            // Act
            bool isOdd = calc.IsOddNumber(10);

            // Assert
            Assert.IsFalse(isOdd);

            // Similar assertion
            // Assert.That(result, Is.EqualTo(false));
        }

        /// <summary>
        /// IsOddNumber True Checker
        /// </summary>
        [Test]
        // Testing with different inputs
        [TestCase(11)]
        [TestCase(13)]
        [TestCase(15)]
        public void IssOddNumber_InputOddNumber_ReturnsTrue(int a)
        {
            // Arrange
            Calculator calc = new();

            // Act
            bool isOdd = calc.IsOddNumber(a);

            // Assert
            Assert.IsTrue(isOdd);
        }

        #endregion
    }
}

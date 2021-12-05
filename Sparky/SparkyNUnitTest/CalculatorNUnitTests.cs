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

        /// <summary>
        /// Addition Method Test
        /// </summary>
        [Test]
        [TestCase(5.4, 10.5)] // 15.9
        [TestCase(5.43, 10.53)] // 15.96
        [TestCase(5.49, 10.59)] // 16.08
        public void AddNumbersDouble_InputTwoDouble_GetCorrectAddition(double a, double b)
        {
            // Arrange -> All the initializations should be arranged this phase.
            // Create an object of the class that will be tested.
            Calculator calc = new();

            // Act -> The phase that actually should invoke any methods that are needed that will give us some output.
            double result = calc.AddNumbersDouble(a, b);

            // Assert -> The phase that we should actually check that the result is exactly the same as we expected.
            Assert.AreEqual(15.9, result, 1); // -> Result shoud be between 14.9 and 16.9
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

        /// <summary>
        /// Control both situation in the same unit test.
        /// </summary>
        /// <param name="a">Given number</param>
        /// <returns>True if given number odd, otherwise false.</returns>
        [Test]
        [TestCase(10, ExpectedResult = false)]
        [TestCase(11, ExpectedResult = true)]
        public bool IsOddChecker_InputNumber_ReturnTrueIfOdd(int a)
        {
            // Arrange
            Calculator calc = new();

            return calc.IsOddNumber(a);
        }

        #endregion

        #region GetOddRange Tests

        [Test]
        public void OddRanger_InputMinAndMaxRange_ReturnsValidOddNumberRange()
        {
            // Arrange
            Calculator calc = new();
            List<int> expectedOddRange = new List<int>() { 5, 7, 9 }; // 5-10

            // Act
            List<int> result = calc.GetOddRange(5, 10);

            // Assert
            Assert.That(result, Is.EquivalentTo(expectedOddRange));

            // Similar Assertions
            Assert.AreEqual(expectedOddRange, result);
            Assert.Contains(7, result);

            // With that method
            Assert.That(result, Does.Contain(7));
            Assert.That(result, Is.Not.Empty);
            Assert.That(result.Count, Is.EqualTo(3));
            Assert.That(result, Has.No.Member(6));
            Assert.That(result, Is.Ordered); // -> Is.Ordered.Descending -> Checks descending
            Assert.That(result, Is.Unique);
        }

        #endregion
    }
}

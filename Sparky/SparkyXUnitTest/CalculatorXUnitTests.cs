using Sparky;
using Xunit;

namespace SparkyXUnitTest
{
    /// <summary>
    /// Unit Tests for Calculator class
    /// </summary>
    public class CalculatorXUnitTests
    {
        #region AddNumbers Tests

        /// <summary>
        /// Addition Method Test
        /// </summary>
        [Fact]
        public void AddNumbers_InputTwoInt_GetCorrectAddition()
        {
            // Arrange -> All the initializations should be arranged this phase.
            // Create an object of the class that will be tested.
            Calculator calc = new();

            // Act -> The phase that actually should invoke any methods that are needed that will give us some output.
            int result = calc.AddNumbers(10, 20);

            // Assert -> The phase that we should actually check that the result is exactly the same as we expected.
            Assert.Equal(30, result);
        }

        /// <summary>
        /// Addition Method Test
        /// </summary>
        [Theory]
        [InlineData(5.4, 10.5)] // 15.9
        [InlineData(5.43, 10.53)] // 15.96
        [InlineData(5.49, 10.59)] // 16.08
        public void AddNumbersDouble_InputTwoDouble_GetCorrectAddition(double a, double b)
        {
            // Arrange -> All the initializations should be arranged this phase.
            // Create an object of the class that will be tested.
            Calculator calc = new();

            // Act -> The phase that actually should invoke any methods that are needed that will give us some output.
            double result = calc.AddNumbersDouble(a, b);

            // Assert -> The phase that we should actually check that the result is exactly the same as we expected.
            Assert.Equal(15.9, result, 0); // -> Result shoud be between 14.9 and 16.9
                                           // -> 0 here is precision. Different from Nunit Test.
        }

        #endregion

        #region IsOddNumber Tests

        // Method can return true or false. So we have to test both situations.

        /// <summary>
        /// IsOddNumber False Checker
        /// </summary>
        [Fact]
        public void IssOddNumber_InputEvenNumber_ReturnsFalse()
        {
            // Arrange
            Calculator calc = new();

            // Act
            bool isOdd = calc.IsOddNumber(10);

            // Assert
            Assert.False(isOdd);
        }

        /// <summary>
        /// IsOddNumber True Checker
        /// </summary>
        [Theory]
        // Testing with different inputs
        [InlineData(11)]
        [InlineData(13)]
        [InlineData(15)]
        public void IssOddNumber_InputOddNumber_ReturnsTrue(int a)
        {
            // Arrange
            Calculator calc = new();

            // Act
            bool isOdd = calc.IsOddNumber(a);

            // Assert
            Assert.True(isOdd);
        }

        /// <summary>
        /// Control both situation in the same unit test.
        /// </summary>
        /// <param name="a">Given number</param>
        /// <returns>True if given number odd, otherwise false.</returns>
        [Theory]
        [InlineData(10, false)]
        [InlineData(11, true)]
        public void IsOddChecker_InputNumber_ReturnTrueIfOdd(int a, bool expectedResult)
        {
            // Arrange
            Calculator calc = new();

            var result = calc.IsOddNumber(a);
            
            Assert.Equal(expectedResult, result);
        }

        #endregion

        #region GetOddRange Tests

        [Fact]
        public void OddRanger_InputMinAndMaxRange_ReturnsValidOddNumberRange()
        {
            // Arrange
            Calculator calc = new();
            List<int> expectedOddRange = new List<int>() { 5, 7, 9 }; // 5-10

            // Act
            List<int> result = calc.GetOddRange(5, 10);

            // Assert
            Assert.Equal(expectedOddRange, result);
            Assert.Contains(7, result);
            Assert.NotEmpty(result);
            Assert.Equal(3,result.Count);
            Assert.DoesNotContain(6, result);
            Assert.Equal(result.OrderBy(u => u), result);
        }

        #endregion
    }
}

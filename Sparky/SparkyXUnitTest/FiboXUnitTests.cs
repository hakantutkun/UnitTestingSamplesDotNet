using Sparky;
using Xunit;

namespace SparkyXUnitTest
{
    /// <summary>
    /// A test class for testing Fibo class methods
    /// </summary>
    public class FiboXUnitTests
    {
        /// <summary>
        /// Fibo Object
        /// </summary>
        private Fibo _fibo;

        /// <summary>
        /// Setting up the test environment
        /// </summary>
        public FiboXUnitTests()
        {
            // Create an instance of fibo
            _fibo = new Fibo();
        }

        /// <summary>
        /// Test with range = 1
        /// </summary>
        [Fact]
        public void GetFiboSeries_InputRange1_ReturnsFiboSeries()
        {
            // Arrange
            _fibo.Range = 1;
            List<int> expectedRange = new List<int>() { 0 };

            // Act
            var result = _fibo.GetFiboSeries();

            // Assert
            Assert.NotEmpty(result);
            Assert.Equal(expectedRange.OrderBy(u => u), result);
            Assert.True(result.SequenceEqual(expectedRange));
        }

        /// <summary>
        /// Test with range = 6
        /// </summary>
        [Fact]
        public void GetFiboSeries_InputRange6_ReturnsFiboSeries()
        {
            // Arrange
            _fibo.Range = 6;
            List<int> expectedRange = new List<int>() { 0, 1, 1, 2, 3, 5 };

            // Act
            var result = _fibo.GetFiboSeries();

            // Assert
            Assert.Contains(3, result);
            Assert.Equal(6,result.Count);
            Assert.DoesNotContain(4, result);
            Assert.Equal(expectedRange, result);
        }
    }
}

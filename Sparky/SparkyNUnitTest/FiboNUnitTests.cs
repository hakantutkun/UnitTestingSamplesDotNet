using NUnit.Framework;
using Sparky;

namespace SparkyNUnitTest
{
    /// <summary>
    /// A test class for testing Fibo class methods
    /// </summary>
    [TestFixture]
    internal class FiboNUnitTests
    {
        /// <summary>
        /// Fibo Object
        /// </summary>
        private Fibo _fibo;

        /// <summary>
        /// Setting up the test environment
        /// </summary>
        [SetUp] 
        public void SetUpAttribute()
        {
            // Create an instance of fibo
            _fibo = new Fibo();
        }

        /// <summary>
        /// Test with range = 1
        /// </summary>
        [Test]
        public void GetFiboSeries_InputRange1_ReturnsFiboSeries()
        {
            // Arrange
            _fibo.Range = 1;
            List<int> expectedRange = new List<int>() { 0 };

            // Act
            var result = _fibo.GetFiboSeries();

            // Assert
            Assert.That(result, Is.Not.Empty);
            Assert.That(result, Is.Ordered);
            Assert.That(result, Is.EquivalentTo(expectedRange));
        }

        /// <summary>
        /// Test with range = 6
        /// </summary>
        [Test]
        public void GetFiboSeries_InputRange6_ReturnsFiboSeries()
        {
            // Arrange
            _fibo.Range = 6;
            List<int> expectedRange = new List<int>() { 0,1,1,2,3,5 };

            // Act
            var result = _fibo.GetFiboSeries();

            // Assert
            Assert.That(result, Does.Contain(3));
            Assert.That(result.Count,Is.EqualTo(6));
            Assert.That(result, Has.No.Member(4));
            Assert.That(result, Is.EquivalentTo(expectedRange));
        }
    }
}

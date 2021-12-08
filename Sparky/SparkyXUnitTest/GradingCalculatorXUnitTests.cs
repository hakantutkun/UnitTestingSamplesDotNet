

using Sparky;
using Xunit;

namespace SparkyXUnitTest
{
    /// <summary>
    /// A Test Class for Grading Calculator Methods
    /// </summary>
    public class GradingCalculatorXUnitTests
    {
        /// <summary>
        /// Grading Calculator object
        /// </summary>
        private GradingCalculator _gradingCalculator;

        /// <summary>
        /// Setup the test class
        /// </summary>
        public GradingCalculatorXUnitTests()
        {
            // Create a instance of grading calculator
            _gradingCalculator = new GradingCalculator();
        }

        /// <summary>
        /// Test for input score -> 95, AttendancePercentage -> 90
        /// </summary>
        [Fact]
        public void GetGrade_InputScore95AndAttendancePercentage90_ShouldReturnA()
        {
            // Arrange
            _gradingCalculator.Score = 95;
            _gradingCalculator.AttendancePercentage = 90;

            // Act
            var result = _gradingCalculator.GetGrade();

            // Assert
            Assert.Equal("A", result);
        }

        /// <summary>
        /// Test for input score -> 95, AttendancePercentage -> 65
        /// </summary>
        [Fact]
        public void GetGrade_InputScore95AndAttendancePercentage65_ShouldReturnB()
        {
            // Arrange
            _gradingCalculator.Score = 95;
            _gradingCalculator.AttendancePercentage = 65;

            // Act
            var result = _gradingCalculator.GetGrade();

            // Assert
            Assert.Equal("B", result);
        }

        /// <summary>
        /// Test for input score -> 85, AttendancePercentage -> 90
        /// </summary>
        [Fact]
        public void GetGrade_InputScore85AndAttendancePercentage90_ShouldReturnB()
        {
            // Arrange
            _gradingCalculator.Score = 85;
            _gradingCalculator.AttendancePercentage = 90;

            // Act
            var result = _gradingCalculator.GetGrade();

            // Assert
            Assert.Equal("B", result);
        }

        /// <summary>
        /// Test for input score -> 65, AttendancePercentage -> 90
        /// </summary>
        [Fact]
        public void GetGrade_InputScore65AndAttendancePercentage90_ShouldReturnC()
        {
            // Arrange
            _gradingCalculator.Score = 65;
            _gradingCalculator.AttendancePercentage = 90;

            // Act
            var result = _gradingCalculator.GetGrade();

            // Assert
            Assert.Equal("C", result);
        }

        /// <summary>
        /// Test with multiple cases
        /// </summary>
        /// <param name="score">Score parameter</param>
        /// <param name="percentage">Attendance percentage parameter</param>
        [Theory]
        [InlineData(95, 55)]
        [InlineData(65, 55)]
        [InlineData(50, 90)]
        public void GetGrade_InputScoreAndAttendancePercentage_ShouldReturnF(int score, int percentage)
        {
            // Arrange
            _gradingCalculator.Score = score;
            _gradingCalculator.AttendancePercentage = percentage;

            // Act
            var result = _gradingCalculator.GetGrade();

            // Assert
            Assert.Equal("F", result);
        }

        /// <summary>
        /// Test for all the cases in the assignment
        /// </summary>
        /// <param name="score">Score parameter</param>
        /// <param name="percentage">Percentage parameter</param>
        /// <returns></returns>
        [Theory]
        [InlineData(95, 90, "A")]
        [InlineData(85, 90, "B")]
        [InlineData(65, 90, "C")]
        [InlineData(95, 65, "B")]
        [InlineData(95, 55, "F")]
        [InlineData(65, 55, "F")]
        [InlineData(50, 90, "F")]
        public void GetGrade_InputScoreAndAttendancePercentage_ShouldReturnCorrectGrade(int score, int percentage, string expectedResult)
        {
            // Arrange
            _gradingCalculator.Score = score;
            _gradingCalculator.AttendancePercentage = percentage;

            // Act
            var result = _gradingCalculator.GetGrade();

            // Assert
            Assert.Equal(expectedResult, result);
        }
    }
}

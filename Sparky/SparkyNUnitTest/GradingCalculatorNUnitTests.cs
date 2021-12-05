using NUnit.Framework;
using Sparky;

namespace SparkyNUnitTest
{
    /// <summary>
    /// A Test Class for Grading Calculator Methods
    /// </summary>
    [TestFixture]
    public class GradingCalculatorNUnitTests
    {
        /// <summary>
        /// Grading Calculator object
        /// </summary>
        private GradingCalculator _gradingCalculator;

        /// <summary>
        /// Setup the test class
        /// </summary>
        [SetUp]
        public void Setup()
        {
            // Create a instance of grading calculator
            _gradingCalculator = new GradingCalculator();
        }

        /// <summary>
        /// Test for input score -> 95, AttendancePercentage -> 90
        /// </summary>
        [Test]
        public void GetGrade_InputScore95AndAttendancePercentage90_ShouldReturnA()
        {
            // Arrange
            _gradingCalculator.Score = 95;
            _gradingCalculator.AttendancePercentage = 90;

            // Act
            var result = _gradingCalculator.GetGrade();

            // Assert
            Assert.That(result, Is.EqualTo("A"));
        }

        /// <summary>
        /// Test for input score -> 95, AttendancePercentage -> 65
        /// </summary>
        [Test]
        public void GetGrade_InputScore95AndAttendancePercentage65_ShouldReturnB()
        {
            // Arrange
            _gradingCalculator.Score = 95;
            _gradingCalculator.AttendancePercentage = 65;

            // Act
            var result = _gradingCalculator.GetGrade();

            // Assert
            Assert.That(result, Is.EqualTo("B"));
        }

        /// <summary>
        /// Test for input score -> 85, AttendancePercentage -> 90
        /// </summary>
        [Test]
        public void GetGrade_InputScore85AndAttendancePercentage90_ShouldReturnB()
        {
            // Arrange
            _gradingCalculator.Score = 85;
            _gradingCalculator.AttendancePercentage = 90;

            // Act
            var result = _gradingCalculator.GetGrade();

            // Assert
            Assert.That(result, Is.EqualTo("B"));
        }

        /// <summary>
        /// Test for input score -> 65, AttendancePercentage -> 90
        /// </summary>
        [Test]
        public void GetGrade_InputScore65AndAttendancePercentage90_ShouldReturnC()
        {
            // Arrange
            _gradingCalculator.Score = 65;
            _gradingCalculator.AttendancePercentage = 90;

            // Act
            var result = _gradingCalculator.GetGrade();

            // Assert
            Assert.That(result, Is.EqualTo("C"));
        }

        /// <summary>
        /// Test with multiple cases
        /// </summary>
        /// <param name="score">Score parameter</param>
        /// <param name="percentage">Attendance percentage parameter</param>
        [Test]
        [TestCase(95,55)]
        [TestCase(65,55)]
        [TestCase(50,90)]
        public void GetGrade_InputScoreAndAttendancePercentage_ShouldReturnF(int score, int percentage)
        {
            // Arrange
            _gradingCalculator.Score = score;
            _gradingCalculator.AttendancePercentage = percentage;

            // Act
            var result = _gradingCalculator.GetGrade();

            // Assert
            Assert.That(result, Is.EqualTo("F"));
        }

        /// <summary>
        /// Test for all the cases in the assignment
        /// </summary>
        /// <param name="score">Score parameter</param>
        /// <param name="percentage">Percentage parameter</param>
        /// <returns></returns>
        [Test]
        [TestCase(95, 90, ExpectedResult = "A")]
        [TestCase(85, 90, ExpectedResult = "B")]
        [TestCase(65, 90, ExpectedResult = "C")]
        [TestCase(95, 65, ExpectedResult = "B")]
        [TestCase(95, 55, ExpectedResult = "F")]
        [TestCase(65, 55, ExpectedResult = "F")]
        [TestCase(50, 90, ExpectedResult = "F")]
        public string GetGrade_InputScoreAndAttendancePercentage_ShouldReturnCorrectGrade(int score, int percentage)
        {
            // Arrange
            _gradingCalculator.Score = score;
            _gradingCalculator.AttendancePercentage = percentage;

            // Act
            var result = _gradingCalculator.GetGrade();

            // Assert
            return result;
        }
    }
}

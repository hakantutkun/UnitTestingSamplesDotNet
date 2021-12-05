using NUnit.Framework;
using Sparky;

namespace SparkyNUnitTest
{
    [TestFixture]
    public class CustomerNUnitTest
    {
        [Test]
        public void CombineName_InputFirstAndLastName_ReturnFullName()
        {
            // Arrange
            var customer = new Customer();

            // Act
            string fullName = customer.GreetAndCombineNames("Ben", "Spark");

            // Assert
            Assert.That(fullName, Is.EqualTo("Hello, Ben Spark"));
            Assert.That(fullName, Does.Contain(","));
            Assert.That(fullName, Does.StartWith("Hello,"));
            Assert.That(fullName, Does.EndWith("Spark"));
            Assert.That(fullName, Does.Contain("ben Spark").IgnoreCase); // IgnoreCase -> Ignores case sensitivity.

            // Asserting with regular expressions
            Assert.That(fullName, Does.Match("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
        }
    }
}

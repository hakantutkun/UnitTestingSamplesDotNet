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
            customer.GreetAndCombineNames("Ben", "Spark");

            // Assert
            Assert.That(customer.GreetMessage, Is.EqualTo("Hello, Ben Spark"));
            Assert.That(customer.GreetMessage, Does.Contain(","));
            Assert.That(customer.GreetMessage, Does.StartWith("Hello,"));
            Assert.That(customer.GreetMessage, Does.EndWith("Spark"));
            Assert.That(customer.GreetMessage, Does.Contain("ben Spark").IgnoreCase); // IgnoreCase -> Ignores case sensitivity.

            // Asserting with regular expressions
            Assert.That(customer.GreetMessage, Does.Match("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
        }
    
        [Test]
        public void GreetMessage_NotGreeted_ReturnsNull()
        {
            // Arrange
            var customer = new Customer();

            // Act

            // Assert
            Assert.IsNull(customer.GreetMessage);

        }
    }
}

using NUnit.Framework;
using Sparky;

namespace SparkyNUnitTest
{
    [TestFixture]
    public class CustomerNUnitTest
    {
        /// <summary>
        /// Global customer object.
        /// </summary>
        private Customer customer;

        /// <summary>
        /// Setup method for this test class.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            // Create a new instance of Customer class.
            customer = new Customer();
        }

        [Test]
        public void CombineName_InputFirstAndLastName_ReturnFullName()
        {
            // Arrange

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

            // Act

            // Assert
            Assert.IsNull(customer.GreetMessage);

        }

        [Test]
        public void DiscountCheck_DefaultCustomer_ReturnsDiscountInRange()
        {
            // Act
            int result = customer.Discount;
            
            // Assert
            Assert.That(result, Is.InRange(10, 25));
        }
    }
}

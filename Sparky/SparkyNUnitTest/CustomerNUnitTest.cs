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
        }
    }
}

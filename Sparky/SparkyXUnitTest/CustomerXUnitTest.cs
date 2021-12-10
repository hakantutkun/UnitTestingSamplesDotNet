using Sparky;
using Xunit;

namespace SparkyXUnitTest
{
    public class CustomerXUnitTest
    {
        /// <summary>
        /// Global customer object.
        /// </summary>
        private Customer customer;

        /// <summary>
        /// Setup method for this test class.
        /// </summary>
        public CustomerXUnitTest()
        {
            // Create a new instance of Customer class.
            customer = new Customer();
        }

        [Fact]
        public void CombineName_InputFirstAndLastName_ReturnFullName()
        {
            // Arrange

            // Act
            customer.GreetAndCombineNames("Ben", "Spark");

            // Assert
            // We should use multiple assertion to use all failures.
            // Otherwise, test will be ended as soon as first failure occured.
            // This way we can display all the failures at the end of the test process.
            Assert.Equal("Hello, Ben Spark", customer.GreetMessage);
            Assert.Contains("Ben Spark",customer.GreetMessage);
            Assert.StartsWith("Hello,", customer.GreetMessage);
            Assert.EndsWith("Spark", customer.GreetMessage);
            Assert.Matches("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", customer.GreetMessage);

        }

        [Fact]
        public void GreetMessage_NotGreeted_ReturnsNull()
        {
            // Arrange

            // Act

            // Assert
            Assert.Null(customer.GreetMessage);

        }

        [Fact]
        public void DiscountCheck_DefaultCustomer_ReturnsDiscountInRange()
        {
            // Act
            int result = customer.Discount;

            // Assert
            Assert.InRange(result,10,25);
        }

        [Fact]
        public void GreetMessage_GreetedWithoutLastName_ReturnsNotNull()
        {
            customer.GreetAndCombineNames("ben", "");

            Assert.NotNull(customer.GreetMessage);
            Assert.False(string.IsNullOrEmpty(customer.GreetMessage));
        }

        [Fact]
        public void GreetChecker_EmptyFirstName_ThrowsException()
        {
            // Arrange
            var exceptionDetails = Assert.Throws<ArgumentException>(() => customer.GreetAndCombineNames("", "Spark"));

            // Act
            Assert.Equal("Empty First Name", exceptionDetails.Message);

            // With that method
            Assert.Throws<ArgumentException>(() => customer.GreetAndCombineNames("", "Spark"));

        }

        [Fact]
        public void CustomerType_CreateCustomerWithLessThan100Order_ReturnBasicCustomer()
        {
            customer.OrderTotal = 10;

            var result = customer.GetCustomerDetails();

            Assert.IsType<BasicCustomer>(result);
        }

        [Fact]
        public void CustomerType_CreateCustomerWithMoreThan100Order_ReturnPlatinumCustomer()
        {
            customer.OrderTotal = 110;

            var result = customer.GetCustomerDetails();

            Assert.IsType<PlatinumCustomer>(result);
        }
    }
}

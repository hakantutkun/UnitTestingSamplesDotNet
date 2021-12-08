//using NUnit.Framework;
//using Sparky;

//namespace SparkyXUnitTest
//{
//    [TestFixture]
//    public class CustomerXUnitTest
//    {
//        /// <summary>
//        /// Global customer object.
//        /// </summary>
//        private Customer customer;

//        /// <summary>
//        /// Setup method for this test class.
//        /// </summary>
//        [SetUp]
//        public void Setup()
//        {
//            // Create a new instance of Customer class.
//            customer = new Customer();
//        }

//        [Test]
//        public void CombineName_InputFirstAndLastName_ReturnFullName()
//        {
//            // Arrange

//            // Act
//            customer.GreetAndCombineNames("Ben", "Spark");

//            // Assert
//            // We should use multiple assertion to use all failures.
//            // Otherwise, test will be ended as soon as first failure occured.
//            // This way we can display all the failures at the end of the test process.
//            Assert.Multiple(() =>
//            {
//                Assert.That(customer.GreetMessage, Is.EqualTo("Hello, Ben Spark"));
//                Assert.That(customer.GreetMessage, Does.Contain(","));
//                Assert.That(customer.GreetMessage, Does.StartWith("Hello,"));
//                Assert.That(customer.GreetMessage, Does.EndWith("Spark"));
//                Assert.That(customer.GreetMessage, Does.Contain("ben Spark").IgnoreCase); // IgnoreCase -> Ignores case sensitivity.
//            });

//            // Asserting with regular expressions
//            Assert.That(customer.GreetMessage, Does.Match("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
//        }
    
//        [Test]
//        public void GreetMessage_NotGreeted_ReturnsNull()
//        {
//            // Arrange

//            // Act

//            // Assert
//            Assert.IsNull(customer.GreetMessage);

//        }

//        [Test]
//        public void DiscountCheck_DefaultCustomer_ReturnsDiscountInRange()
//        {
//            // Act
//            int result = customer.Discount;
            
//            // Assert
//            Assert.That(result, Is.InRange(10, 25));
//        }

//        [Test]
//        public void GreetMessage_GreetedWithoutLastName_ReturnsNotNull()
//        {
//            customer.GreetAndCombineNames("ben", "");

//            Assert.IsNotNull(customer.GreetMessage);
//            Assert.IsFalse(string.IsNullOrEmpty(customer.GreetMessage));
//        }

//        [Test]
//        public void GreetChecker_EmptyFirstName_ThrowsException()
//        {
//            // Arrange
//            var exceptionDetails = Assert.Throws<ArgumentException>(() => customer.GreetAndCombineNames("", "Spark"));
            
//            // Act
//            Assert.AreEqual("Empty First Name", exceptionDetails.Message);

//            // With that method
//            Assert.That(() => customer.GreetAndCombineNames("", "spark"), Throws.ArgumentException.With.Message.EqualTo("Empty First Name"));



//            // Arrange
//            Assert.Throws<ArgumentException>(() => customer.GreetAndCombineNames("", "Spark"));

//            // With that method
//            Assert.That(() => customer.GreetAndCombineNames("", "spark"), Throws.ArgumentException);
//        }

//        [Test]
//        public void CustomerType_CreateCustomerWithLessThan100Order_ReturnBasicCustomer()
//        {
//            customer.OrderTotal = 10;

//            var result = customer.GetCustomerDetails();

//            Assert.That(result, Is.TypeOf<BasicCustomer>());
//        }

//        [Test]
//        public void CustomerType_CreateCustomerWithMoreThan100Order_ReturnPlatinumCustomer()
//        {
//            customer.OrderTotal = 110;

//            var result = customer.GetCustomerDetails();

//            Assert.That(result, Is.TypeOf<PlatinumCustomer>());
//        }
//    }
//}

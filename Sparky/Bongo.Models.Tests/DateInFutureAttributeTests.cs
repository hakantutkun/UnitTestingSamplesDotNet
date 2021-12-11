using Bongo.Models.ModelValidations;
using NUnit.Framework;

namespace Bongo.Models.Tests
{
    /// <summary>
    /// Test Class for <see cref="DateInFutureAttribute"/>
    /// </summary>
    [TestFixture]
    public class DateInFutureAttributeTests
    {
        /// <summary>
        /// Date Validator Test
        /// </summary>
        /// <param name="addTime"></param>
        /// <returns></returns>
        [TestCase(100, ExpectedResult = true)]
        [TestCase(-100, ExpectedResult = false)]
        [TestCase(0, ExpectedResult = false)]
        
        public bool DateValidator_InputExpectedDateRange_DateValidity(int addTime)
        {
            DateInFutureAttribute dateInFutureAttribute = new DateInFutureAttribute(() => DateTime.Now);

            return dateInFutureAttribute.IsValid(DateTime.Now.AddSeconds(addTime));
        }

        /// <summary>
        /// Date Validator
        /// Checks if error message received when invalid date sent.
        /// </summary>
        [Test]
        public void DateValidator_NotValidDate_ReturnErrorMessage()
        {
            var result = new DateInFutureAttribute();

            Assert.AreEqual("Date must be in the future", result.ErrorMessage);
        }
    }
}

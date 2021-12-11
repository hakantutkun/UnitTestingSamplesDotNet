using Bongo.Models.ModelValidations;
using NUnit.Framework;

namespace Bongo.Models.Tests
{
    [TestFixture]
    public class DateInFutureAttributeTests
    {
        [Test]
        
        public void DateValidator_InputExpectedDateRange_DateValidity()
        {
            DateInFutureAttribute dateInFutureAttribute = new DateInFutureAttribute(() => DateTime.Now);

            var result = dateInFutureAttribute.IsValid(DateTime.Now.AddSeconds(100));

            Assert.AreEqual(true, result);
        }
    }
}

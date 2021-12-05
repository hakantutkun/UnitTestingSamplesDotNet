using NUnit.Framework;
using Sparky;

namespace SparkyNUnitTest
{
    [TestFixture]
    public class BankAccountNUnitTest
    {
        private BankAccount _bankAccount;

        [SetUp]
        public void Setup()
        {
            _bankAccount = new(new FakeLogger());
        }

        [Test]
        public void BankDeposit_Add100_ReturnTrue()
        {
            var result = _bankAccount.Deposit(100);

            Assert.IsTrue(result);
            Assert.That(_bankAccount.GetBalance, Is.EqualTo(100));
        }

    }
}

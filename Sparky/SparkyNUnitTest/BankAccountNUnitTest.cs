using Moq;
using NUnit.Framework;
using Sparky;

namespace SparkyNUnitTest
{
    [TestFixture]
    public class BankAccountNUnitTest
    {
        private BankAccount account;

        [SetUp]
        public void Setup()
        {
            
        }

        //[Test]
        //public void BankDepositLogFakker_Add100_ReturnTrue()
        //{
        //    BankAccount bankAccount = new(new FakeLogger());
        //    var result = bankAccount.Deposit(100);

        //    Assert.IsTrue(result);
        //    Assert.That(bankAccount.GetBalance, Is.EqualTo(100));
        //}

        [Test]
        public void BankDeposit_Add100_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();

            BankAccount bankAccount = new(logMock.Object);
            var result = bankAccount.Deposit(100);

            Assert.IsTrue(result);
            Assert.That(bankAccount.GetBalance, Is.EqualTo(100));
        }

        [Test]
        [TestCase(200,100)]
        [TestCase(200,150)]
        public void BankWithdraw_Withdraw100With200Balance_ReturnsTrue(int balance, int withdraw)
        {
            var logMock = new Mock<ILogBook>();
            logMock.Setup(u => u.LogToDb(It.IsAny<string>())).Returns(true);
            logMock.Setup(u => u.LogBalanceAfterWithDrawal(It.Is<int>(x => x > 0 ))).Returns(true);

            BankAccount bankAccount = new(logMock.Object);
            bankAccount.Deposit(balance);

            var result = bankAccount.Withdraw(withdraw);

            Assert.IsTrue(result);


        }

        [Test]
        [TestCase(200, 300)]
        public void BankWithdraw_Withdraw300With200Balance_ReturnsFalse(int balance, int withdraw)
        {
            var logMock = new Mock<ILogBook>();

            logMock.Setup(u => u.LogBalanceAfterWithDrawal(It.Is<int>(x => x > 0))).Returns(true);
            logMock.Setup(u => u.LogBalanceAfterWithDrawal(It.Is<int>(x => x < 0))).Returns(false);
            logMock.Setup(u => u.LogBalanceAfterWithDrawal(It.IsInRange<int>(int.MinValue, -1, Moq.Range.Inclusive))).Returns(false);

            BankAccount bankAccount = new(logMock.Object);
            bankAccount.Deposit(balance);

            var result = bankAccount.Withdraw(withdraw);

            Assert.IsFalse(result);


        }

        [Test]
        public void BankWithdraw_LogMockString_ReturnsTrue()
        {
            var logMock = new Mock<ILogBook>();
            string desiredOutput = "hello";

            logMock.Setup(u => u.MessageWithReturnStr(It.IsAny<string>())).Returns((string str) => str.ToLower());

            Assert.That(logMock.Object.MessageWithReturnStr("HEllo"), Is.EqualTo(desiredOutput));
        }

    }
}

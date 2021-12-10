using Moq;
using Sparky;
using Xunit;

namespace SparkyXUnitTest
{
    public class BankAccountXUnitTest
    {
        private BankAccount account;

        [Fact]
        public void BankDeposit_Add100_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();

            BankAccount bankAccount = new(logMock.Object);
            var result = bankAccount.Deposit(100);

            Assert.True(result);
            Assert.Equal(100,bankAccount.GetBalance());
        }

        [Theory]
        [InlineData(200, 100)]
        [InlineData(200, 150)]
        public void BankWithdraw_Withdraw100With200Balance_ReturnsTrue(int balance, int withdraw)
        {
            var logMock = new Mock<ILogBook>();
            logMock.Setup(u => u.LogToDb(It.IsAny<string>())).Returns(true);
            logMock.Setup(u => u.LogBalanceAfterWithDrawal(It.Is<int>(x => x > 0))).Returns(true);

            BankAccount bankAccount = new(logMock.Object);
            bankAccount.Deposit(balance);

            var result = bankAccount.Withdraw(withdraw);

            Assert.True(result);


        }

        [Theory]
        [InlineData(200, 300)]
        public void BankWithdraw_Withdraw300With200Balance_ReturnsFalse(int balance, int withdraw)
        {
            var logMock = new Mock<ILogBook>();

            logMock.Setup(u => u.LogBalanceAfterWithDrawal(It.Is<int>(x => x > 0))).Returns(true);
            logMock.Setup(u => u.LogBalanceAfterWithDrawal(It.Is<int>(x => x < 0))).Returns(false);
            logMock.Setup(u => u.LogBalanceAfterWithDrawal(It.IsInRange<int>(int.MinValue, -1, Moq.Range.Inclusive))).Returns(false);

            BankAccount bankAccount = new(logMock.Object);
            bankAccount.Deposit(balance);

            var result = bankAccount.Withdraw(withdraw);

            Assert.False(result);


        }

        [Fact]
        public void BankLogDummy_LogMockString_ReturnsTrue()
        {
            var logMock = new Mock<ILogBook>();
            string desiredOutput = "hello";

            logMock.Setup(u => u.MessageWithReturnStr(It.IsAny<string>())).Returns((string str) => str.ToLower());

            Assert.Equal(desiredOutput, logMock.Object.MessageWithReturnStr("HEllo"));
        }

        [Fact]
        public void BankLogDummy_LogMockStringOutoutStr_ReturnsTrue()
        {
            var logMock = new Mock<ILogBook>();
            string desiredOutput = "hello";

            logMock.Setup(u => u.LogWithOutputResult(It.IsAny<string>(), out desiredOutput)).Returns(true);

            string result = "";

            Assert.True(logMock.Object.LogWithOutputResult("Ben", out result));

            Assert.Equal(desiredOutput,result);
        }

        [Fact]
        public void BankLogDummy_LogRefChecker_ReturnsTrue()
        {
            var logMock = new Mock<ILogBook>();

            Customer customer = new();
            Customer customerNotUsed = new();

            logMock.Setup(u => u.LogWithRefObj(ref customer)).Returns(true);

            Assert.False(logMock.Object.LogWithRefObj(ref customerNotUsed));
            Assert.True(logMock.Object.LogWithRefObj(ref customer));
        }

        [Fact]
        public void BankLogDummy_SetAndGetLogTypeAndSeveirtyMock_MockTest()
        {
            var logMock = new Mock<ILogBook>();

            // Should be addded for change property values.
            logMock.SetupAllProperties();

            logMock.Setup(u => u.LogSeverity).Returns(10);
            logMock.Setup(u => u.LogType).Returns("warning");

            // Change propery value
            logMock.Object.LogSeverity = 100;

            Assert.Equal(100,logMock.Object.LogSeverity);
            Assert.Equal("warning",logMock.Object.LogType);

            // callbacks
            string logTemp = "Hello, ";
            logMock.Setup(u => u.LogToDb(It.IsAny<string>())).Returns(true).Callback((string str) => logTemp += str);

            logMock.Object.LogToDb("Ben");
            Assert.Equal("Hello, Ben", logTemp);

            // callbacks
            int counter = 5;
            logMock.Setup(u => u.LogToDb(It.IsAny<string>()))
                    .Callback(() => counter++)
                    .Returns(true)
                    .Callback(() => counter++);

            logMock.Object.LogToDb("Ben");
            logMock.Object.LogToDb("Ben");
            Assert.Equal(9,counter);

        }

        [Fact]
        public void BankLogDummy_VerifyExample()
        {
            var logMock = new Mock<ILogBook>();

            BankAccount bankAccount = new(logMock.Object);

            bankAccount.Deposit(100);
            Assert.Equal(100,bankAccount.GetBalance());

            // verification -> we verify that this message method called two times in this process.
            logMock.Verify(u => u.Message(It.IsAny<string>()), Times.Exactly(2));
            logMock.Verify(u => u.Message("Test"), Times.AtLeastOnce);

            // verify that logSeverity set to 101 once.
            logMock.VerifySet(u => u.LogSeverity = 101, Times.Once);

            // verify that logSeverity getter called once.
            logMock.VerifyGet(u => u.LogSeverity, Times.Once);
        }

    }
}

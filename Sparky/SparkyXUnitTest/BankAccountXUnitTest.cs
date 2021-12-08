//using Moq;
//using NUnit.Framework;
//using Sparky;

//namespace SparkyXUnitTest
//{
//    [TestFixture]
//    public class BankAccountXUnitTest
//    {
//        private BankAccount account;

//        [SetUp]
//        public void Setup()
//        {

//        }

//        //[Test]
//        //public void BankDepositLogFakker_Add100_ReturnTrue()
//        //{
//        //    BankAccount bankAccount = new(new FakeLogger());
//        //    var result = bankAccount.Deposit(100);

//        //    Assert.IsTrue(result);
//        //    Assert.That(bankAccount.GetBalance, Is.EqualTo(100));
//        //}

//        [Test]
//        public void BankDeposit_Add100_ReturnTrue()
//        {
//            var logMock = new Mock<ILogBook>();

//            BankAccount bankAccount = new(logMock.Object);
//            var result = bankAccount.Deposit(100);

//            Assert.IsTrue(result);
//            Assert.That(bankAccount.GetBalance, Is.EqualTo(100));
//        }

//        [Test]
//        [TestCase(200, 100)]
//        [TestCase(200, 150)]
//        public void BankWithdraw_Withdraw100With200Balance_ReturnsTrue(int balance, int withdraw)
//        {
//            var logMock = new Mock<ILogBook>();
//            logMock.Setup(u => u.LogToDb(It.IsAny<string>())).Returns(true);
//            logMock.Setup(u => u.LogBalanceAfterWithDrawal(It.Is<int>(x => x > 0))).Returns(true);

//            BankAccount bankAccount = new(logMock.Object);
//            bankAccount.Deposit(balance);

//            var result = bankAccount.Withdraw(withdraw);

//            Assert.IsTrue(result);


//        }

//        [Test]
//        [TestCase(200, 300)]
//        public void BankWithdraw_Withdraw300With200Balance_ReturnsFalse(int balance, int withdraw)
//        {
//            var logMock = new Mock<ILogBook>();

//            logMock.Setup(u => u.LogBalanceAfterWithDrawal(It.Is<int>(x => x > 0))).Returns(true);
//            logMock.Setup(u => u.LogBalanceAfterWithDrawal(It.Is<int>(x => x < 0))).Returns(false);
//            logMock.Setup(u => u.LogBalanceAfterWithDrawal(It.IsInRange<int>(int.MinValue, -1, Moq.Range.Inclusive))).Returns(false);

//            BankAccount bankAccount = new(logMock.Object);
//            bankAccount.Deposit(balance);

//            var result = bankAccount.Withdraw(withdraw);

//            Assert.IsFalse(result);


//        }

//        [Test]
//        public void BankLogDummy_LogMockString_ReturnsTrue()
//        {
//            var logMock = new Mock<ILogBook>();
//            string desiredOutput = "hello";

//            logMock.Setup(u => u.MessageWithReturnStr(It.IsAny<string>())).Returns((string str) => str.ToLower());

//            Assert.That(logMock.Object.MessageWithReturnStr("HEllo"), Is.EqualTo(desiredOutput));
//        }

//        [Test]
//        public void BankLogDummy_LogMockStringOutoutStr_ReturnsTrue()
//        {
//            var logMock = new Mock<ILogBook>();
//            string desiredOutput = "hello";

//            logMock.Setup(u => u.LogWithOutputResult(It.IsAny<string>(), out desiredOutput)).Returns(true);

//            string result = "";

//            Assert.IsTrue(logMock.Object.LogWithOutputResult("Ben", out result));

//            Assert.That(result, Is.EqualTo(desiredOutput));
//        }

//        [Test]
//        public void BankLogDummy_LogRefChecker_ReturnsTrue()
//        {
//            var logMock = new Mock<ILogBook>();

//            Customer customer = new();
//            Customer customerNotUsed = new();

//            logMock.Setup(u => u.LogWithRefObj(ref customer)).Returns(true);

//            Assert.IsFalse(logMock.Object.LogWithRefObj(ref customerNotUsed));
//            Assert.IsTrue(logMock.Object.LogWithRefObj(ref customer));
//        }

//        [Test]
//        public void BankLogDummy_SetAndGetLogTypeAndSeveirtyMock_MockTest()
//        {
//            var logMock = new Mock<ILogBook>();

//            // Should be addded for change property values.
//            logMock.SetupAllProperties();

//            logMock.Setup(u => u.LogSeverity).Returns(10);
//            logMock.Setup(u => u.LogType).Returns("warning");

//            // Change propery value
//            logMock.Object.LogSeverity = 100;

//            Assert.That(logMock.Object.LogSeverity, Is.EqualTo(100));
//            Assert.That(logMock.Object.LogType, Is.EqualTo("warning"));

//            // callbacks
//            string logTemp = "Hello, ";
//            logMock.Setup(u => u.LogToDb(It.IsAny<string>())).Returns(true).Callback((string str) => logTemp += str);

//            logMock.Object.LogToDb("Ben");
//            Assert.That(logTemp, Is.EqualTo("Hello, Ben"));

//            // callbacks
//            int counter = 5;
//            logMock.Setup(u => u.LogToDb(It.IsAny<string>()))
//                    .Callback(() => counter++)
//                    .Returns(true)
//                    .Callback(() => counter++);

//            logMock.Object.LogToDb("Ben");
//            logMock.Object.LogToDb("Ben");
//            Assert.That(counter, Is.EqualTo(9));

//        }

//        [Test]
//        public void BankLogDummy_VerifyExample()
//        {
//            var logMock = new Mock<ILogBook>();

//            BankAccount bankAccount = new(logMock.Object);

//            bankAccount.Deposit(100);
//            Assert.That(bankAccount.GetBalance, Is.EqualTo(100));

//            // verification -> we verify that this message method called two times in this process.
//            logMock.Verify(u => u.Message(It.IsAny<string>()), Times.Exactly(2));
//            logMock.Verify(u => u.Message("Test"), Times.AtLeastOnce);

//            // verify that logSeverity set to 101 once.
//            logMock.VerifySet(u => u.LogSeverity = 101, Times.Once);

//            // verify that logSeverity getter called once.
//            logMock.VerifyGet(u => u.LogSeverity, Times.Once);
//        }

//    }
//}

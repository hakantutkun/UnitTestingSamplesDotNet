namespace Sparky
{
    public class BankAccount
    {
        public int Balance { get; set; }
        private readonly ILogBook _logBook;

        public BankAccount(ILogBook logBook)
        {
            _logBook = logBook;
            Balance = 0;
        }

        public bool Deposit(int amount)
        {
            _logBook.Message("Deposit Invoked");
            _logBook.Message("Test");
            _logBook.LogSeverity = 101;

            var temp = _logBook.LogSeverity;

            Balance += amount;
            return true;
        }

        public bool Withdraw(int amount)
        {
            if (amount <= Balance)
            {
                _logBook.LogToDb("WithDrawal Amount : " + amount.ToString());
                Balance -= amount;
                return _logBook.LogBalanceAfterWithDrawal(Balance);
            }
            return _logBook.LogBalanceAfterWithDrawal(Balance-amount);
        }

        public int GetBalance()
        {
            return Balance;
        }

    }
}

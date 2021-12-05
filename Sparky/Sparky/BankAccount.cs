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
            Balance += amount;
            return true;
        }

        public bool Withdraw(int amount)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }

        public int GetBalance()
        {
            return Balance;
        }

    }
}

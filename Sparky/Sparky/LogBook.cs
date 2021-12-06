namespace Sparky
{
    public interface ILogBook
    {
        void Message(string message);

        bool LogToDb(string message);

        bool LogBalanceAfterWithDrawal(int balanceAfterWithDrawal);
    }

    public class LogBook : ILogBook
    {
        public bool LogBalanceAfterWithDrawal(int balanceAfterWithDrawal)
        {
            if(balanceAfterWithDrawal >= 0)
            {
                Console.WriteLine("Success");
                return true;
            }
            Console.WriteLine("failure");
            return false;
        }

        public bool LogToDb(string message)
        {
            Console.Write(message);
            return true;
        }

        public void Message(string message)
        {
            Console.WriteLine(message);
        }
    }

    //public class FakeLogger : ILogBook
    //{
    //    public void Message(string message)
    //    {
            
    //    }
    //}
}

﻿namespace Sparky
{
    public interface ILogBook
    {
        public int LogSeverity { get; set; }
        public string LogType { get; set; }

        void Message(string message);

        bool LogToDb(string message);

        bool LogBalanceAfterWithDrawal(int balanceAfterWithDrawal);

        string MessageWithReturnStr(string message);

        bool LogWithOutputResult(string str, out string outputStr);

        bool LogWithRefObj(ref Customer customer);
    }

    public class LogBook : ILogBook
    {
        public int LogSeverity {get; set; } 
        public string LogType { get; set; }

        public bool LogBalanceAfterWithDrawal(int balanceAfterWithDrawal)
        {
            if (balanceAfterWithDrawal >= 0)
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

        public bool LogWithOutputResult(string str, out string outputStr)
        {
            outputStr = "Hello " + str;
            return true;
        }

        public bool LogWithRefObj(ref Customer customer)
        {
            return true;
        }

        public void Message(string message)
        {
            Console.WriteLine(message);
        }

        public string MessageWithReturnStr(string message)
        {
            Console.WriteLine(message);
            return message.ToLower();
        }
    }

    //public class FakeLogger : ILogBook
    //{
    //    public void Message(string message)
    //    {

    //    }
    //}
}

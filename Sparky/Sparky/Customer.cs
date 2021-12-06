namespace Sparky
{
    public interface ICustomer
    {
        int Discount { get; set; }

        int OrderTotal { get; set; }

        string GreetMessage { get; set; }

        bool IsPlatinum { get; set; }

        string GreetAndCombineNames(string firstName, string lastName);

        CustomerType GetCustomerDetails();

    }

        public class Customer : ICustomer
    {
        /// <summary>
        /// The amount of the discount
        /// </summary>
        public int Discount { get; set; }

        public int OrderTotal { get; set; }

        /// <summary>
        /// Greet Message
        /// </summary>
        public string GreetMessage { get; set; }

        public bool IsPlatinum { get; set; }

        public Customer()
        {
            Discount = 15;
            IsPlatinum = false;
        }

        /// <summary>
        /// Greets the user and combine the given names.
        /// </summary>
        /// <param name="firstName">Name</param>
        /// <param name="LastName">Surname</param>
        /// <returns></returns>
        public string GreetAndCombineNames(string firstName, string LastName)
        {
            // Check if first name null or has white space
            if(string.IsNullOrWhiteSpace(firstName))
            {
                // Throw an exception
                throw new ArgumentException("Empty First Name");
            }

            GreetMessage = $"Hello, {firstName} {LastName}";

            Discount = 20;

            return GreetMessage;
        }

        public CustomerType GetCustomerDetails()
        {
            if(OrderTotal < 100)
            {
                return new BasicCustomer();
            }

            return new PlatinumCustomer();
        }
    }

    public class CustomerType { }

    public class BasicCustomer: CustomerType { }

    public class PlatinumCustomer : CustomerType { }
}

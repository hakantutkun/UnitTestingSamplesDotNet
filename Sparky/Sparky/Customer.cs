namespace Sparky
{
    public class Customer
    {
        /// <summary>
        /// The amount of the discount
        /// </summary>
        public int Discount = 15;

        /// <summary>
        /// Greet Message
        /// </summary>
        public string GreetMessage { get; set; }

        /// <summary>
        /// Greets the user and combine the given names.
        /// </summary>
        /// <param name="firstName">Name</param>
        /// <param name="LastName">Surname</param>
        /// <returns></returns>
        public string GreetAndCombineNames(string firstName, string LastName)
        {
            GreetMessage = $"Hello, {firstName} {LastName}";

            Discount = 20;

            return GreetMessage;
        }
    }
}

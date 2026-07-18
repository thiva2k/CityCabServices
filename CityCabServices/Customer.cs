namespace CityCabServices
{
    public class Customer
    {
        // Properties with getters and setters
        public string CustomerID { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        // Constructor
        public Customer(string customerID, string name, string phoneNumber)
        {
            CustomerID = customerID;
            Name = name;
            PhoneNumber = phoneNumber;
        }

        // ToString override
        public override string ToString()
        {
            return $"Customer ID: {CustomerID}, Name: {Name}, Phone: {PhoneNumber}";
        }
    }
}

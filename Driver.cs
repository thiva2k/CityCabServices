namespace CityCabServices
{
    public class Driver
    {
        // Properties with getters and setters
        public string DriverID { get; set; }
        public string Name { get; set; }
        public string LicenseNumber { get; set; }

        // Constructor
        public Driver(string driverID, string name, string licenseNumber)
        {
            DriverID = driverID;
            Name = name;
            LicenseNumber = licenseNumber;
        }

        // ToString override
        public override string ToString()
        {
            return $"Driver ID: {DriverID}, Name: {Name}, License: {LicenseNumber}";
        }
    }
}

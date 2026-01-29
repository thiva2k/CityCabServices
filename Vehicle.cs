namespace CityCabServices
{
    public abstract class Vehicle
    {
        // Properties with getters and setters
        public int VehicleID { get; set; }
        public string Model { get; set; }
        public int SeatingCapacity { get; set; }
        public Driver AssignedDriver { get; set; }

        // Constructor
        protected Vehicle(int vehicleID, string model, int seatingCapacity)
        {
            VehicleID = vehicleID;
            Model = model;
            SeatingCapacity = seatingCapacity;
            AssignedDriver = null;
        }

        // Method to assign a driver
        public void AssignDriver(Driver driver)
        {
            AssignedDriver = driver;
        }

        // Abstract method to be implemented by derived classes
        public abstract string GetVehicleType();

        // ToString override
        public override string ToString()
        {
            string driverInfo = AssignedDriver != null ? AssignedDriver.ToString() : "No driver assigned";
            return $"Vehicle ID: {VehicleID}, Model: {Model}, Capacity: {SeatingCapacity}, Type: {GetVehicleType()}, Driver: {driverInfo}";
        }
    }
}

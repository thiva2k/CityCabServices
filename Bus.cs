namespace CityCabServices
{
    public class Bus : Vehicle
    {
        // Additional property specific to Bus
        public string RouteNumber { get; set; }

        // Constructor
        public Bus(int vehicleID, string model, int seatingCapacity, string routeNumber)
            : base(vehicleID, model, seatingCapacity)
        {
            RouteNumber = routeNumber;
        }

        // Override abstract method
        public override string GetVehicleType()
        {
            return $"Bus (Route: {RouteNumber})";
        }

        // ToString override
        public override string ToString()
        {
            return base.ToString();
        }
    }
}

namespace CityCabServices
{
    public class Car : Vehicle
    {
        // Additional property specific to Car
        public string CarType { get; set; }

        // Constructor
        public Car(int vehicleID, string model, int seatingCapacity, string carType)
            : base(vehicleID, model, seatingCapacity)
        {
            CarType = carType;
        }

        // Override abstract method
        public override string GetVehicleType()
        {
            return $"Car ({CarType})";
        }

        // ToString override
        public override string ToString()
        {
            return base.ToString();
        }
    }
}

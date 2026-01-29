using System;

namespace CityCabServices
{
    public class Trip
    {
        // Properties with getters and setters
        public string TripID { get; set; }
        public Customer Customer { get; set; }
        public Vehicle Vehicle { get; set; }
        public DateTime Date { get; set; }

        // Constructor
        public Trip(string tripID, Customer customer, Vehicle vehicle, DateTime date)
        {
            if (vehicle.AssignedDriver == null)
            {
                throw new InvalidOperationException("Cannot create trip: Vehicle must have an assigned driver.");
            }

            TripID = tripID;
            Customer = customer;
            Vehicle = vehicle;
            Date = date;
        }

        // ToString override
        public override string ToString()
        {
            return $"Trip ID: {TripID}, Date: {Date.ToShortDateString()}, Customer: {Customer.Name}, Vehicle: {Vehicle.Model} (ID: {Vehicle.VehicleID}), Driver: {Vehicle.AssignedDriver.Name}";
        }
    }
}

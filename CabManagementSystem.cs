using System;
using System.Collections.Generic;
using System.Linq;

namespace CityCabServices
{
    public class CabManagementSystem
    {
        // Properties with getters and setters (collections)
        public List<Driver> Drivers { get; set; }
        public List<Vehicle> Vehicles { get; set; }
        public List<Customer> Customers { get; set; }
        public List<Trip> Trips { get; set; }

        // Constructor
        public CabManagementSystem()
        {
            Drivers = new List<Driver>();
            Vehicles = new List<Vehicle>();
            Customers = new List<Customer>();
            Trips = new List<Trip>();
        }

        // Method to add a driver
        public void AddDriver(Driver driver)
        {
            if (Drivers.Any(d => d.DriverID == driver.DriverID))
            {
                throw new InvalidOperationException($"Driver with ID {driver.DriverID} already exists.");
            }
            Drivers.Add(driver);
        }

        // Method to add a vehicle
        public void AddVehicle(Vehicle vehicle)
        {
            if (Vehicles.Any(v => v.VehicleID == vehicle.VehicleID))
            {
                throw new InvalidOperationException($"Vehicle with ID {vehicle.VehicleID} already exists.");
            }
            Vehicles.Add(vehicle);
        }

        // Method to assign a driver to a vehicle
        public void AssignDriverToVehicle(string driverID, int vehicleID)
        {
            Driver driver = Drivers.FirstOrDefault(d => d.DriverID == driverID);
            if (driver == null)
            {
                throw new InvalidOperationException($"Driver with ID {driverID} not found.");
            }

            Vehicle vehicle = Vehicles.FirstOrDefault(v => v.VehicleID == vehicleID);
            if (vehicle == null)
            {
                throw new InvalidOperationException($"Vehicle with ID {vehicleID} not found.");
            }

            vehicle.AssignDriver(driver);
        }

        // Method to add a customer
        public void AddCustomer(Customer customer)
        {
            if (Customers.Any(c => c.CustomerID == customer.CustomerID))
            {
                throw new InvalidOperationException($"Customer with ID {customer.CustomerID} already exists.");
            }
            Customers.Add(customer);
        }

        // Method to add a trip
        public void AddTrip(Trip trip)
        {
            if (Trips.Any(t => t.TripID == trip.TripID))
            {
                throw new InvalidOperationException($"Trip with ID {trip.TripID} already exists.");
            }
            Trips.Add(trip);
        }

        // Method to get a driver by ID
        public Driver GetDriverByID(string driverID)
        {
            return Drivers.FirstOrDefault(d => d.DriverID == driverID);
        }

        // Method to get a vehicle by ID
        public Vehicle GetVehicleByID(int vehicleID)
        {
            return Vehicles.FirstOrDefault(v => v.VehicleID == vehicleID);
        }

        // Method to get a customer by ID
        public Customer GetCustomerByID(string customerID)
        {
            return Customers.FirstOrDefault(c => c.CustomerID == customerID);
        }

        // Method to list all vehicles with driver details
        public void ListAllVehiclesWithDrivers()
        {
            if (Vehicles.Count == 0)
            {
                Console.WriteLine("No vehicles found.");
                return;
            }

            Console.WriteLine("\n=== All Vehicles ===");
            foreach (var vehicle in Vehicles)
            {
                Console.WriteLine(vehicle.ToString());
            }
        }

        // Method to list all drivers
        public void ListAllDrivers()
        {
            if (Drivers.Count == 0)
            {
                Console.WriteLine("No drivers found.");
                return;
            }

            Console.WriteLine("\n=== All Drivers ===");
            foreach (var driver in Drivers)
            {
                Console.WriteLine(driver.ToString());
            }
        }

        // Method to list all trips
        public void ListAllTrips()
        {
            if (Trips.Count == 0)
            {
                Console.WriteLine("No trips found.");
                return;
            }

            Console.WriteLine("\n=== All Trips ===");
            foreach (var trip in Trips)
            {
                Console.WriteLine(trip.ToString());
            }
        }
    }
}

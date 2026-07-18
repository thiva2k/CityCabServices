using System;

namespace CityCabServices
{
    public class MenuHandler
    {
        private CabManagementSystem _cabSystem;

        // Constructor
        public MenuHandler(CabManagementSystem cabSystem)
        {
            _cabSystem = cabSystem;
        }

        // Display the menu
        public void DisplayMenu()
        {
            Console.WriteLine("\n=== CityCab Services Management System ===");
            Console.WriteLine("1. Add a driver");
            Console.WriteLine("2. Add a vehicle (Car or Bus)");
            Console.WriteLine("3. Assign a driver to a vehicle");
            Console.WriteLine("4. Add a trip");
            Console.WriteLine("5. List all vehicles with driver details");
            Console.WriteLine("6. List drivers");
            Console.WriteLine("7. List all trips");
            Console.WriteLine("8. Exit the app");
            Console.Write("Enter your choice: ");
        }

        // Process menu choice
        public bool ProcessMenuChoice(string choice)
        {
            try
            {
                switch (choice)
                {
                    case "1":
                        AddDriverMenu();
                        break;
                    case "2":
                        AddVehicleMenu();
                        break;
                    case "3":
                        AssignDriverToVehicleMenu();
                        break;
                    case "4":
                        AddTripMenu();
                        break;
                    case "5":
                        _cabSystem.ListAllVehiclesWithDrivers();
                        break;
                    case "6":
                        _cabSystem.ListAllDrivers();
                        break;
                    case "7":
                        _cabSystem.ListAllTrips();
                        break;
                    case "8":
                        Console.WriteLine("Exiting the application. Goodbye!");
                        return false;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return true;
        }

        // Menu to add a driver
        private void AddDriverMenu()
        {
            Console.WriteLine("\n=== Add Driver ===");
            Console.Write("Enter Driver ID: ");
            string driverID = Console.ReadLine();

            Console.Write("Enter Driver Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter License Number: ");
            string licenseNumber = Console.ReadLine();

            Driver driver = new Driver(driverID, name, licenseNumber);
            _cabSystem.AddDriver(driver);
            Console.WriteLine("Driver added successfully!");
        }

        // Menu to add a vehicle
        private void AddVehicleMenu()
        {
            Console.WriteLine("\n=== Add Vehicle ===");
            Console.WriteLine("1. Add Car");
            Console.WriteLine("2. Add Bus");
            Console.Write("Enter choice: ");
            string vehicleChoice = Console.ReadLine();

            Console.Write("Enter Vehicle ID: ");
            int vehicleID = int.Parse(Console.ReadLine());

            Console.Write("Enter Model: ");
            string model = Console.ReadLine();

            Console.Write("Enter Seating Capacity: ");
            int capacity = int.Parse(Console.ReadLine());

            if (vehicleChoice == "1")
            {
                Console.Write("Enter Car Type (e.g., Hybrid, Sedan): ");
                string carType = Console.ReadLine();

                Car car = new Car(vehicleID, model, capacity, carType);
                _cabSystem.AddVehicle(car);
                Console.WriteLine("Car added successfully!");
            }
            else if (vehicleChoice == "2")
            {
                Console.Write("Enter Route Number (e.g., B12): ");
                string routeNumber = Console.ReadLine();

                Bus bus = new Bus(vehicleID, model, capacity, routeNumber);
                _cabSystem.AddVehicle(bus);
                Console.WriteLine("Bus added successfully!");
            }
            else
            {
                Console.WriteLine("Invalid vehicle type choice.");
            }
        }

        // Menu to assign a driver to a vehicle
        private void AssignDriverToVehicleMenu()
        {
            Console.WriteLine("\n=== Assign Driver to Vehicle ===");
            Console.Write("Enter Driver ID: ");
            string driverID = Console.ReadLine();

            Console.Write("Enter Vehicle ID: ");
            int vehicleID = int.Parse(Console.ReadLine());

            _cabSystem.AssignDriverToVehicle(driverID, vehicleID);
            Console.WriteLine("Driver assigned to vehicle successfully!");
        }

        // Menu to add a trip
        private void AddTripMenu()
        {
            Console.WriteLine("\n=== Add Trip ===");
            Console.Write("Enter Trip ID: ");
            string tripID = Console.ReadLine();

            // Get or create customer
            Console.Write("Enter Customer ID: ");
            string customerID = Console.ReadLine();

            Customer customer = _cabSystem.GetCustomerByID(customerID);
            if (customer == null)
            {
                Console.Write("Customer not found. Enter Customer Name: ");
                string customerName = Console.ReadLine();

                Console.Write("Enter Phone Number: ");
                string phoneNumber = Console.ReadLine();

                customer = new Customer(customerID, customerName, phoneNumber);
                _cabSystem.AddCustomer(customer);
                Console.WriteLine("Customer added successfully!");
            }

            // Get vehicle
            Console.Write("Enter Vehicle ID: ");
            int vehicleID = int.Parse(Console.ReadLine());

            Vehicle vehicle = _cabSystem.GetVehicleByID(vehicleID);
            if (vehicle == null)
            {
                throw new InvalidOperationException("Vehicle not found.");
            }

            // Get date
            Console.Write("Enter Trip Date (yyyy-mm-dd): ");
            DateTime date = DateTime.Parse(Console.ReadLine());

            Trip trip = new Trip(tripID, customer, vehicle, date);
            _cabSystem.AddTrip(trip);
            Console.WriteLine("Trip added successfully!");
        }
    }
}

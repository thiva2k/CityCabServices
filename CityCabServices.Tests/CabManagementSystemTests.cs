using System;
using NUnit.Framework;
using CityCabServices;

namespace CityCabServices.Tests
{
    [TestFixture]
    public class CabManagementSystemTests
    {
        [Test]
        public void CabManagementSystem_Creation_InitializesEmptyLists()
        {
            // Arrange & Act
            CabManagementSystem system = new CabManagementSystem();

            // Assert
            Assert.IsNotNull(system.Drivers);
            Assert.IsNotNull(system.Vehicles);
            Assert.IsNotNull(system.Customers);
            Assert.IsNotNull(system.Trips);
            Assert.IsEmpty(system.Drivers);
            Assert.IsEmpty(system.Vehicles);
            Assert.IsEmpty(system.Customers);
            Assert.IsEmpty(system.Trips);
        }

        [Test]
        public void AddDriver_AddsDriverSuccessfully()
        {
            // Arrange
            CabManagementSystem system = new CabManagementSystem();
            Driver driver = new Driver("D01", "John", "DL123");

            // Act
            system.AddDriver(driver);

            // Assert
            Assert.AreEqual(1, system.Drivers.Count);
            Assert.AreEqual("D01", system.Drivers[0].DriverID);
        }

        [Test]
        public void AddDriver_DuplicateDriverID_ThrowsException()
        {
            // Arrange
            CabManagementSystem system = new CabManagementSystem();
            Driver driver1 = new Driver("D01", "John", "DL123");
            Driver driver2 = new Driver("D01", "Jane", "DL456");
            system.AddDriver(driver1);

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() =>
                system.AddDriver(driver2));
            
            Assert.That(exception.Message, Does.Contain("already exists"));
        }

        [Test]
        public void AddVehicle_AddsCar_Successfully()
        {
            // Arrange
            CabManagementSystem system = new CabManagementSystem();
            Car car = new Car(101, "Toyota Prius", 4, "Hybrid");

            // Act
            system.AddVehicle(car);

            // Assert
            Assert.AreEqual(1, system.Vehicles.Count);
            Assert.AreEqual(101, system.Vehicles[0].VehicleID);
        }

        [Test]
        public void AddVehicle_AddsBus_Successfully()
        {
            // Arrange
            CabManagementSystem system = new CabManagementSystem();
            Bus bus = new Bus(201, "Volvo 9700", 50, "B12");

            // Act
            system.AddVehicle(bus);

            // Assert
            Assert.AreEqual(1, system.Vehicles.Count);
            Assert.AreEqual(201, system.Vehicles[0].VehicleID);
        }

        [Test]
        public void AddVehicle_DuplicateVehicleID_ThrowsException()
        {
            // Arrange
            CabManagementSystem system = new CabManagementSystem();
            Car car1 = new Car(101, "Toyota Prius", 4, "Hybrid");
            Car car2 = new Car(101, "Honda Civic", 4, "Sedan");
            system.AddVehicle(car1);

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() =>
                system.AddVehicle(car2));
            
            Assert.That(exception.Message, Does.Contain("already exists"));
        }

        [Test]
        public void AssignDriverToVehicle_AssignsSuccessfully()
        {
            // Arrange
            CabManagementSystem system = new CabManagementSystem();
            Driver driver = new Driver("D01", "John", "DL123");
            Car car = new Car(101, "Toyota Prius", 4, "Hybrid");
            system.AddDriver(driver);
            system.AddVehicle(car);

            // Act
            system.AssignDriverToVehicle("D01", 101);

            // Assert
            Assert.IsNotNull(system.Vehicles[0].AssignedDriver);
            Assert.AreEqual("D01", system.Vehicles[0].AssignedDriver.DriverID);
        }

        [Test]
        public void AssignDriverToVehicle_InvalidDriverID_ThrowsException()
        {
            // Arrange
            CabManagementSystem system = new CabManagementSystem();
            Car car = new Car(101, "Toyota Prius", 4, "Hybrid");
            system.AddVehicle(car);

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() =>
                system.AssignDriverToVehicle("D99", 101));
            
            Assert.That(exception.Message, Does.Contain("not found"));
        }

        [Test]
        public void AssignDriverToVehicle_InvalidVehicleID_ThrowsException()
        {
            // Arrange
            CabManagementSystem system = new CabManagementSystem();
            Driver driver = new Driver("D01", "John", "DL123");
            system.AddDriver(driver);

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() =>
                system.AssignDriverToVehicle("D01", 999));
            
            Assert.That(exception.Message, Does.Contain("not found"));
        }

        [Test]
        public void AddCustomer_AddsCustomerSuccessfully()
        {
            // Arrange
            CabManagementSystem system = new CabManagementSystem();
            Customer customer = new Customer("C001", "Alice", "555-1234");

            // Act
            system.AddCustomer(customer);

            // Assert
            Assert.AreEqual(1, system.Customers.Count);
            Assert.AreEqual("C001", system.Customers[0].CustomerID);
        }

        [Test]
        public void AddTrip_WithValidData_AddsSuccessfully()
        {
            // Arrange
            CabManagementSystem system = new CabManagementSystem();
            Driver driver = new Driver("D01", "John", "DL123");
            Car car = new Car(101, "Toyota Prius", 4, "Hybrid");
            car.AssignDriver(driver);
            Customer customer = new Customer("C001", "Alice", "555-1234");
            DateTime date = new DateTime(2024, 3, 15);
            Trip trip = new Trip("T001", customer, car, date);

            system.AddDriver(driver);
            system.AddVehicle(car);
            system.AddCustomer(customer);

            // Act
            system.AddTrip(trip);

            // Assert
            Assert.AreEqual(1, system.Trips.Count);
            Assert.AreEqual("T001", system.Trips[0].TripID);
        }

        [Test]
        public void AddTrip_DuplicateTripID_ThrowsException()
        {
            // Arrange
            CabManagementSystem system = new CabManagementSystem();
            Driver driver = new Driver("D01", "John", "DL123");
            Car car = new Car(101, "Toyota Prius", 4, "Hybrid");
            car.AssignDriver(driver);
            Customer customer = new Customer("C001", "Alice", "555-1234");
            DateTime date = new DateTime(2024, 3, 15);
            Trip trip1 = new Trip("T001", customer, car, date);
            Trip trip2 = new Trip("T001", customer, car, date);

            system.AddTrip(trip1);

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() =>
                system.AddTrip(trip2));
            
            Assert.That(exception.Message, Does.Contain("already exists"));
        }

        [Test]
        public void GetDriverByID_ReturnsCorrectDriver()
        {
            // Arrange
            CabManagementSystem system = new CabManagementSystem();
            Driver driver1 = new Driver("D01", "John", "DL123");
            Driver driver2 = new Driver("D02", "Sarah", "DL456");
            system.AddDriver(driver1);
            system.AddDriver(driver2);

            // Act
            Driver result = system.GetDriverByID("D02");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Sarah", result.Name);
        }

        [Test]
        public void GetVehicleByID_ReturnsCorrectVehicle()
        {
            // Arrange
            CabManagementSystem system = new CabManagementSystem();
            Car car = new Car(101, "Toyota Prius", 4, "Hybrid");
            Bus bus = new Bus(201, "Volvo 9700", 50, "B12");
            system.AddVehicle(car);
            system.AddVehicle(bus);

            // Act
            Vehicle result = system.GetVehicleByID(201);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Volvo 9700", result.Model);
        }

        [Test]
        public void GetCustomerByID_ReturnsCorrectCustomer()
        {
            // Arrange
            CabManagementSystem system = new CabManagementSystem();
            Customer customer1 = new Customer("C001", "Alice", "555-1234");
            Customer customer2 = new Customer("C002", "Bob", "555-5678");
            system.AddCustomer(customer1);
            system.AddCustomer(customer2);

            // Act
            Customer result = system.GetCustomerByID("C002");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Bob", result.Name);
        }
    }
}

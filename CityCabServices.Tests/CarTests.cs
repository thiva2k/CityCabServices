using System;
using NUnit.Framework;
using CityCabServices;

namespace CityCabServices.Tests
{
    [TestFixture]
    public class CarTests
    {
        [Test]
        public void Car_Creation_SetsPropertiesCorrectly()
        {
            // Arrange & Act
            Car car = new Car(101, "Toyota Prius", 4, "Hybrid");

            // Assert
            Assert.AreEqual(101, car.VehicleID);
            Assert.AreEqual("Toyota Prius", car.Model);
            Assert.AreEqual(4, car.SeatingCapacity);
            Assert.AreEqual("Hybrid", car.CarType);
            Assert.IsNull(car.AssignedDriver);
        }

        [Test]
        public void Car_GetVehicleType_ReturnsCorrectType()
        {
            // Arrange
            Car car = new Car(101, "Toyota Prius", 4, "Hybrid");

            // Act
            string vehicleType = car.GetVehicleType();

            // Assert
            Assert.AreEqual("Car (Hybrid)", vehicleType);
        }

        [Test]
        public void Car_AssignDriver_AssignsDriverCorrectly()
        {
            // Arrange
            Car car = new Car(101, "Toyota Prius", 4, "Hybrid");
            Driver driver = new Driver("D01", "John", "DL123");

            // Act
            car.AssignDriver(driver);

            // Assert
            Assert.IsNotNull(car.AssignedDriver);
            Assert.AreEqual("D01", car.AssignedDriver.DriverID);
            Assert.AreEqual("John", car.AssignedDriver.Name);
        }

        [Test]
        public void Car_ToString_ReturnsFormattedString()
        {
            // Arrange
            Car car = new Car(101, "Toyota Prius", 4, "Hybrid");
            Driver driver = new Driver("D01", "John", "DL123");
            car.AssignDriver(driver);

            // Act
            string result = car.ToString();

            // Assert
            Assert.That(result, Does.Contain("Vehicle ID: 101"));
            Assert.That(result, Does.Contain("Toyota Prius"));
            Assert.That(result, Does.Contain("Capacity: 4"));
            Assert.That(result, Does.Contain("Car (Hybrid)"));
            Assert.That(result, Does.Contain("John"));
        }
    }
}

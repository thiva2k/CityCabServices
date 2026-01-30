using System;
using NUnit.Framework;
using CityCabServices;

namespace CityCabServices.Tests
{
    [TestFixture]
    public class BusTests
    {
        [Test]
        public void Bus_Creation_SetsPropertiesCorrectly()
        {
            // Arrange & Act
            Bus bus = new Bus(201, "Volvo 9700", 50, "B12");

            // Assert
            Assert.AreEqual(201, bus.VehicleID);
            Assert.AreEqual("Volvo 9700", bus.Model);
            Assert.AreEqual(50, bus.SeatingCapacity);
            Assert.AreEqual("B12", bus.RouteNumber);
            Assert.IsNull(bus.AssignedDriver);
        }

        [Test]
        public void Bus_GetVehicleType_ReturnsCorrectType()
        {
            // Arrange
            Bus bus = new Bus(201, "Volvo 9700", 50, "B12");

            // Act
            string vehicleType = bus.GetVehicleType();

            // Assert
            Assert.AreEqual("Bus (Route: B12)", vehicleType);
        }

        [Test]
        public void Bus_AssignDriver_AssignsDriverCorrectly()
        {
            // Arrange
            Bus bus = new Bus(201, "Volvo 9700", 50, "B12");
            Driver driver = new Driver("D02", "Sarah", "DL456");

            // Act
            bus.AssignDriver(driver);

            // Assert
            Assert.IsNotNull(bus.AssignedDriver);
            Assert.AreEqual("D02", bus.AssignedDriver.DriverID);
            Assert.AreEqual("Sarah", bus.AssignedDriver.Name);
        }

        [Test]
        public void Bus_ToString_ReturnsFormattedString()
        {
            // Arrange
            Bus bus = new Bus(201, "Volvo 9700", 50, "B12");
            Driver driver = new Driver("D02", "Sarah", "DL456");
            bus.AssignDriver(driver);

            // Act
            string result = bus.ToString();

            // Assert
            Assert.That(result, Does.Contain("Vehicle ID: 201"));
            Assert.That(result, Does.Contain("Volvo 9700"));
            Assert.That(result, Does.Contain("Capacity: 50"));
            Assert.That(result, Does.Contain("Bus (Route: B12)"));
            Assert.That(result, Does.Contain("Sarah"));
        }
    }
}

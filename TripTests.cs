using System;
using NUnit.Framework;
using CityCabServices;

namespace CityCabServices.Tests
{
    [TestFixture]
    public class TripTests
    {
        [Test]
        public void Trip_Creation_WithAssignedDriver_SetsPropertiesCorrectly()
        {
            // Arrange
            Driver driver = new Driver("D01", "John", "DL123");
            Car car = new Car(101, "Toyota Prius", 4, "Hybrid");
            car.AssignDriver(driver);
            Customer customer = new Customer("C001", "Alice", "555-1234");
            DateTime date = new DateTime(2024, 3, 15);

            // Act
            Trip trip = new Trip("T001", customer, car, date);

            // Assert
            Assert.AreEqual("T001", trip.TripID);
            Assert.AreEqual(customer, trip.Customer);
            Assert.AreEqual(car, trip.Vehicle);
            Assert.AreEqual(date, trip.Date);
        }

        [Test]
        public void Trip_Creation_WithoutAssignedDriver_ThrowsException()
        {
            // Arrange
            Car car = new Car(101, "Toyota Prius", 4, "Hybrid");
            Customer customer = new Customer("C001", "Alice", "555-1234");
            DateTime date = new DateTime(2024, 3, 15);

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() =>
                new Trip("T001", customer, car, date));
            
            Assert.That(exception.Message, Does.Contain("Vehicle must have an assigned driver"));
        }

        [Test]
        public void Trip_ToString_ReturnsFormattedString()
        {
            // Arrange
            Driver driver = new Driver("D01", "John", "DL123");
            Car car = new Car(101, "Toyota Prius", 4, "Hybrid");
            car.AssignDriver(driver);
            Customer customer = new Customer("C001", "Alice", "555-1234");
            DateTime date = new DateTime(2024, 3, 15);
            Trip trip = new Trip("T001", customer, car, date);

            // Act
            string result = trip.ToString();

            // Assert
            Assert.That(result, Does.Contain("Trip ID: T001"));
            Assert.That(result, Does.Contain("Alice"));
            Assert.That(result, Does.Contain("Toyota Prius"));
            Assert.That(result, Does.Contain("John"));
        }

        [Test]
        public void Trip_PropertyGettersAndSetters_WorkCorrectly()
        {
            // Arrange
            Driver driver = new Driver("D01", "John", "DL123");
            Car car = new Car(101, "Toyota Prius", 4, "Hybrid");
            car.AssignDriver(driver);
            Customer customer = new Customer("C001", "Alice", "555-1234");
            DateTime date = new DateTime(2024, 3, 15);
            Trip trip = new Trip("T001", customer, car, date);

            // Act
            DateTime newDate = new DateTime(2024, 3, 20);
            trip.Date = newDate;

            // Assert
            Assert.AreEqual(newDate, trip.Date);
        }
    }
}

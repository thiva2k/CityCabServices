using System;
using NUnit.Framework;
using CityCabServices;

namespace CityCabServices.Tests
{
    [TestFixture]
    public class DriverTests
    {
        [Test]
        public void Driver_Creation_SetsPropertiesCorrectly()
        {
            // Arrange & Act
            Driver driver = new Driver("D01", "John", "DL123");

            // Assert
            Assert.AreEqual("D01", driver.DriverID);
            Assert.AreEqual("John", driver.Name);
            Assert.AreEqual("DL123", driver.LicenseNumber);
        }

        [Test]
        public void Driver_ToString_ReturnsFormattedString()
        {
            // Arrange
            Driver driver = new Driver("D01", "John", "DL123");

            // Act
            string result = driver.ToString();

            // Assert
            Assert.That(result, Does.Contain("Driver ID: D01"));
            Assert.That(result, Does.Contain("Name: John"));
            Assert.That(result, Does.Contain("License: DL123"));
        }

        [Test]
        public void Driver_PropertyGettersAndSetters_WorkCorrectly()
        {
            // Arrange
            Driver driver = new Driver("D01", "John", "DL123");

            // Act
            driver.Name = "John Doe";
            driver.LicenseNumber = "DL999";

            // Assert
            Assert.AreEqual("John Doe", driver.Name);
            Assert.AreEqual("DL999", driver.LicenseNumber);
        }
    }
}

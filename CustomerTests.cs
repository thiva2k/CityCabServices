using System;
using NUnit.Framework;
using CityCabServices;

namespace CityCabServices.Tests
{
    [TestFixture]
    public class CustomerTests
    {
        [Test]
        public void Customer_Creation_SetsPropertiesCorrectly()
        {
            // Arrange & Act
            Customer customer = new Customer("C001", "Alice", "555-1234");

            // Assert
            Assert.AreEqual("C001", customer.CustomerID);
            Assert.AreEqual("Alice", customer.Name);
            Assert.AreEqual("555-1234", customer.PhoneNumber);
        }

        [Test]
        public void Customer_ToString_ReturnsFormattedString()
        {
            // Arrange
            Customer customer = new Customer("C001", "Alice", "555-1234");

            // Act
            string result = customer.ToString();

            // Assert
            Assert.That(result, Does.Contain("Customer ID: C001"));
            Assert.That(result, Does.Contain("Name: Alice"));
            Assert.That(result, Does.Contain("Phone: 555-1234"));
        }

        [Test]
        public void Customer_PropertyGettersAndSetters_WorkCorrectly()
        {
            // Arrange
            Customer customer = new Customer("C001", "Alice", "555-1234");

            // Act
            customer.Name = "Alice Smith";
            customer.PhoneNumber = "555-9999";

            // Assert
            Assert.AreEqual("Alice Smith", customer.Name);
            Assert.AreEqual("555-9999", customer.PhoneNumber);
        }
    }
}

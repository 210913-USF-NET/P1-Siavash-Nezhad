using System;
using Xunit;
using Models;

namespace Tests
{
    public class ModelTests
    {
        [Fact]
        public void CustomerShouldSetValidName()
        {
            //Arrange
            Customer test = new Customer();
            string testName = "test Customer";

            //Act
            test.Name = testName;

            //Assert
            Assert.Equal(testName, test.Name);
        }

        [Fact]
        public void CustomerShouldCreate()
        {
            Customer test = new Customer();

            Assert.NotNull(test);
        }

        [Fact]
        public void testInventoryQuantity()
        {
            // Arrange
            Inventory test = new Inventory();

            // Act
            test.Quantity = 20;

            // Assert
            Assert.Equal(20, test.Quantity);
        }
        [Fact]
        public void testLineItemQuantity()
        {
            // Arrange
            LineItem test = new LineItem();

            // Act
            test.Quantity = 20;

            // Assert
            Assert.Equal(20, test.Quantity);
        }
        [Fact]
        public void testOrdersCustomerId()
        {
            // Arrange
            Order test = new Order();

            // Act
            test.CustomerID = 3;

            // Assert
            Assert.Equal(3, test.CustomerID);
        }
        [Fact]
        public void testCustomerName()
        {
            // Arrange
            Customer test = new Customer();
            string customerName = "Rachel";

            // Act
            test.Name = customerName;

            // Assert
            Assert.Equal(customerName, test.Name);
        }
    }
}

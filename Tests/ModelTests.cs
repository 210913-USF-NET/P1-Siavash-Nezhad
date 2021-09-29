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
    }
}

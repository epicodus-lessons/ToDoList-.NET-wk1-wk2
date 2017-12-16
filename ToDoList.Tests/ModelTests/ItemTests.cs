using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoList.Models;

namespace ToDoList.Tests
{
    [TestClass]
    public class ItemTest
    {
        [TestMethod]
        public void GetDescription_ReturnsItemDescription_String()
        {
            //Arrange
            var item = new Item("Wash the dog");

            //Act
            var result = item.Description;

            //Assert
            Assert.AreEqual("Wash the dog", result);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using ToDoList.Controllers;
using Moq;
using System.Linq;

namespace ToDoList.Tests.ControllerTests
{

    [TestClass]
    public class ItemsControllerTests
    {
        Mock<IItemRepository> mock = new Mock<IItemRepository>();

        private void DbSetup()
        {
            mock.Setup(m => m.Items).Returns(new Item[]
            {
                new Item {ItemId = 1, Description = "Wash the dog" },
                new Item {ItemId = 2, Description = "Do the dishes" },
                new Item {ItemId = 3, Description = "Sweep the floor" }
            }.AsQueryable());

        }

        [TestMethod]
        public void Mock_GetViewResultIndex_ActionResult() // Confirms route returns view
        {
            //Arrange
            DbSetup();
            ItemsController controller = new ItemsController(mock.Object);

            //Act
            var result = controller.Index();

            //Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult));
        }

        [TestMethod]
        public void Mock_IndexContainsModelData_List() // Confirms model as list of items
        {
            // Arrange
            DbSetup();
            ViewResult indexView = new ItemsController(mock.Object).Index() as ViewResult;

            // Act
            var result = indexView.ViewData.Model;

            // Assert
            Assert.IsInstanceOfType(result, typeof(List<Item>));
        }

        [TestMethod]
        public void Mock_IndexModelContainsItems_Collection() // Confirms presence of known entry
        {
            // Arrange
            DbSetup();
            ItemsController controller = new ItemsController(mock.Object);
            Item testItem = new Item();
            testItem.Description = "Wash the dog";
            testItem.ItemId = 1;

            // Act
            ViewResult indexView = controller.Index() as ViewResult;
            List<Item> collection = indexView.ViewData.Model as List<Item>;

            // Assert
            CollectionAssert.Contains(collection, testItem);
        }
    }
}

using Adform_Todo.Common.Models;
using Adform_ToDo.API.Controllers.v1;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Adform_ToDo.Tests.ControllersTests
{
    /// <summary>
    /// Items controller tests.
    /// </summary>
    public class ToDoItemControllerTests : BaseController
    {
        private ToDoItemsController controller;

        /// <summary>
        /// Setup.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            controller = new ToDoItemsController(ToDoItemManager.Object, Mapper)
            {
                ControllerContext = Context
            };
        }

        /// <summary>
        /// Add item test.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task AddItemTest()
        {
            IActionResult result = await controller.CreateToDoItem(new CreateToDoItemModel { Notes = "test", ToDoListId = 1 });
            ObjectResult response = result as ObjectResult;
            Assert.AreEqual(StatusCodes.Status201Created, (int)response.StatusCode);
        }

        /// <summary>
        /// Update item test.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task UpdateItemTest()
        {
            IActionResult result = await controller.PutToDoItem(new UpdateToDoItemModel { ToDoItemId = 1, Notes = "test" });
            ObjectResult response = result as ObjectResult;
            Assert.AreEqual(StatusCodes.Status200OK, (int)response.StatusCode);
        }

        /// <summary>
        /// Delete item test.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task DeleteLabelTest()
        {
            IActionResult result = await controller.DeleteToDoItem(1);
            ObjectResult response = result as ObjectResult;
            Assert.AreEqual(StatusCodes.Status200OK, (int)response.StatusCode);
        }

        /// <summary>
        /// Get item test.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task GetItemTest()
        {
            IActionResult result = await controller.GetToDoItemById(1);
            ObjectResult response = result as ObjectResult;
            Assert.AreEqual(StatusCodes.Status200OK, (int)response.StatusCode);
        }
    }
}

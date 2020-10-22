using Adform_Todo.Common.Models;
using Adform_ToDo.API.Controllers.v1;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Adform_ToDo.Tests.ControllersTests
{
    /// <summary>
    /// Lists controller tests.
    /// </summary>
    public class ToDoListControllerTests : BaseController
    {
        private ToDoListController controller;

        /// <summary>
        /// Setup.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            controller = new ToDoListController(ToDoListManager.Object, Mapper)
            {
                ControllerContext = Context
            };
        }

        /// <summary>
        /// Add list test.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task AddListTest()
        {
            IActionResult result = await controller.CreateToDoList(new CreateToDoListModel { Description = "test" }, Version);
            CreatedAtActionResult response = result as CreatedAtActionResult;
            Assert.AreEqual(StatusCodes.Status201Created, (int)response.StatusCode);
        }

        /// <summary>
        /// Update list test.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task UpdateListTest()
        {
            IActionResult result = await controller.PutToDoList(new UpdateToDoListModel { ToDoListId = 1, Description = "test" });
            OkObjectResult response = result as OkObjectResult;
            Assert.AreEqual(StatusCodes.Status200OK, (int)response.StatusCode);
        }

        /// <summary>
        /// Delete list test.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task DeleteListTest()
        {
            IActionResult result = await controller.DeleteToDoList(1);
            OkObjectResult response = result as OkObjectResult;
            Assert.AreEqual(StatusCodes.Status200OK, (int)response.StatusCode);
        }

        /// <summary>
        /// Get list test.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task GetListTest()
        {
            IActionResult result = await controller.GetToDoListById(1);
            OkObjectResult response = result as OkObjectResult;
            Assert.AreEqual(StatusCodes.Status200OK, (int)response.StatusCode);
        }
    }
}

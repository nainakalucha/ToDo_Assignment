using Adform_Todo.Common.Models;
using Adform_ToDo.API.Controllers.v1;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Adform_ToDo.Tests.ControllersTests
{
    /// <summary>
    /// Label controller tests.
    /// </summary>
    public class LabelControllerTests : BaseController
    {
        private LabelsController controller;

        /// <summary>
        /// Setup.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            controller = new LabelsController(LabelManager.Object, Mapper)
            {
                ControllerContext = Context
            };
        }

        /// <summary>
        /// Add label test.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task AddLabelTest()
        {
            IActionResult result = await controller.CreateLabel(new CreateLabelModel { Description = "test" });
            ObjectResult response = result as ObjectResult;
            Assert.AreEqual(StatusCodes.Status201Created, (int)response.StatusCode);
        }

        /// <summary>
        /// Delete label test.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task DeleteLabelTest()
        {
            IActionResult result = await controller.DeleteLabel(1);
            ObjectResult response = result as ObjectResult;
            Assert.AreEqual(StatusCodes.Status200OK, (int)response.StatusCode);
        }

        /// <summary>
        /// Get label test.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task GetLabelByIdTest()
        {
            IActionResult result = await controller.GetLabelById(1);
            ObjectResult response = result as ObjectResult;
            Assert.AreEqual(StatusCodes.Status200OK, (int)response.StatusCode);
        }
    }
}

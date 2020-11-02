using Adform_Todo.Common.Models;
using Adform_ToDo.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Adform_ToDo.Tests.ControllersTests
{
    /// <summary>
    /// User controller tests.
    /// </summary>
    public class UserControllerTests : BaseController
    {
        private UserController controller;
        private IOptions<AppSettings> options;

        /// <summary>
        /// Setup.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            options = Options.Create(new AppSettings { Secret = "this is my custom Secret key for authnetication" });
            controller = new UserController(UserLogger.Object, UserManager.Object, options, Mapper)
            {
                ControllerContext = Context
            };
        }

        /// <summary>
        /// Authentication test.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task AuthenticateTest()
        {
            IActionResult result = await controller.Login(new LoginModel { UserName = "Sunaina  ", Password = "12345" });
            ObjectResult response = result as ObjectResult;
            Assert.AreEqual(StatusCodes.Status200OK, (int)response.StatusCode);
        }


        /// <summary>
        /// Authentication test.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task RegistrationTest()
        {
            IActionResult result = await controller.Register(new CreateUserModel { FirstName = "Sunaina", LastName = "Kalucha", UserName = "Sunaina", Password = "12345" });
            ObjectResult response = result as ObjectResult;
            Assert.AreEqual(StatusCodes.Status200OK, (int)response.StatusCode);
        }

    }
}

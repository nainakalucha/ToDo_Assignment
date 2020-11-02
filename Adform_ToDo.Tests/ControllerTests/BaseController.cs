using Adform_Todo.Common.Contracts;
using Adform_Todo.Common.Dtos;
using Adform_ToDo.API.Controllers.v1;
using Adform_ToDo.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Threading.Tasks;

namespace Adform_ToDo.Tests.ControllersTests
{
    /// <summary>
    /// Base class for controller tests.
    /// </summary>
    public class BaseController : MapperInitiator
    {
        public ControllerContext Context { get; }
        public ApiVersion Version { get; }

        public Mock<ILogger<LabelsController>> LabelLogger { get; }
        public Mock<ILogger<ToDoItemsController>> ToDoItemLogger { get; }
        public Mock<ILogger<ToDoListsController>> ToDoListLogger { get; }
        public Mock<ILogger<UserController>> UserLogger { get; }

        public Mock<ILabelManager> LabelManager { get; }
        public Mock<IToDoItemManager> ToDoItemManager { get; }
        public Mock<IToDoListManager> ToDoListManager { get; }
        public Mock<IUserManager> UserManager { get; }

        private readonly ToDoItemDto _toDoItemDto = new ToDoItemDto { ToDoItemId = 1 };
        private readonly LabelDto _labelDto = new LabelDto { LabelId = 1 };
        private readonly ToDoListDto _toDoListDto = new ToDoListDto { ToDoListId = 1 };
        private readonly UserDto _userDto = new UserDto { UserId = 1, UserName = "Sunaina", UserRole = "User" };

        protected BaseController()
        {
            Context = new ControllerContext
            {
                HttpContext = new DefaultHttpContext()
            };
            Version = new ApiVersion(1, 0);
            LabelManager = new Mock<ILabelManager>();
            ToDoItemManager = new Mock<IToDoItemManager>();
            ToDoListManager = new Mock<IToDoListManager>();
            UserManager = new Mock<IUserManager>();
            LabelLogger = new Mock<ILogger<LabelsController>>();
            ToDoItemLogger = new Mock<ILogger<ToDoItemsController>>();
            ToDoListLogger = new Mock<ILogger<ToDoListsController>>();
            UserLogger = new Mock<ILogger<UserController>>();

            Context.HttpContext.Items["UserId"] = 1;
            //Mock methods
            LabelManager.Setup(p => p.AddLabel(It.IsAny<CreateLabelDto>())).Returns(Task.FromResult(_labelDto));
            LabelManager.Setup(p => p.DeleteLabel(It.IsAny<long>(), It.IsAny<long>())).Returns(Task.FromResult(1));
            LabelManager.Setup(p => p.GetLabelById(1, 1)).Returns(Task.FromResult(_labelDto));
            ToDoItemManager.Setup(p => p.AddToDoItem(It.IsAny<CreateToDoItemDto>())).Returns(Task.FromResult(_toDoItemDto));
            ToDoItemManager.Setup(p => p.UpdateToDoItem(It.IsAny<UpdateToDoItemDto>())).Returns(Task.FromResult(_toDoItemDto));
            ToDoItemManager.Setup(p => p.DeleteToDoItem(It.IsAny<long>(), It.IsAny<long>())).Returns(Task.FromResult(1));
            ToDoItemManager.Setup(p => p.GetToDoItemById(1, 1)).Returns(Task.FromResult(_toDoItemDto));
            ToDoListManager.Setup(p => p.GetToDoListById(1, 1)).Returns(Task.FromResult(_toDoListDto));
            ToDoListManager.Setup(p => p.CreateToDoList(It.IsAny<CreateToDoListDto>())).Returns(Task.FromResult(_toDoListDto));
            ToDoListManager.Setup(p => p.UpdateToDoList(It.IsAny<UpdateToDoListDto>())).Returns(Task.FromResult(_toDoListDto));
            ToDoListManager.Setup(p => p.DeleteToDoList(It.IsAny<long>(), It.IsAny<long>())).Returns(Task.FromResult(1));
            UserManager.Setup(p => p.AuthenticateUser(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(_userDto));
            UserManager.Setup(p => p.RegisterUser(It.IsAny<CreateUserDto>())).Returns(Task.FromResult(true));
        }
    }
}

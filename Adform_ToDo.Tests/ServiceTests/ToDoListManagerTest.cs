using Adform_Todo.Common.Contracts;
using Adform_Todo.Common.Dtos;
using Adform_Todo.Common.Models;
using Adform_ToDo.BL;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Adform_ToDo.Tests.ServiceTests
{
    class ToDoListManagerTest
    {
        private Mock<IToDoListDal> _toDoListDbOps;
        private IToDoListManager _toDoListContract;
        private readonly ToDoListDto _toDoListDto = new ToDoListDto { ToDoListId = 1, Description = "test" };
        readonly List<ToDoListDto> _toDoListDtos = new List<ToDoListDto>();
        readonly PaginationParameters paginationParameters = new PaginationParameters()
        {
            PageNumber = 1,
            PageSize = 10,
            SearchString = "Something"
        };
        /// <summary>
        /// Setup.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _toDoListDbOps = new Mock<IToDoListDal>();
            _toDoListContract = new ToDoListManager(_toDoListDbOps.Object);
            _toDoListDbOps.Setup(p => p.CreateToDoList(It.IsAny<CreateToDoListDto>())).Returns(Task.FromResult(_toDoListDto));
            _toDoListDbOps.Setup(p => p.UpdateToDoList(It.IsAny<UpdateToDoListDto>())).Returns(Task.FromResult(_toDoListDto));
            _toDoListDbOps.Setup(p => p.DeleteToDoList(It.IsAny<long>(), It.IsAny<long>())).Returns(Task.FromResult(1));
            _toDoListDbOps.Setup(p => p.GetToDoListById(It.IsAny<long>(), It.IsAny<long>())).Returns(Task.FromResult(_toDoListDto));
            _toDoListDbOps.Setup(p => p.GetAllToDoLists(It.IsAny<long>())).Returns(Task.FromResult(_toDoListDtos));
        }

        /// <summary>
        /// Add ToDoList test.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task AddToDoListTest()
        {
            ToDoListDto result = await _toDoListContract.CreateToDoList(new CreateToDoListDto());
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.ToDoListId);
        }
        [Test]
        public async Task UpdateToDoListTest()
        {
            ToDoListDto result = await _toDoListContract.UpdateToDoList(new UpdateToDoListDto());
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.ToDoListId);
        }
        [Test]
        public async Task DeleteToDoListTest()
        {
            int result = await _toDoListContract.DeleteToDoList(1, 1);
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result);
        }
        [Test]
        public async Task GetToDoListById()
        {
            ToDoListDto result = await _toDoListContract.GetToDoListById(1, 1);
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.ToDoListId);
        }
        [Test]
        public async Task GetToDoLists()
        {
            PagedList<ToDoListDto> result = await _toDoListContract.GetToDoLists(paginationParameters, 1);
            Assert.IsNotNull(result);
        }
    }
}

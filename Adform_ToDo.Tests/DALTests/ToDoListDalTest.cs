using Adform_Todo.Common.Dtos;
using Adform_Todo.Common.Models;
using Adform_ToDo.DAL;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Adform_ToDo.Tests.DALTests
{
    public class ToDoListDalTest : ToDoDbContextInitiator
    {
        private readonly ToDoListDal _toDoListDal;
        public ToDoListDalTest()
        {
            _toDoListDal = new ToDoListDal(DBContext, Mapper);
            DBContext.ToDoLists.Add(new TodoListEntity
            {
                Description = "something",
                CreatedBy = 1,
                CreationDate = DateTime.Now
            });
            DBContext.SaveChanges();
        }

        /// <summary>
        /// Get ToDoList test.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task GetToDoLists()
        {
            List<ToDoListDto> ToDoListList = await _toDoListDal.GetAllToDoLists(1);
            int count = ToDoListList.Count;
            Assert.IsNotNull(ToDoListList);
            Assert.IsTrue(count >= 1);
        }

        /// <summary>
        /// Test to update existing ToDoItem record.
        /// </summary>
        [Test]
        public async Task UpdateToDoList()
        {
            DBContext.ToDoLists.Add(new TodoListEntity
            {
                Description = "ListToUpdate",
                CreatedBy = 1,
                CreationDate = DateTime.Now
            });
            DBContext.SaveChanges();
            ToDoListDto updatedToDoList = await _toDoListDal.UpdateToDoList(new UpdateToDoListDto { ToDoListId = 2, Description = "UpdatedList", CreatedBy = 1 });
            Assert.IsNotNull(updatedToDoList);
            Assert.AreEqual("UpdatedList", updatedToDoList.Description);
        }

        /// <summary>
        /// Add ToDoList test.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task AddToDoList()
        {
            ToDoListDto addedtoDoList = await _toDoListDal.CreateToDoList(new CreateToDoListDto { Description = "buy phone", CreatedBy = 1 });
            Assert.IsNotNull(addedtoDoList);
            Assert.AreEqual("buy phone", addedtoDoList.Description);
        }

        /// <summary>
        /// test to delete existing ToDoItem record.
        /// </summary>
        [Test]
        public async Task DeleteToDoList()
        {
            int deleteResult = await _toDoListDal.DeleteToDoList(1, 1);
            Assert.IsNotNull(deleteResult);
            Assert.IsTrue(deleteResult > 0);
        }
    }
}
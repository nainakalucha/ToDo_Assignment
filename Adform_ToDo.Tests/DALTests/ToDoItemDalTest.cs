using Adform_Todo.Common.Dtos;
using Adform_Todo.Common.Models;
using Adform_ToDo.DAL;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Adform_ToDo.Tests.DALTests
{
    public class ToDoItemDalTest : ToDoDbContextInitiator
    {
        private readonly ToDoItemDal _toDoItemDal;
        public ToDoItemDalTest()
        {
            _toDoItemDal = new ToDoItemDal(DBContext, Mapper);
            DBContext.ToDoItems.Add(new TodoItemEntity
            {
                Notes = "something",
                CreatedBy = 1,
                ToDoListId = 1,
                CreationDate = DateTime.Now
            });
            DBContext.SaveChanges();
        }

        /// <summary>
        /// Get ToDoItems test.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task GetToDoItems()
        {
            List<ToDoItemDto> toDoItemList = await _toDoItemDal.GetAllToDoItems(1);
            int count = toDoItemList.Count;
            Assert.IsNotNull(toDoItemList);
            Assert.IsTrue(count >= 1);
        }

        /// <summary>
        /// Test to update existing ToDoItem record.
        /// </summary>
        [Test]
        public async Task UpdateToDoItem()
        {
            DBContext.ToDoItems.Add(new TodoItemEntity
            {
                Notes = "ItemToUpdate",
                CreatedBy = 1,
                ToDoListId = 1,
                CreationDate = DateTime.Now
            });
            DBContext.SaveChanges();
            ToDoItemDto updatedToDoItem = await _toDoItemDal.UpdateToDoItem(new UpdateToDoItemDto { ToDoItemId = 2, Notes = "UpdatedItem", CreatedBy = 1 });
            Assert.IsNotNull(updatedToDoItem);
            Assert.AreEqual("UpdatedItem", updatedToDoItem.Notes);
        }

        /// <summary>
        /// Add ToDoItem test.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task AddToDoItem()
        {
            ToDoItemDto addedToDoItem = await _toDoItemDal.AddToDoItem(new CreateToDoItemDto { Notes = "buy phone", CreatedBy = 1, ToDoListId = 2 });
            Assert.IsNotNull(addedToDoItem);
            Assert.AreEqual("buy phone", addedToDoItem.Notes);
        }

        /// <summary>
        /// test to delete existing ToDoItem record.
        /// </summary>
        [Test]
        public async Task DeleteToDoItem()
        {
            int deleteResult = await _toDoItemDal.DeleteToDoItem(1, 1);
            Assert.IsNotNull(deleteResult);
            Assert.IsTrue(deleteResult > 0);
        }
    }
}
using Adform_Todo.Common.Contracts;
using Adform_Todo.Common.Dtos;
using Adform_Todo.Common.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adform_ToDo.BL
{
    /// <summary>
    /// Implemenation of ITodoItemService contract.
    /// </summary>
    public class ToDoItemManager : IToDoItemManager
    {
        private readonly IToDoItemDal _toDoItemDal;
        public ToDoItemManager(IToDoItemDal toDoItemDal)
        {
            _toDoItemDal = toDoItemDal;
        }
        /// <summary>
        /// Get ToDoItem record By Id 
        /// </summary>
        /// <param name="ToDoItemId"></param>
        /// <param name="userId"></param>
        /// <returns>ToDoItem record based on ToDoItemId</returns>
        public async Task<ToDoItemDto> GetToDoItemById(long ToDoItemId, long userId)
        {
            return await _toDoItemDal.GetToDoItemById(ToDoItemId, userId);
        }

        /// <summary>
        /// Get all ToDoItems created by user.
        /// </summary>
        /// <param name="listId"></param>
        /// <param name="userId"></param>
        /// <returns>Returns all ToDoItems created by user.</returns>
        public async Task<List<ToDoItemDto>> GetToDoItemsForToDoListId(long listId, long userId)
        {
            return await _toDoItemDal.GetToDoItemsForToDoListId(listId, userId);
        }

        /// <summary>
        /// Get all ToDoItems created by user.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Returns all ToDoItems created by user.</returns>
        public async Task<List<ToDoItemDto>> GetAllToDoItems(long userId)
        {
            return await _toDoItemDal.GetAllToDoItems(userId);
        }

        /// <summary>
        /// returns all the to do Items in paged format based on search query for the logged in user.
        /// </summary>
        /// <param name="paginationParams"></param>
        /// <param name="userId"></param>
        /// <returns> Pagedlst of ToDoItem records. </returns>
        public async Task<PagedList<ToDoItemDto>> GetToDoItems(PaginationParameters paginationParams, long userId)
        {
            List<ToDoItemDto> todoItems = await _toDoItemDal.GetAllToDoItems(userId);
            if (!string.IsNullOrWhiteSpace(paginationParams.SearchString))
            {
                todoItems = todoItems.Where(p => p.Notes.ToLower().Contains(paginationParams.SearchString.ToLower())).ToList();
            }
            return PagedList<ToDoItemDto>.ToPagedList(todoItems, paginationParams.PageNumber, paginationParams.PageSize);
        }

        /// <summary>
        /// Create ToDoItem record.
        /// </summary>
        /// <param name="createToDoItemDto"></param>
        /// <returns> Created ToDoItem record. </returns>
        public async Task<ToDoItemDto> AddToDoItem(CreateToDoItemDto createToDoItemDto)
        {
            return await _toDoItemDal.AddToDoItem(createToDoItemDto);
        }

        /// <summary>
        /// Updates specified ToDoItem record.
        /// </summary>
        /// <param name="updateToDoItemDto"></param>
        /// <returns> Updated ToDoItem record. </returns>
        public async Task<ToDoItemDto> UpdateToDoItem(UpdateToDoItemDto updateToDoItemDto)
        {
            return await _toDoItemDal.UpdateToDoItem(updateToDoItemDto);
        }

        /// <summary>
        /// Delete ToDoItem record.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userId"></param>
        /// <returns> 1 on success, 0 on failure. </returns>
        public async Task<int> DeleteToDoItem(long id, long userId)
        {
            return await _toDoItemDal.DeleteToDoItem(id, userId);
        }

        /// <summary>
        /// Assign labelIds to specified ToDoItemId record.
        /// </summary>
        /// <param name="assignLabelToItemDto"></param>
        /// <returns> Boolean result of Assignment, i.e. true/false. </returns>
        public async Task<bool> AssignLabelToItem(AssignLabelToItemDto assignLabelToItemDto)
        {
            return await _toDoItemDal.AssignLabelToItem(assignLabelToItemDto);
        }
    }
}

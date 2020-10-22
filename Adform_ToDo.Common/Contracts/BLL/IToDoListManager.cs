using Adform_Todo.Common.Dtos;
using Adform_Todo.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Adform_Todo.Common.Contracts
{
    /// <summary>
    /// Contract for todolist service.
    /// </summary>
    public interface IToDoListManager
    {
        /// <summary>
        /// Gets all the ToDoList items in paged format based on search query.
        /// </summary>
        /// <param name="paginationParams">Page Size, search query and page number.</param>
        /// <param name="userId"> Id of the logged in user.</param>
        Task<PagedList<ToDoListDto>> GetToDoLists(PaginationParameters paginationParams, long userId);

        /// <summary>
        /// Gets all the ToDoList items in paged format based on search query.
        /// </summary>
        /// <param name="userId"> Id of the logged in user.</param>
        Task<List<ToDoListDto>> GetAllToDoLists(long userId);

        /// <summary>
        /// Gets ToDoList item based on Id. 
        /// </summary>
        /// <param name="toDoListId"></param>
        /// <param name="userId"></param>
        Task<ToDoListDto> GetToDoListById(long toDoListId, long userId);

        /// <summary>
        /// Add ToDoList item in database
        /// </summary>
        /// <param name="createToDoListDto"></param>
        Task<ToDoListDto> CreateToDoList(CreateToDoListDto createToDoListDto);

        /// <summary>
        /// Updates provided ToDoList.
        /// </summary>
        /// <param name="updateToDoListDto"></param>
        Task<ToDoListDto> UpdateToDoList(UpdateToDoListDto updateToDoListDto);

        /// <summary>
        /// Deletes ToDoList record from database.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<int> DeleteToDoList(long id, long userId);

        /// <summary>
        /// Assign labels to list.
        /// </summary>
        /// <param name="assignLabelToListDto"></param>
        Task<bool> AssignLabelToList(AssignLabelToListDto assignLabelToListDto);
    }
}

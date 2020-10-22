using Adform_Todo.Common.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Adform_Todo.Common.Contracts
{
    /// <summary>
    /// Contract for todolist data layer.
    /// </summary>
    public interface IToDoListDal
    {
        /// <summary>
        /// Gets all the ToDoList records.
        /// </summary>
        /// <param name="userId"> Id of the logged in user.</param>
        Task<List<ToDoListDto>> GetAllToDoLists(long userId);

        /// <summary>
        /// Gets ToDoList item based on Id. 
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="userId"></param>
        Task<ToDoListDto> GetToDoListById(long Id, long userId);

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
        /// Assign labels to ToDoList.
        /// </summary>
        /// <param name="assignLabelToListDto"> LabelIds corresponding to ToDoListId</param>
        Task<bool> AssignLabelToList(AssignLabelToListDto assignLabelToListDto);
    }
}
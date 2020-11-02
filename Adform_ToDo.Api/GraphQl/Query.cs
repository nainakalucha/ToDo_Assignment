using Adform_Todo.Common.Contracts;
using Adform_Todo.Common.Dtos;
using HotChocolate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Adform_ToDo.API.GraphQl
{
    /// <summary>
    /// Query class for GraphQl.
    /// </summary>
    [Authorize(Roles = "User,Admin")]
    public class Query
    {
        private readonly ILabelDal _labelDal;
        private readonly IToDoListDal _toDoListDal;
        private readonly IToDoItemDal _toDoItemDal;
        private readonly IUserDal _userDal;
        private readonly long _userId;

        /// <summary>
        /// Query Constructor
        /// </summary>
        /// <param name="labelDal"></param>
        /// <param name="toDoItemDal"></param>
        /// <param name="toDoListDal"></param>
        /// <param name="userDal"></param>
        /// <param name="httpContextAccessor"></param>
        public Query([Service]ILabelDal labelDal, [Service]IToDoItemDal toDoItemDal, [Service]IToDoListDal toDoListDal,
            [Service]IUserDal userDal, IHttpContextAccessor httpContextAccessor)
        {
            _labelDal = labelDal;
            _toDoItemDal = toDoItemDal;
            _toDoListDal = toDoListDal;
            _userDal = userDal;
            if (httpContextAccessor.HttpContext.Items["UserId"] != null)
            {
                _userId = long.Parse(httpContextAccessor.HttpContext.Items["UserId"].ToString());
            }
        }

        #region Labels
        /// <summary>
        /// Get labels.
        /// </summary>
        /// <returns>Returns labels.</returns>
        public async Task<List<LabelDto>> GetAllLabels()
        {
            return await _labelDal.GetAllLabels(_userId);
        }

        /// <summary>
        /// Get label by id.
        /// </summary>
        /// <param name="labelId">label id.</param>
        public async Task<LabelDto> GetLabelById(long labelId)
        {
            return await _labelDal.GetLabelById(labelId, _userId);
        }

        #endregion

        #region Todolists

        /// <summary>
        /// Get ToDoItems.
        /// </summary>
        /// <returns>Returns ToDoItems.</returns>
        public async Task<List<ToDoItemDto>> GetAllToDoItems()
        {
            return await _toDoItemDal.GetAllToDoItems(_userId);
        }

        /// <summary>
        /// Get ToDoItem by id.
        /// </summary>
        /// <param name="toDoItemId">ToDoItem id.</param>        
        public async Task<ToDoItemDto> GetToDoItemById(long toDoItemId)
        {
            return await _toDoItemDal.GetToDoItemById(toDoItemId, _userId);
        }

        #endregion

        #region ToDoLists

        /// <summary>
        /// Get ToDoLists.
        /// </summary>
        /// <returns>Returns ToDoLists.</returns>
        public async Task<List<ToDoListDto>> GetAllToDoLists()
        {
            return await _toDoListDal.GetAllToDoLists(_userId);
        }

        /// <summary>
        /// Get ToDoList by id.
        /// </summary>
        /// <param name="toDoListId">ToDoList id.</param>
        public async Task<ToDoListDto> GetToDoListById(long toDoListId)
        {
            return await _toDoListDal.GetToDoListById(toDoListId, _userId);
        }

        #endregion

        #region Users

        /// <summary>
        /// Get user by user id.
        /// </summary>
        /// <returns>Returns user details.</returns>
        public async Task<UserDto> GetById()
        {
            return await _userDal.GetById(_userId);
        }

        #endregion
    }
}

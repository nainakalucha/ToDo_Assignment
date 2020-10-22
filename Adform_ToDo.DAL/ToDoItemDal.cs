using Adform_Todo.Common.Contracts;
using Adform_Todo.Common.Dtos;
using Adform_Todo.Common.Models;
using AutoMapper;
using Adform_ToDo.DAL.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adform_ToDo.DAL
{
    public class ToDoItemDal : IToDoItemDal
    {
        private readonly ToDoDbContext _toDoDbContext;
        private readonly IMapper _mapper;
        public ToDoItemDal(ToDoDbContext toDoDbContext, IMapper mapper)
        {
            _mapper = mapper;
            _toDoDbContext = toDoDbContext;
        }

        /// <summary>
        /// Gets all the todoitem records..
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>All ToDoItem records for the logged in user.</returns>
        public async Task<List<ToDoItemDto>> GetAllToDoItems(long userId)
        {
            List<TodoItemEntity> toDoItems = await _toDoDbContext.ToDoItems
                .Include(p => p.Labels)
                .Where(p => p.CreatedBy == userId).ToListAsync();
            return _mapper.Map<List<ToDoItemDto>>(toDoItems);
        }

        /// <summary>
        /// Gets todoitem records for specific todolist record.
        /// </summary>
        /// <param name="listId"></param>
        /// <param name="userId"></param>
        /// <returns> List of ToDoItem records corresponding to specific ToDoListId. </returns>
        public async Task<List<ToDoItemDto>> GetToDoItemsForToDoListId(long listId, long userId)
        {
            List<TodoItemEntity> toDoItems = await _toDoDbContext.ToDoItems.Include(p => p.Labels)
                .Where(p => p.CreatedBy == userId && p.ToDoListId == listId).ToListAsync();
            return _mapper.Map<List<ToDoItemDto>>(toDoItems);
        }

        /// <summary>
        /// Gets specific todoitem record.
        /// </summary>
        /// <param name="toDoItemId"></param>
        /// <param name="userId"></param>
        /// <returns>ToDoItem record for the given Id.</returns>
        public async Task<ToDoItemDto> GetToDoItemById(long toDoItemId, long userId)
        {
            TodoItemEntity toDoItemDbDto = await _toDoDbContext.ToDoItems.Include(p => p.Labels).FirstOrDefaultAsync(p => p.ToDoItemId == toDoItemId && p.CreatedBy == userId);
            return _mapper.Map<ToDoItemDto>(toDoItemDbDto);
        }
        /// <summary>
        /// Adds ToDoItem record to ToDoItem table.
        /// </summary>
        /// <param name="createToDoItemDto"></param>
        /// <returns>added ToDoItem record.</returns>
        public async Task<ToDoItemDto> AddToDoItem(CreateToDoItemDto createToDoItemDto)
        {
            TodoItemEntity toDoItemDbDto = _mapper.Map<TodoItemEntity>(createToDoItemDto);
            toDoItemDbDto.CreationDate = DateTime.UtcNow;
            _toDoDbContext.ToDoItems.Add(toDoItemDbDto);
            await _toDoDbContext.SaveChangesAsync();
            return _mapper.Map<ToDoItemDto>(toDoItemDbDto);
        }
        /// <summary>
        /// Updates todoitem record based on input.
        /// </summary>
        /// <param name="updateToDoItemDto">ToDoItemObject to be updated.</param>
        /// <returns> Updated ToDoItem record.</returns>
        public async Task<ToDoItemDto> UpdateToDoItem(UpdateToDoItemDto updateToDoItemDto)
        {
            TodoItemEntity toDoItemDbDto = await _toDoDbContext.ToDoItems
                .FirstOrDefaultAsync(p => p.ToDoItemId == updateToDoItemDto.ToDoItemId && p.CreatedBy == updateToDoItemDto.CreatedBy);
            if (toDoItemDbDto == null)
                return null;
            toDoItemDbDto.Notes = updateToDoItemDto.Notes;
            toDoItemDbDto.UpdationDate = DateTime.UtcNow;

            await _toDoDbContext.SaveChangesAsync();
            return _mapper.Map<ToDoItemDto>(toDoItemDbDto);
        }
        /// <summary>
        /// Delete ToDoItem record based on ToDoItemId passed.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userId"></param>
        /// <returns> 1 if success else -1. </returns>
        public async Task<int> DeleteToDoItem(long id, long userId)
        {
            TodoItemEntity toDoItemDbDto = await _toDoDbContext.ToDoItems
                .FirstOrDefaultAsync(p => p.ToDoItemId == id && p.CreatedBy == userId);
            if (toDoItemDbDto == null)
                return 0;
            _toDoDbContext.ToDoItems.Remove(toDoItemDbDto);
            return await _toDoDbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Create mapping of LabelId/s to ToDoItemId 
        /// </summary>
        /// <param name="assignLabelToItemDto"></param>
        /// <returns> success/failure result </returns>
        public async Task<bool> AssignLabelToItem(AssignLabelToItemDto assignLabelToItemDto)
        {
            //Remove existing mapping first 
            List<ToDoItemLabelsEntity> existingItemLabels = _toDoDbContext.ToDoItemLabels
                .Where(mapping => mapping.ToDoItemId == assignLabelToItemDto.ToDoItemId
                        && mapping.CreatedBy == assignLabelToItemDto.CreatedBy).ToList();
            TodoItemEntity existingToDoItemDbModel = _toDoDbContext.ToDoItems
                .Where(item => item.ToDoItemId == assignLabelToItemDto.ToDoItemId && item.CreatedBy == assignLabelToItemDto.CreatedBy).FirstOrDefault();
            int saveResult = 0;
            if (existingItemLabels != null && existingToDoItemDbModel != null)                // remove existing mapping first based on UserId and ToDoItemId combination.
            {
                foreach(var itemMapping in existingItemLabels)
                {
                    _toDoDbContext.ToDoItemLabels.Remove(itemMapping);
                }
                
                await _toDoDbContext.SaveChangesAsync();
                for (int labelId = 0; labelId < assignLabelToItemDto.LabelId.Length; labelId++)
                {
                    ToDoItemLabelsEntity mapLabelsToItemDbDto = new ToDoItemLabelsEntity
                    {
                        CreatedBy = assignLabelToItemDto.CreatedBy,
                        LabelId = assignLabelToItemDto.LabelId[labelId],
                        ToDoItemId = assignLabelToItemDto.ToDoItemId
                    };
                    _toDoDbContext.ToDoItemLabels.Add(mapLabelsToItemDbDto);
                }
                saveResult = await _toDoDbContext.SaveChangesAsync();
            }
            if (saveResult > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}

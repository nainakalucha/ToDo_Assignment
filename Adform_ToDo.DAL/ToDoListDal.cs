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
    public class ToDoListDal : IToDoListDal
    {
        private readonly ToDoDbContext _toDoDbContext;
        private readonly IMapper _mapper;
        public ToDoListDal(ToDoDbContext toDoDbContext, IMapper mapper)
        {
            _mapper = mapper;
            _toDoDbContext = toDoDbContext;
        }
        /// <summary>
        /// Gets all the todolist records.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>All ToDoList items for logged in User.</returns>
        public async Task<List<ToDoListDto>> GetAllToDoLists(long userId)
        {
            List<TodoListEntity> toDoLists = await _toDoDbContext.ToDoLists
                .Include(p => p.Labels)
                .Include(p => p.ToDoItems)
                .Where(p => p.CreatedBy == userId).ToListAsync();
            return _mapper.Map<List<ToDoListDto>>(toDoLists);
        }
        /// <summary>
        /// Get specific todolist record.
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="userId"></param>
        /// <returns>ToDoList item by Id for logged in user</returns>
        public async Task<ToDoListDto> GetToDoListById(long Id, long userId)
        {
            TodoListEntity toDoListDbDto = await _toDoDbContext.ToDoLists
                .Include(p => p.ToDoItems).Include(p => p.Labels).FirstOrDefaultAsync(p => p.ToDoListId == Id && p.CreatedBy == userId);
            return _mapper.Map<ToDoListDto>(toDoListDbDto);
        }
        /// <summary>
        /// Adds ToDoList record to ToDoList table.
        /// </summary>
        /// <param name="createToDoListDto"></param>
        /// <returns> added ToDoList record. </returns>
        public async Task<ToDoListDto> CreateToDoList(CreateToDoListDto createToDoListDto)
        {
            TodoListEntity toDoListDbDto = _mapper.Map<TodoListEntity>(createToDoListDto);
            toDoListDbDto.CreationDate = DateTime.UtcNow;
            _toDoDbContext.ToDoLists.Add(toDoListDbDto);
            await _toDoDbContext.SaveChangesAsync();
            return _mapper.Map<ToDoListDto>(toDoListDbDto);
        }
        /// <summary>
        /// Update ToDoListId.
        /// </summary>
        /// <param name="updateToDoListDto"></param>
        /// <returns> Updated ToDoListId. </returns>
        public async Task<ToDoListDto> UpdateToDoList(UpdateToDoListDto updateToDoListDto)
        {
            TodoListEntity toDoListDbModel = await _toDoDbContext.ToDoLists
                .FirstOrDefaultAsync(p => p.ToDoListId == updateToDoListDto.ToDoListId && p.CreatedBy == updateToDoListDto.CreatedBy);
            if (toDoListDbModel == null)
                return null;
            toDoListDbModel.Description = updateToDoListDto.Description;
            toDoListDbModel.UpdationDate = DateTime.UtcNow;
            await _toDoDbContext.SaveChangesAsync();
            return _mapper.Map<ToDoListDto>(toDoListDbModel);
        }
        /// <summary>
        /// Delete ToDoList record based on ToDoListId passed.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userId"></param>
        /// <returns> 1 if success else -1. </returns> 
        public async Task<int> DeleteToDoList(long id, long userId)
        {
            TodoListEntity toDoListDbDto = await _toDoDbContext.ToDoLists
                .FirstOrDefaultAsync(p => p.ToDoListId == id && p.CreatedBy == userId);
            if (toDoListDbDto == null)
                return 0;

            _toDoDbContext.ToDoLists.Remove(toDoListDbDto);
            return await _toDoDbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Create mapping of LabelId/s to ToDoListId 
        /// </summary>
        /// <param name="assignLabelToListDto"></param>
        /// <returns> success/failure result </returns>
        public async Task<bool> AssignLabelToList(AssignLabelToListDto assignLabelToListDto)
        {
            //Remove existing mapping first 
            List<ToDoListLabelsEntity> existingListLabels = _toDoDbContext.ToDoListLabels
                .Where(mapping => mapping.ToDoListId == assignLabelToListDto.ToDoListId
                        && mapping.CreatedBy == assignLabelToListDto.CreatedBy).ToList();
            TodoListEntity existingToDoListDbModel = _toDoDbContext.ToDoLists
                .Where(list => list.ToDoListId == assignLabelToListDto.ToDoListId && list.CreatedBy == assignLabelToListDto.CreatedBy).FirstOrDefault();
            int saveResult = 0;
            if (existingListLabels != null && existingToDoListDbModel != null)
            {
                foreach (var listMapping in existingListLabels)
                {
                    _toDoDbContext.ToDoListLabels.Remove(listMapping);
                }               
                await _toDoDbContext.SaveChangesAsync();

                for (int labelId = 0; labelId < assignLabelToListDto.LabelId.Length; labelId++)
                {
                    ToDoListLabelsEntity mapLabelsToListDbDto = new ToDoListLabelsEntity
                    {
                        CreatedBy = assignLabelToListDto.CreatedBy,
                        LabelId = assignLabelToListDto.LabelId[labelId],
                        ToDoListId = assignLabelToListDto.ToDoListId
                    };
                    _toDoDbContext.ToDoListLabels.Add(mapLabelsToListDbDto);
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

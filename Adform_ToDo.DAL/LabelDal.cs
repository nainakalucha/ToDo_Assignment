using Adform_Todo.Common.Contracts;
using Adform_Todo.Common.Dtos;
using Adform_Todo.Common.Models;
using AutoMapper;
using Adform_ToDo.DAL.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adform_ToDo.DAL
{
    public class LabelDal : ILabelDal
    {
        private readonly ToDoDbContext _toDoDbContext;
        private readonly IMapper _mapper;
        public LabelDal(ToDoDbContext toDoDbContext, IMapper mapper)
        {
            _mapper = mapper;
            _toDoDbContext = toDoDbContext;
        }
        /// <summary>
        /// Gets all the Label items.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>All Label items.</returns>
        public async Task<List<LabelDto>> GetAllLabels(long userId)
        {
            List<LabelEntity> Labels = await _toDoDbContext.Labels.Where(p => p.CreatedBy == userId).ToListAsync();
            return _mapper.Map<List<LabelDto>>(Labels);
        }
        /// <summary>
        /// Gets Label item by Id from database.
        /// </summary>
        /// <param name="labelId"></param>
        /// <param name="userId"></param>
        /// <returns>Label item by Id for logged in user</returns>
        public async Task<LabelDto> GetLabelById(long labelId, long userId)
        {
            LabelEntity LabelDbDto = await _toDoDbContext.Labels
                .FirstOrDefaultAsync(p => p.LabelId == labelId && p.CreatedBy == userId);
            return _mapper.Map<LabelDto>(LabelDbDto);
        }
        /// <summary>
        /// adds label in Label table
        /// </summary>
        /// <param name="createLabelDto"></param>
        /// <returns> added label record Dto. </returns>
        public async Task<LabelDto> AddLabel(CreateLabelDto createLabelDto)
        {
            LabelEntity labelDbDto = _mapper.Map<LabelEntity>(createLabelDto);
            labelDbDto.CreatedBy = createLabelDto.CreatedBy;
            _toDoDbContext.Labels.Add(labelDbDto);
            await _toDoDbContext.SaveChangesAsync();
            return _mapper.Map<LabelDto>(labelDbDto);
        }
        /// <summary>
        /// Delete Label record based on LabelId passed.
        /// </summary>
        /// <param name="labelId"></param>
        /// <param name="userId"></param>
        /// <returns> 1 if success else -1. </returns>
        public async Task<int> DeleteLabel(long labelId, long userId)
        {
            LabelEntity labelDbDto = await _toDoDbContext.Labels
                .FirstOrDefaultAsync(p => p.LabelId == labelId && p.CreatedBy == userId);
            if (labelDbDto == null)
                return 0;

            _toDoDbContext.Labels.Remove(labelDbDto);
            return await _toDoDbContext.SaveChangesAsync();
        }        
    }
}
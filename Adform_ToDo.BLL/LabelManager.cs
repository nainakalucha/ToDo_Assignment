using Adform_Todo.Common.Contracts;
using Adform_Todo.Common.Dtos;
using Adform_Todo.Common.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adform_ToDo.BL
{
    /// <summary>
    /// Implemenation of ILabelService contract.
    /// </summary>
    public class LabelManager : ILabelManager
    {
        private readonly ILabelDal _labelDal;
        public LabelManager(ILabelDal labelDal)
        {
            _labelDal = labelDal;
        }
        /// <summary>
        /// Get Label record By Id 
        /// </summary>
        /// <param name="labelId"></param>
        /// <param name="userId"></param>
        /// <returns>Label record based on LabelId</returns>
        public async Task<LabelDto> GetLabelById(long labelId, long userId)
        {
            return await _labelDal.GetLabelById(labelId, userId);
        }

        /// <summary>
        /// Get all labels.
        /// </summary>
        /// <param name="paginationParams"></param>
        /// <param name="userId"></param>
        /// <returns>Returns all labels for user.</returns>
        public async Task<PagedList<LabelDto>> GetAllLabels(PaginationParameters paginationParams, long userId)
        {
            List<LabelDto> Labels = await _labelDal.GetAllLabels(userId);
            if (!string.IsNullOrWhiteSpace(paginationParams.SearchString))
            {
                Labels = Labels.Where(p => p.Description.ToLower().Contains(paginationParams.SearchString.ToLower())).ToList();
            }
            return PagedList<LabelDto>.ToPagedList(Labels, paginationParams.PageNumber, paginationParams.PageSize);
        }
        /// <summary>
        /// adds label record to label table.
        /// </summary>
        /// <param name="createLabelDto"></param>
        /// <returns> Added Label record. </returns>
        public async Task<LabelDto> AddLabel(CreateLabelDto createLabelDto)
        {
            return await _labelDal.AddLabel(createLabelDto);
        }

        /// <summary>
        /// Delete label record.
        /// </summary>
        /// <param name="labelId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<int> DeleteLabel(long labelId, long userId)
        {
            return await _labelDal.DeleteLabel(labelId, userId);
        }
    }
}

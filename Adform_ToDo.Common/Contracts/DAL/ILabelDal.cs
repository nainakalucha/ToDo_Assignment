using Adform_Todo.Common.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Adform_Todo.Common.Contracts
{
    public interface ILabelDal
    {
        /// <summary>
        /// Delete label.
        /// </summary>
        /// <param name="labelId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<int> DeleteLabel(long labelId, long userId);

        /// <summary>
        /// Get label by id.
        /// </summary>
        /// <param name="labelId">label id.</param>
        /// <param name="userId">user id.</param>
        Task<LabelDto> GetLabelById(long labelId, long userId);

        /// <summary>
        /// Get all labels.
        /// </summary>
        /// <param name="userId">User id.</param>
        Task<List<LabelDto>> GetAllLabels(long userId);

        /// <summary>
        /// Add label.
        /// </summary>
        /// <param name="createLabelDto">Label details.</param>
        Task<LabelDto> AddLabel(CreateLabelDto createLabelDto);      
    }
}

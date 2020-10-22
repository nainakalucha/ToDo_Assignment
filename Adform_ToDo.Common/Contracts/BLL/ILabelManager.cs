using Adform_Todo.Common.Dtos;
using Adform_Todo.Common.Models;
using System.Threading.Tasks;

namespace Adform_Todo.Common.Contracts
{
    public interface ILabelManager
    {
        /// <summary>
        /// Get label by id.
        /// </summary>
        /// <param name="labelId">label id.</param>
        /// <param name="userId">user id.</param>
        Task<LabelDto> GetLabelById(long labelId, long userId);

        /// <summary>
        /// Get all labels
        /// </summary>
        /// <param name="paginationParams"></param>
        /// <param name="userId"></param>
        /// <returns></returns>        
        Task<PagedList<LabelDto>> GetAllLabels(PaginationParameters paginationParams, long userId);

        /// <summary>
        /// Add label.
        /// </summary>
        /// <param name="createLabelDto">Label details.</param>
        Task<LabelDto> AddLabel(CreateLabelDto createLabelDto);

        /// <summary>
        /// Delete label record
        /// </summary>
        /// <param name="labelId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<int> DeleteLabel(long labelId, long userId);
    }
}

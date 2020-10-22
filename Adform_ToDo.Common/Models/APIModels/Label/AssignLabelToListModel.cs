using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Adform_Todo.Common.Models
{
    [SwaggerSchemaFilter(typeof(AssignLabelToListModel))]
    public class AssignLabelToListModel : AssignLabelModel
    {
        [Required]
        public long ToDoListId { get; set; }
    }
}

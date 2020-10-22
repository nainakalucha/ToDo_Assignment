using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Adform_Todo.Common.Models
{
    public class AssignLabelToItemModel : AssignLabelModel
    {
        [Required]
        public long ToDoItemId { get; set; }
    }
}

using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Adform_Todo.Common.Models
{
    [SwaggerSchemaFilter(typeof(DeleteLabelModel))]
    public class DeleteLabelModel
    {
        [Required]
        public long LabelId { get; set; }
        [JsonIgnore]
        public long CreatedBy { get; set; }
    }
}

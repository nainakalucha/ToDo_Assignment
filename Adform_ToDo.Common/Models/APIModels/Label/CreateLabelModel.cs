using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Adform_Todo.Common.Models
{
    [SwaggerSchemaFilter(typeof(CreateLabelModel))]
    public class CreateLabelModel
    {
        public string Description { get; set; }
        [JsonIgnore]
        public long CreatedBy { get; set; }
    }
}

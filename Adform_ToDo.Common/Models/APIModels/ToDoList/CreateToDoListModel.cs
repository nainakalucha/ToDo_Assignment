using Swashbuckle.AspNetCore.Annotations;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Adform_Todo.Common.Models
{
    [SwaggerSchemaFilter(typeof(CreateToDoListModel))]
    public class CreateToDoListModel
    {
        public string Description { get; set; }
        [JsonIgnore]
        public long CreatedBy { get; set; }
        [JsonIgnore]
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;

    }
}

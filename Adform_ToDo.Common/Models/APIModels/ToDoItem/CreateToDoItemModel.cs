using Swashbuckle.AspNetCore.Annotations;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Adform_Todo.Common.Models
{
    [SwaggerSchemaFilter(typeof(CreateToDoItemModel))]
    public class CreateToDoItemModel
    {
        public long ToDoListId { get; set; }
        public string Notes { get; set; }
        [JsonIgnore]
        public long CreatedBy { get; set; }
        [JsonIgnore]
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;
    }
}
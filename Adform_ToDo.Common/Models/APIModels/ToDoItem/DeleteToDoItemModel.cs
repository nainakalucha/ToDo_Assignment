using Swashbuckle.AspNetCore.Annotations;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Adform_Todo.Common.Models
{
    [SwaggerSchemaFilter(typeof(DeleteToDoItemModel))]
    public class DeleteToDoItemModel
    {
        [Required]
        public long ToDoItemId { get; set; }
        [JsonIgnore]
        public long CreatedBy { get; set; }
    }
}
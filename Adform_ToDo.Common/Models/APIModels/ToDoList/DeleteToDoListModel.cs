using Swashbuckle.AspNetCore.Annotations;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Adform_Todo.Common.Models
{
    [SwaggerSchemaFilter(typeof(DeleteToDoListModel))]
    public class DeleteToDoListModel
    {
        [Required]
        public long ToDoListId { get; set; }
        [JsonIgnore]
        public long CreatedBy { get; set; }
    }
}

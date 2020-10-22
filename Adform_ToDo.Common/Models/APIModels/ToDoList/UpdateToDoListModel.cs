using Swashbuckle.AspNetCore.Annotations;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Adform_Todo.Common.Models
{
    [SwaggerSchemaFilter(typeof(UpdateToDoListModel))]
    public class UpdateToDoListModel
    {
        public string Description { get; set; }
        [Required]
        public long ToDoListId { get; set; }
        [JsonIgnore]
        public DateTime UpdationDate { get; set; } = DateTime.UtcNow;
        [JsonIgnore]
        public long CreatedBy { get; set; }
    }
}

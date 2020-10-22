using Swashbuckle.AspNetCore.Annotations;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Adform_Todo.Common.Models
{
    [SwaggerSchemaFilter(typeof(UpdateToDoItemModel))]
    public class UpdateToDoItemModel
    {
        public string Notes { get; set; }
        [Required]
        public long ToDoItemId { get; set; }
        [JsonIgnore]
        public DateTime UpdationDate { get; set; } = DateTime.UtcNow;
        [JsonIgnore]
        public long CreatedBy { get; set; }
    }
}
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Adform_Todo.Common.Models
{
    public class ToDoListModel
    {
        public long ToDoListId { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdationDate { get; set; }
        public LabelModel LabelModel { get; set; }
        [JsonIgnore]
        public long CreatedBy { get; set; }
    }
}

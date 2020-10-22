using Swashbuckle.AspNetCore.Annotations;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Adform_Todo.Common.Models
{
    public class ToDoItemModel
    {
        public long ToDoItemId { get; set; }
        public string Notes { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdationDate { get; set; }
        public long ToDoListId { get; set; }
    }
}
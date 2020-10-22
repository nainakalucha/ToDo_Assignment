using System;
using System.Collections.Generic;

namespace Adform_Todo.Common.Dtos
{
    public class ToDoItemDto
    {
        public long ToDoItemId { get; set; }
        public string Notes { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdationDate { get; set; }
        public long ToDoListId { get; set; }
        public List<ToDoItemLabelsDto> Labels { get; set; }
    }
}
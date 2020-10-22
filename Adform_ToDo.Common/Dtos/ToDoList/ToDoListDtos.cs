using System;
using System.Collections.Generic;

namespace Adform_Todo.Common.Dtos
{
    public class ToDoListDto
    {
        public long ToDoListId { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdationDate { get; set; }
        public long CreatedBy { get; set; }
        public List<ToDoListLabelsDto> Labels { get; set; }
        public List<ToDoItemDto> ToDoItems { get; set; }
    }
}

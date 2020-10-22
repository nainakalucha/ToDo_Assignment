using System;
using System.Collections.Generic;

namespace Adform_Todo.Common.Dtos
{
    public class CreateToDoItemDto
    {
        public long ToDoListId { get; set; }
        public string Notes { get; set; }
        public long CreatedBy { get; set; }
    }
}
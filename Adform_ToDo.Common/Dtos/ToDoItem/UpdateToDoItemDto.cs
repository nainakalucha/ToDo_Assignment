using System;
using System.Collections.Generic;

namespace Adform_Todo.Common.Dtos
{
    public class UpdateToDoItemDto
    {
        public string Notes { get; set; }
        public long ToDoItemId { get; set; }
        public long CreatedBy { get; set; }
    }
}
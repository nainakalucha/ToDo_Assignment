using System;
using System.Collections.Generic;

namespace Adform_Todo.Common.Dtos
{
    public class DeleteToDoItemDto
    {
        public long ToDoItemId { get; set; }
        public long CreatedBy { get; set; }
    }
}
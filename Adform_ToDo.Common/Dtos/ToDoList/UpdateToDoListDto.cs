using System;
using System.Collections.Generic;

namespace Adform_Todo.Common.Dtos
{
    public class UpdateToDoListDto
    {
        public string Description { get; set; }
        public long ToDoListId { get; set; }
        public long CreatedBy { get; set; }
    }
}

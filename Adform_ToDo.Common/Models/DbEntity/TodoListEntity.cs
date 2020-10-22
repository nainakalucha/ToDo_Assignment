using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Adform_Todo.Common.Models
{
    public class TodoListEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ToDoListId { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdationDate { get; set; }
        public List<TodoItemEntity> ToDoItems { get; set; }

        public long CreatedBy { get; set; }
        [ForeignKey("CreatedBy")]
        public virtual UserEntity Users { get; set; }

        public List<ToDoListLabelsEntity> Labels { get; set; }
    }
}

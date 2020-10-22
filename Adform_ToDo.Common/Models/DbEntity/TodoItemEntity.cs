using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Adform_Todo.Common.Models
{
    public class TodoItemEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ToDoItemId { get; set; }
        public string Notes { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdationDate { get; set; }

        public List<ToDoItemLabelsEntity> Labels { get; set; }

        public long CreatedBy { get; set; }
        [ForeignKey("CreatedBy")]
        public virtual UserEntity Users { get; set; }

        public long ToDoListId { get; set; }
        [ForeignKey("ToDoListId")]
        public virtual TodoListEntity ToDoLists { get; set; }
    }
}
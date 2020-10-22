using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Adform_Todo.Common.Models
{
    public class ToDoItemLabelsEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ItemMappingId { get; set; }

        public long LabelId { get; set; }
        [ForeignKey("LabelId")]
        public virtual LabelEntity Labels { get; set; }

        public long ToDoItemId { get; set; }
        [ForeignKey("ToDoItemId")]
        public virtual TodoItemEntity ToDoItems { get; set; }

        public long CreatedBy { get; set; }
        [ForeignKey("CreatedBy")]
        public virtual UserEntity Users { get; set; }
    }
}
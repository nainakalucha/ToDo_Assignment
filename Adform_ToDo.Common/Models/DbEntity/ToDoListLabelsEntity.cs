using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Adform_Todo.Common.Models
{
    public class ToDoListLabelsEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ListMappingId { get; set; }

        public long LabelId { get; set; }
        [ForeignKey("LabelId")]
        public virtual LabelEntity Labels { get; set; }

        public long ToDoListId { get; set; }
        [ForeignKey("ToDoListId")]
        public virtual TodoListEntity ToDoLists { get; set; }

        public long CreatedBy { get; set; }
        [ForeignKey("CreatedBy")]
        public virtual UserEntity Users { get; set; }
    }
}

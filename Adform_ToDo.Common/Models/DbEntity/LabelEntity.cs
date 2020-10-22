using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Adform_Todo.Common.Models
{
    public class LabelEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long LabelId { get; set; }
        public string Description { get; set; }

        public long CreatedBy { get; set; }
        [ForeignKey("CreatedBy")]
        public virtual UserEntity Users { get; set; }
    }
}
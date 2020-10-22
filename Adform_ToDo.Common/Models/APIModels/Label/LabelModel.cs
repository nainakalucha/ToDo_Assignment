using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Adform_Todo.Common.Models
{
    public class LabelModel
    {
        public long LabelId { get; set; }
        public string Description { get; set; }
        public long CreatedBy { get; set; }
    }
}

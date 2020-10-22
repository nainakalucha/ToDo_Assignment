using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Adform_Todo.Common.Models
{
    public class AssignLabelModel
    {
        public long[] LabelId;
        [JsonIgnore]
        public long CreatedBy { get; set; }
    }
}

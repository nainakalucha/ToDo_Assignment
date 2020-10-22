using System.Text.Json.Serialization;

namespace Adform_Todo.Common.Dtos
{
    public class ToDoListLabelsDto : LabelDto
    {
        [JsonIgnore]
        public new string Description { get; set; }
    }
}

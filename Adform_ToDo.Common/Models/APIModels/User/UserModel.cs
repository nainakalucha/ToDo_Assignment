using Swashbuckle.AspNetCore.Annotations;
using System.Text.Json.Serialization;

namespace Adform_Todo.Common.Models
{
    public class UserModel
    {
        [JsonIgnore]
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        [JsonIgnore]
        public string UserRole { get; set; }
    }
}

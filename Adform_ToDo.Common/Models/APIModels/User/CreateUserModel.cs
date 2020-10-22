using Swashbuckle.AspNetCore.Annotations;
using System.Text.Json.Serialization;

namespace Adform_Todo.Common.Models
{
    [SwaggerSchemaFilter(typeof(CreateUserModel))]
    public class CreateUserModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
    }
}

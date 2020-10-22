using Swashbuckle.AspNetCore.Annotations;

namespace Adform_Todo.Common.Models
{

    [SwaggerSchemaFilter(typeof(LoginModel))]
    public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}

using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;

namespace Adform_ToDo.Filters
{
    /// <summary>
    /// SampleSchemaFilter Class
    /// </summary>
    public class SampleSchemaFilter : ISchemaFilter
    {
        /// <summary>
        /// Apply
        /// </summary>
        /// <param name="schema"></param>
        /// <param name="context"></param>
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            schema.Example = SetSample(context.Type);
        }

        private IOpenApiAny SetSample(Type type)
        {
            return type.Name switch
            {
                "CreateLabelModel" => new OpenApiObject
                {
                    ["Description"] = new OpenApiString("Animation")
                },
                "DeleteLabelModel" => new OpenApiObject
                {
                    ["LabelId"] = new OpenApiLong(3)
                },
                "AssignLabelToListModel" => new OpenApiObject
                {
                    ["LabelId"] = new OpenApiArray(),
                    ["ToDoListId"] = new OpenApiLong(2)
                },
                "AssignLabelToItemModel" => new OpenApiObject
                {
                    ["LabelId"] = new OpenApiArray(),
                    ["ToDoItemId"] = new OpenApiLong(3)
                },
                "AssignLabelModel" => new OpenApiObject
                {
                    ["LabelId"] = new OpenApiArray()
                },
                "CreateToDoItemModel" => new OpenApiObject
                {
                    ["ToDoListId"] = new OpenApiLong(1),
                    ["Notes"] = new OpenApiString("Review movies")
                },
                "UpdateToDoItemModel" => new OpenApiObject
                {
                    ["ToDoItemId"] = new OpenApiLong(2),
                    ["Notes"] = new OpenApiString("Review animation movies")
                },
                "DeleteToDoItemModel" => new OpenApiObject
                {
                    ["ToDoItemId"] = new OpenApiLong(1)
                },
                "CreateToDoListModel" => new OpenApiObject
                {
                    ["Description"] = new OpenApiString("List of animation movies")
                },
                "UpdateToDoListModel" => new OpenApiObject
                {
                    ["ToDoListId"] = new OpenApiLong(2),
                    ["Description"] = new OpenApiString("List of animation movies")
                },
                "DeleteToDoListModel" => new OpenApiObject
                {
                    ["ToDoListId"] = new OpenApiLong(1)
                },
                "CreateUserModel" => new OpenApiObject
                {
                    ["FirstName"] = new OpenApiString("FirstName"),
                    ["LastName"] = new OpenApiString("LastName"),
                    ["UserName"] = new OpenApiString("UserName"),
                    ["Password"] = new OpenApiString("12345"),
                },
                "LoginModel" => new OpenApiObject
                {
                    ["UserName"] = new OpenApiString("UserName"),
                    ["Password"] = new OpenApiString("12345"),
                },
                _ => null,
            };
        }
    }
}

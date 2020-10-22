using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;

namespace Adform_ToDo.Filters
{
    public class SampleSchemaFilter : ISchemaFilter
    {
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
                    ["Description"] = new OpenApiString("Review")
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
                "CreateToDoItemModel" => new OpenApiObject
                {
                    ["ToDoListId"] = new OpenApiLong(1),
                    ["Notes"] = new OpenApiString("Review movies")
                },
                "UpdateToDoItemModel" => new OpenApiObject
                {
                    ["ToDoItemId"] = new OpenApiLong(2),
                    ["Notes"] = new OpenApiString("Review romantic movies")
                },
                "DeleteToDoItemModel" => new OpenApiObject
                {
                    ["ToDoItemId"] = new OpenApiLong(1)
                },
                "CreateToDoListModel" => new OpenApiObject
                {
                    ["Description"] = new OpenApiString("List of movies")
                },
                "UpdateToDoListModel" => new OpenApiObject
                {
                    ["ToDoListId"] = new OpenApiLong(2),
                    ["Description"] = new OpenApiString("List of action movies")
                },
                "DeleteToDoListModel" => new OpenApiObject
                {
                    ["ToDoListId"] = new OpenApiLong(1)
                },
                "CreateUserModel" => new OpenApiObject
                {
                    ["FirstName"] = new OpenApiString("Sunaina"),
                    ["LastName"] = new OpenApiString("Kalucha"),
                    ["UserName"] = new OpenApiString("Sunaina"),
                    ["Password"] = new OpenApiString("12345"),
                },
                "LoginModel" => new OpenApiObject
                {
                    ["UserName"] = new OpenApiString("Sunaina"),
                    ["Password"] = new OpenApiString("12345"),
                },
                _ => null,
            };
        }
    }
}

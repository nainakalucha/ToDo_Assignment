using Microsoft.AspNetCore.JsonPatch.Operations;
using Swashbuckle.AspNetCore.Filters;

/// <summary>
/// JsonPatchPersonRequestExample
/// </summary>
public class JsonPatchPersonRequestExample : IExamplesProvider<Operation>
{
    /// <summary>
    /// GetExamples
    /// </summary>
    /// <returns></returns>
    public Operation GetExamples()
    {
        return new Operation
        {
            op = "replace",
            path = "/PropertyName",
            value = "NewValue"
        };
    }
}
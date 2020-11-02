using Adform_ToDo.API.GraphQl;
using Adform_ToDo.API.GraphQl.Mutations;
using HotChocolate;
using Microsoft.Extensions.DependencyInjection;

namespace Adform_ToDo.API.Services
{
    /// <summary>
    /// Extensionn method for configure IService Collection for adding GraphQl services.
    /// </summary>
    public static class GraphQLServiceExtension
    {
        /// <summary>
        /// AddGraphQLServices
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public static IServiceCollection AddGraphQLServices(this IServiceCollection service)
        {
            return service.AddGraphQL(s => SchemaBuilder.New()
                    .AddServices(s)
                    .AddQueryType<Query>()
                    .AddMutationType<Mutation>()
                    .Create());
        }
    }
}

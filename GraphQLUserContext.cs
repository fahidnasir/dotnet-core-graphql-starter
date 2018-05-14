namespace dotnet_core_graphql_starter
{
    using System.Security.Claims;

    public class GraphQLUserContext
    {
        public ClaimsPrincipal User { get; set; }
    }
}

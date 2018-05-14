namespace dotnet_core_graphql_starter
{
    using dotnet_core_graphql_starter.Repositories;
    using dotnet_core_graphql_starter.Schemas;
    using dotnet_core_graphql_starter.Types;
    using GraphQL.Server.Transports.WebSockets;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// <see cref="IServiceCollection"/> extension methods add project services.
    /// </summary>
    /// <remarks>
    /// AddSingleton - Only one instance is ever created and returned.
    /// AddScoped - A new instance is created and returned for each request/response cycle.
    /// AddTransient - A new instance is created and returned each time.
    /// </remarks>
    public static class ProjectServiceCollectionExtensions
    {
        /// <summary>
        /// Add project data repositories.
        /// </summary>
        public static IServiceCollection AddProjectRepositories(this IServiceCollection services) =>
            services
                .AddSingleton<IDroidRepository, DroidRepository>()
                .AddSingleton<IHumanRepository, HumanRepository>();

        /// <summary>
        /// Add project GraphQL types.
        /// </summary>
        public static IServiceCollection AddProjectGraphQLTypes(this IServiceCollection services) =>
            services
                .AddSingleton<CharacterInterface>()
                .AddSingleton<DroidObject>()
                .AddSingleton<EpisodeEnumeration>()
                .AddSingleton<HumanCreatedEvent>()
                .AddSingleton<HumanInputObject>()
                .AddSingleton<HumanObject>();

        /// <summary>
        /// Add project GraphQL schema and web socket types.
        /// </summary>
        public static IServiceCollection AddProjectGraphQLSchemas(this IServiceCollection services) =>
            services
                .AddSingleton<RootQuery>()
                .AddSingleton<RootMutation>()
                .AddSingleton<RootSubscription>()
                .AddSingleton<MainSchema>()
                .AddGraphQLWebSocket<MainSchema>();
    }
}

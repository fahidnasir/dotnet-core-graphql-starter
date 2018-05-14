namespace dotnet_core_graphql_starter.Schemas
{
    using GraphQL;
    using GraphQL.Types;

    public class MainSchema : Schema
    {
        public MainSchema(
            RootQuery query,
            RootMutation mutation,
            RootSubscription subscription,
            IDependencyResolver resolver)

            : base(resolver)
        {
            this.Query = resolver.Resolve<RootQuery>();
            this.Mutation = mutation;
            this.Subscription = subscription;
        }
    }
}

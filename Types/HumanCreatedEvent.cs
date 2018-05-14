namespace dotnet_core_graphql_starter.Types
{
    using dotnet_core_graphql_starter.Repositories;

    public class HumanCreatedEvent : HumanObject
    {
        public HumanCreatedEvent(IHumanRepository humanRepository) : base(humanRepository)
        {
        }
    }
}

namespace dotnet_core_graphql_starter.Types
{
    using GraphQL.Types;
    using dotnet_core_graphql_starter.Models;

    public class HumanInputObject : InputObjectGraphType
    {
        public HumanInputObject()
        {
            this.Name = "HumanInput";
            this.Description = "A humanoid creature from the Star Wars universe.";

            this.Field<NonNullGraphType<StringGraphType>>(nameof(Human.Name));
            this.Field<StringGraphType>(nameof(Human.HomePlanet));
            this.Field<ListGraphType<EpisodeEnumeration>>(nameof(Human.AppearsIn), "Which movie they appear in.");
        }
    }
}

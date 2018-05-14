namespace dotnet_core_graphql_starter.Types
{
    using System.Collections.Generic;
    using GraphQL.Types;
    using dotnet_core_graphql_starter.Models;
    using dotnet_core_graphql_starter.Repositories;

    public class HumanObject : ObjectGraphType<Human>
    {
        public HumanObject(IHumanRepository humanRepository)
        {
            this.Name = "Human";
            this.Description = "A humanoid creature from the Star Wars universe.";

            this.Field(x => x.Id, type: typeof(IdGraphType)).Description("The unique identifier of the human.");
            this.Field(x => x.Name).Description("The name of the human.");
            this.Field(x => x.HomePlanet, nullable: true).Description("The home planet of the human.");
            this.Field<ListGraphType<EpisodeEnumeration>>(nameof(Character.AppearsIn), "Which movie they appear in.");

            this.FieldAsync<ListGraphType<CharacterInterface>, List<Character>>(
                nameof(Human.Friends),
                "The friends of the character, or an empty list if they have none.",
                resolve: context => humanRepository.GetFriends(context.Source, context.CancellationToken));

            this.Interface<CharacterInterface>();
        }
    }
}

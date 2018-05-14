namespace dotnet_core_graphql_starter.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using dotnet_core_graphql_starter.Models;

    public class DroidRepository : IDroidRepository
    {
        public Task<Droid> GetDroid(Guid id, CancellationToken cancellationToken) =>
            Task.FromResult(Database.Droids.FirstOrDefault(x => x.Id == id));

        public Task<List<Character>> GetFriends(Droid droid, CancellationToken cancellationToken) =>
            Task.FromResult(Database.Characters.Where(x => droid.Friends.Contains(x.Id)).ToList());
    }
}

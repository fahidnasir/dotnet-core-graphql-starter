namespace dotnet_core_graphql_starter.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using dotnet_core_graphql_starter.Models;

    public interface IDroidRepository
    {
        Task<Droid> GetDroid(Guid id, CancellationToken cancellationToken);

        Task<List<Character>> GetFriends(Droid droid, CancellationToken cancellationToken);
    }
}

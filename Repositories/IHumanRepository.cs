namespace dotnet_core_graphql_starter.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using dotnet_core_graphql_starter.Models;

    public interface IHumanRepository
    {
        IObservable<Human> WhenHumanCreated { get; }

        Task<Human> AddHuman(Human human, CancellationToken cancellationToken);

        Task<List<Character>> GetFriends(Human human, CancellationToken cancellationToken);

        Task<Human> GetHuman(Guid id, CancellationToken cancellationToken);
    }
}

namespace dotnet_core_graphql_starter.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reactive.Linq;
    using System.Reactive.Subjects;
    using System.Threading;
    using System.Threading.Tasks;
    using dotnet_core_graphql_starter.Models;

    public class HumanRepository : IHumanRepository
    {
        private readonly Subject<Human> whenHumanCreated;

        public HumanRepository() => this.whenHumanCreated = new Subject<Human>();

        public IObservable<Human> WhenHumanCreated => this.whenHumanCreated.AsObservable();

        public Task<Human> AddHuman(Human human, CancellationToken cancellationToken)
        {
            human.Id = Guid.NewGuid();
            Database.Humans.Add(human);
            this.whenHumanCreated.OnNext(human);
            return Task.FromResult(human);
        }

        public Task<List<Character>> GetFriends(Human human, CancellationToken cancellationToken) =>
            Task.FromResult(Database.Characters.Where(x => human.Friends.Contains(x.Id)).ToList());

        public Task<Human> GetHuman(Guid id, CancellationToken cancellationToken) =>
            Task.FromResult(Database.Humans.FirstOrDefault(x => x.Id == id));
    }
}

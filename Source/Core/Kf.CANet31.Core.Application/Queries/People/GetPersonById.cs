using Kf.CANet31.Core.Domain.People;
using Kf.Essentials.CleanArchitecture.Cqs.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace Kf.CANet31.Core.Application.Queries.People
{
    public sealed class GetPersonById
    {
        public sealed class Query : IQuery<Person> 
        {            
            public Query(long id)
                => Id = id;            

            public long Id { get; }
        }

        public sealed class Handler : QueryHandler<Query, Person>
        {
            private readonly IDatabaseContext _databaseContext;

            public Handler(IDatabaseContext databaseContext)
                => _databaseContext = databaseContext;

            public override async Task<Person> HandleAsync(
                Query query,
                CancellationToken cancellationToken
            )
                => await _databaseContext
                    .People
                    .FindAsync(query.Id);
        }
    }
}

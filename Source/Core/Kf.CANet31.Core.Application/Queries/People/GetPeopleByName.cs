using Kf.CANet31.Core.Domain.People;
using Kf.Essentials.CleanArchitecture.Cqs.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Kf.CANet31.Core.Application.Queries.People
{
    public sealed class GetPeopleByName
    {
        public sealed class Query : IQuery<IEnumerable<Person>>
        {
            public Query(string partOfName)
                => PartOfName = partOfName;            

            public string PartOfName { get; }
        }

        public sealed class Handler : QueryHandler<Query, IEnumerable<Person>>
        {
            private readonly IDatabaseContext _databaseContext;

            public Handler(IDatabaseContext databaseContext)
                => _databaseContext = databaseContext;

            public override async Task<IEnumerable<Person>> HandleAsync(
                Query query,
                CancellationToken cancellationToken
            )
                => await Task.Run(() => _databaseContext
                    .People
                    .Where(person =>
                        $"{person.Name.FirstName}{person.Name.LastName}"
                        .Contains(query.PartOfName, StringComparison.InvariantCultureIgnoreCase)
                    )
                    .AsEnumerable()
                );
        }
    }
}

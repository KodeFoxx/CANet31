using FluentAssertions;
using Kf.CANet31.Core.Application.Queries.People;
using Kf.CANet31.Core.Domain.People;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Kf.CANet31.Test.UnitTests.Core.Application.Queries.People
{
    public sealed class GetPersonByIdTests
    {
        [Fact]
        public async Task Returns_Person_when_found()
        {
            using (var db = InMemoryDatabaseContext
                .CreateDatabaseContext(
                    nameof(Returns_Person_when_found),
                    new List<Person> { Person.Create(33311, Name.Create("Yves", "Schelpe")) }
                )
            )
            {
                var sut = new GetPersonById.Handler(db);
                var result = await sut.HandleAsync(
                    new GetPersonById.Query(33311), 
                    CancellationToken.None
                );

                result.Should().NotBeNull();
                result.Name.FirstName.Should().Be("Yves");
            }

        }

        [Fact]
        public async Task Returns_null_when_not_found()
        {
            using (var db = InMemoryDatabaseContext
                .CreateDatabaseContext(
                    nameof(Returns_null_when_not_found)                   
                )
            )
            {
                var sut = new GetPersonById.Handler(db);
                var result = await sut.HandleAsync(
                    new GetPersonById.Query(0), 
                    CancellationToken.None
                );

                result.Should().BeNull();                
            }
        }
    }
}

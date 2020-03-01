using FluentAssertions;
using Kf.CANet31.Core.Application.Queries.People;
using Kf.CANet31.Core.Domain.People;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Kf.CANet31.Test.UnitTests.Core.Application.Queries.People
{
    public sealed class GetPeopleByNameTests
    {
        [Theory]
        [InlineData("schelpe")]
        [InlineData("yve")]
        [InlineData("Schelpe")]
        [InlineData("yves")]
        [InlineData("ssch")]
        public async Task Returns_IEnumerable_of_Person_when_match_is_found_case_is_ignored(
            string partOfName
        )
        {
            using (var db = InMemoryDatabaseContext
                .CreateDatabaseContext(
                    $"{nameof(Returns_IEnumerable_of_Person_when_match_is_found_case_is_ignored)}_{partOfName}",
                    new List<Person> { Person.Create(33311, Name.Create("Yves", "Schelpe")) }
                )
            )
            {
                var sut = new GetPeopleByName.Handler(db);
                var result = await sut.HandleAsync(
                    new GetPeopleByName.Query(partOfName),
                    CancellationToken.None
                );

                result.Should().NotBeEmpty();
                result.ElementAt(0).Name.FirstName.Should().Be("Yves");
            }

        }

        [Fact]
        public async Task Returns_empty_IEnumerable_of_Person_when_not_found()
        {
            using (var db = InMemoryDatabaseContext
                .CreateDatabaseContext(
                    nameof(Returns_empty_IEnumerable_of_Person_when_not_found)
                )
            )
            {
                var sut = new GetPeopleByName.Handler(db);
                var result = await sut.HandleAsync(
                    new GetPeopleByName.Query("schelpe"), 
                    CancellationToken.None
                );

                result.Should().NotBeNull();
                result.Should().BeEmpty();
            }
        }
    }
}

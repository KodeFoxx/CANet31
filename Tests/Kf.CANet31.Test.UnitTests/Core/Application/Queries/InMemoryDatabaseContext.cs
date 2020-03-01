using Kf.CANet31.Core.Domain.People;
using Kf.CANet31.Infrastructure.Persistence.Ef;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Kf.CANet31.Test.UnitTests.Core.Application.Queries
{
    public static class InMemoryDatabaseContext
    {
        public static DatabaseContext CreateDatabaseContext(
            string databaseName,
            List<Person> people = null
        )
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName)
                .Options;

            var databaseContext = new DatabaseContext(options);            
            databaseContext.People.AddRange(people.IfNullThenEmpty());
            databaseContext.SaveChanges();

            return databaseContext;            
        }
    }
}

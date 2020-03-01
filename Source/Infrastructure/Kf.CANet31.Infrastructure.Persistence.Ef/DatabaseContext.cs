using Kf.CANet31.Core.Application;
using Kf.CANet31.Core.Domain.People;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Kf.CANet31.Infrastructure.Persistence.Ef
{
    public sealed class DatabaseContext
        : DbContext, IDatabaseContext
    {
        private readonly ILogger<DatabaseContext> _logger;

        public DatabaseContext(
            ILogger<DatabaseContext> logger,
            DbContextOptions options
        ) : base(options)
            => _logger = logger;
        public DatabaseContext(
            DbContextOptions options)
            : base(options)
        { }

        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}

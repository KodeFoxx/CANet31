using Kf.CANet31.Core.Domain.People;
using Microsoft.EntityFrameworkCore;

namespace Kf.CANet31.Core.Application
{
    public interface IDatabaseContext
    {
        DbSet<Person> People { get; set; }
    }
}

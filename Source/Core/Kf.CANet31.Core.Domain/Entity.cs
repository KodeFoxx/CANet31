using Kf.Essentials.CleanArchitecture.Model;

namespace Kf.CANet31.Core.Domain
{
    public abstract class Entity : Entity<long>
    {
        protected Entity(long id) 
            : base(id)
        { }
    }
}

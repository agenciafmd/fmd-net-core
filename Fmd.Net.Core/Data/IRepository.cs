using Fmd.Net.Core.DomainObjects;

namespace Fmd.Net.Core.Data;

public interface IRepository<T> : IDisposable where T : IAggregateRoot
{
    IUnitOfWork UnitOfWork { get; }
}
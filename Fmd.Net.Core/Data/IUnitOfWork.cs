namespace Fmd.Net.Core.Data;

public interface IUnitOfWork
{
    Task<bool> Commit();
}
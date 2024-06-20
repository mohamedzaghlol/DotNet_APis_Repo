using Domain.Models;

namespace Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {

        IBaseRepository<Product> Products { get; }
        IBaseRepository<Person> Persons { get; }

        Task<bool> Commit();
        int Complete();
        Task Rollback();
        void BeginTransaction();
        void CommitTransaction();
        void RollBackTransaction();
    }
}
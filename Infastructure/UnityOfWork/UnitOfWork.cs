using Application.Interfaces;
using Domain.Models;
using LBInfastructure.Context;
using LBInfastructure.Core;

namespace LBInfastructure.UnityOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LB _context;
        public IBaseRepository<Product> Products { get; private set; }
        public IBaseRepository<Person> Persons { get; private set; }

        public UnitOfWork(LB context)
        {
            _context = context;
            Products = new BaseRepository<Product>(_context);
            Persons = new BaseRepository<Person>(_context);
        }

        public async Task<bool> Commit()
        {
            var success = await _context.SaveChangesAsync() > 0;
            // Possibility to dispatch domain events, etc
            return success;
        }

        public int Complete()
        {
            return _context.SaveChanges();

        }

        public void Dispose() =>
            _context.Dispose();

        public Task Rollback()
        {
            // Rollback anything, if necessary
            return Task.CompletedTask;
        }

        public void BeginTransaction()
        {
            _context.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _context.Database.CommitTransaction();
        }
        public void RollBackTransaction()
        {
            _context.Database.CommitTransaction();
        }
    }
}
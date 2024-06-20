using Application.Interfaces;
using LBInfastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace LBInfastructure.Core
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly LB _context;

        public BaseRepository(LB context)
        {
            _context = context;
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsQueryable();
        }

        public T Add(T entity)
        {
            try
            {
                _context.Set<T>().Add(entity);
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public T Update(T entity)
        {
            _context.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }
        public T GetByid(int id)
        {
            return _context.Set<T>().Find(id);
        }
        public void Delete(T Entity)
        {
            _context.Set<T>().Remove(Entity);
        }

    }
}

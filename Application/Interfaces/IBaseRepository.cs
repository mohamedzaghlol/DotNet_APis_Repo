namespace Application.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        T GetByid(int id);
        IQueryable<T> GetAll();
        T Add(T Entity);
        T Update(T Entity);
        void Delete(T Entity);
    }
}

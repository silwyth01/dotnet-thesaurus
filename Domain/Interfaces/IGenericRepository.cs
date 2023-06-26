namespace Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        bool SaveChanges();
        IEnumerable<T> GetAll();
        T? GetById(int id);
        void Create(T item);
        void Update(T item);
        void Delete(T item);
    }
}

using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ThesaurusContext _context;
        private readonly DbSet<T> _table;

        public GenericRepository(ThesaurusContext context)
        {
            _context = context;
            _table = context.Set<T>();
        }

        public void Create(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            _table.Add(item);
        }

        public void Delete(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            _table.Remove(item);
        }

        public IEnumerable<T> GetAll()
        {
            return _table.ToList();
        }

        public T? GetById(int id)
        {
            return _table.Find(id);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public void Update(T item)
        {

        }
    }
}

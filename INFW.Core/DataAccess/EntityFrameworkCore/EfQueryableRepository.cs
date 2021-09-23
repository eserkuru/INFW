using System.Linq;
using Microsoft.EntityFrameworkCore;
using INFW.Core.Entities;

namespace INFW.Core.DataAccess.EntityFrameworkCore
{
    /// <summary>
    /// Represents the class that will allow querying from the database using entity framework core.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EfQueryableRepository<T> : IQueryableRepository<T> where T : class, IEntity, new()
    {
        private readonly DbContext _context;
        private DbSet<T> _entities;

        public EfQueryableRepository(DbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Returns the table to be subscribed to.
        /// </summary>
        public IQueryable<T> Table => Entities;

        /// <summary>
        /// Gets the entity to be queried from the context.
        /// </summary>
        protected virtual DbSet<T> Entities => _entities ?? (_entities = _context.Set<T>());
    }
}

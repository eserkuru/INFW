using System.Linq;
using INFW.Core.Entities;

namespace INFW.Core.DataAccess
{
    /// <summary>
    /// Represents the class that will allow querying from the database.
    /// </summary>
    public interface IQueryableRepository<T> where T : class, IEntity, new()
    {
        /// <summary>
        /// Returns the table to be subscribed to.
        /// </summary>
        IQueryable<T> Table { get; }
    }
}

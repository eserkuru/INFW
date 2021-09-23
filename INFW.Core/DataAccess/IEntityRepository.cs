using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using INFW.Core.Entities;

namespace INFW.Core.DataAccess
{
    /// <summary>
    /// Represents the class to allow processing of database records.
    /// </summary>
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        /// <summary>
        /// Returns a single record of the given entity from the database.
        /// </summary>
        T Get(Expression<Func<T, bool>> filter = null);

        /// <summary>
        /// Returns the list record of the given entity from the database.
        /// </summary>
        List<T> GetList(Expression<Func<T, bool>> filter = null);

        /// <summary>
        /// Adds the given entity to the database.
        /// </summary>
        void Add(T entity);

        /// <summary>
        /// Updates the given entity in the database.
        /// </summary>
        void Update(T entity);

        /// <summary>
        /// Removes the given entity from the database.
        /// </summary>
        void Delete(T entity);
    }
}

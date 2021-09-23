using INFW.Core.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace INFW.Core.DataAccess.MongoDbDriver
{
    public class MongoEntityRepositoryBase<TEntity, TClient> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TClient : class, IMongoDbClient, new()
    {
        private string CollectionName { get; set; }
        public MongoEntityRepositoryBase()
        {
            CollectionName = typeof(TEntity).Name + "s"; // TODO: Geçici çözüm.
        }
        public void Add(TEntity entity)
        {
            using (var client = new TClient())
            {
                client.Database.GetCollection<TEntity>(CollectionName).InsertOne(entity);
            }
        }

        public void Delete(TEntity entity)
        {
            using (var client = new TClient())
            {
                client.Database.GetCollection<TEntity>(CollectionName).DeleteOne(c => c.Id == entity.Id);
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var client = new TClient())
            {
                return filter == null
                    ? client.Database.GetCollection<TEntity>(CollectionName).Find(c => true).FirstOrDefault()
                    : client.Database.GetCollection<TEntity>(CollectionName).Find(filter).FirstOrDefault();
            }
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var client = new TClient())
            {
                return filter == null
                    ? client.Database.GetCollection<TEntity>(CollectionName).Find(c => true).ToList()
                    : client.Database.GetCollection<TEntity>(CollectionName).Find(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (var client = new TClient())
            {
                client.Database.GetCollection<TEntity>(CollectionName).ReplaceOne(c => c.Id == entity.Id, entity);
            }
        }
    }
}

using MongoDB.Driver;
using System;

namespace INFW.Core.DataAccess.MongoDbDriver
{
    public interface IMongoDbClient : IDisposable
    {
        IMongoDatabase Database { get; }
    }
}

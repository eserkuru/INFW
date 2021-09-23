using INFW.Core.DataAccess.MongoDbDriver;
using INFW.Core.DataAccess.MongoDbDriver.Configuration;
using MongoDB.Driver;
using System;

namespace INFW.Authorization.DataAccess.Concrete.MongoDbDriver.Clients
{
    public class AuthorizationClient : DbClientHelper
    {
        public AuthorizationClient() : base("Authorization") { }
    }
}
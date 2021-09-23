using INFW.Core.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace INFW.Authorization.Entities.Concrete
{
    public class UserRole : EntityBase
    {
        [BsonGuidRepresentation(GuidRepresentation.Standard)] // TODO: Mongo için geçici çözüm. Map sınıfı oluşturulması gerekir.
        public virtual Guid UserId { get; set; }

        [BsonGuidRepresentation(GuidRepresentation.Standard)] // TODO: Mongo için geçici çözüm. Map sınıfı oluşturulması gerekir.
        public virtual Guid RoleId { get; set; }

        public virtual int Type { get; set; }
    }
}

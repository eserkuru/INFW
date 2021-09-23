using INFW.Core.Entities;
using MongoDB.Bson;
using System;

namespace INFW.Authorization.Entities.DTOs
{
    public class UserRoleDto : IDto
    {
        public virtual Guid UserId { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string UserName { get; set; }
        public virtual string EmailAddress { get; set; }
        public virtual Guid RoleId { get; set; }
        public virtual string RoleName { get; set; }
    }
}

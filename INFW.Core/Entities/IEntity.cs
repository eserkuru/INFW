using MongoDB.Bson;
using System;

namespace INFW.Core.Entities
{
    public interface IEntity
    {
        /// <summary>
        /// Gets or sets the entity identifier
        /// </summary>
        Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the entity created time
        /// </summary>
        string Created { get; set; }
        
        /// <summary>
        /// Gets or sets the entity created by
        /// </summary>
        string CreatedBy { get; set; }
        
        /// <summary>
        /// Gets or sets the entity modified time
        /// </summary>
        string Modified { get; set; }
        
        /// <summary>
        /// Gets or sets the entity modified by
        /// </summary>
        string ModifiedBy { get; set; }
        
        /// <summary>
        /// Gets or sets the entity is deleted
        /// </summary>
        int Status { get; set; }
    }
}

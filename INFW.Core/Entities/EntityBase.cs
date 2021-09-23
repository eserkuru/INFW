using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Globalization;

namespace INFW.Core.Entities
{
    /// <summary>
    /// Base class for entities
    /// </summary>
    public abstract class EntityBase : IEntity
    {

        private string _created;
        private string _createdBy;
        private string _modified;
        private string _modifiedBy;

        #region Properties

        /// <summary>
        /// Gets or sets the entity identifier
        /// </summary>
       [BsonGuidRepresentation(GuidRepresentation.Standard)] // TODO: Mongo için geçici çözüm. Map sınıfı oluşturulması gerekir.
        public virtual Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the entity created time
        /// </summary>
        public virtual string Created
        {
            get
            {
                if (string.IsNullOrEmpty(_created))
                {
                    _created = DateTime.Now.ToUniversalTime().ToString("yyyy-MM-dd'T'HH:mm:ss.fffK", CultureInfo.InvariantCulture);
                }
                return _created;
            }
            set => _created = value;

        }

        /// <summary>
        /// Gets or sets the entity created by
        /// </summary>
        public virtual string CreatedBy
        {
            get => _createdBy ?? (_createdBy = "Default User"); // TODO: Session'daki kullanıcı eklenmeli
            set => _createdBy = value;
        }

        /// <summary>
        /// Gets or sets the entity modified time
        /// </summary>
        public virtual string Modified
        {
            get
            {
                _modified = DateTime.Now.ToUniversalTime().ToString("yyyy-MM-dd'T'HH:mm:ss.fffK", CultureInfo.InvariantCulture);
                return _modified;
            }
            set => _modified = value;
        }

        /// <summary>
        /// Gets or sets the entity modified by
        /// </summary>
        public virtual string ModifiedBy
        {
            get => _modifiedBy ?? (_modifiedBy = "Default User"); // TODO: Session'daki kullanıcı eklenmeli
            set => _modifiedBy = value;
        }

        /// <summary>
        /// Gets or sets record status.
        /// </summary>
        public virtual int Status { get; set; }

        #endregion
    }
}

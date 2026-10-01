using System;
using System.Collections.Generic;
using System.Text;

namespace Gishe.presentation.Domain.Base
{
    public abstract class BaseEntity<TKey> : IBaseEntity<TKey>
    {
        public TKey Id { get; protected set; }
        public DateTime CreatedAt { get; private set; }

        public DateTime? UpdatedAt { get; protected set; }
        protected void SetUpdatedAt()
        {
            UpdatedAt = DateTime.UtcNow;
        }
        protected BaseEntity(TKey id)
        {
            Id = id;
            CreatedAt = DateTime.UtcNow;
        }
        protected BaseEntity()
        {
            InitiateId();
            CreatedAt = DateTime.UtcNow;

        }
        protected abstract void InitiateId();
    }
}

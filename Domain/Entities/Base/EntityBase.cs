using System;

namespace Domain.Entities.Base
{
    public abstract class EntityBase
    {
        public bool IsDeleted { get; set; }
        public Guid Id { get; set; }
    }
}
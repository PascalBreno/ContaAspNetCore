using System;

namespace Domain.Entities
{
    public class EntityBase
    {
        public bool IsDeleted { get; set; }
        public Guid Id { get; set; }
    }
}
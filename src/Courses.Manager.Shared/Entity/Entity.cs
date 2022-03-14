
using System;

namespace Courses.Manager.Shared.Entity
{
    public class Entity
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }

}
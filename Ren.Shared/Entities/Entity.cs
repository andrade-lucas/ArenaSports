using System;
using FluentValidator;

namespace Ren.Shared.Entities
{
    public class Entity : Notifiable
    {
        public Guid Id { get; private set; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public Entity(Guid id)
        {
            Id = id;
        }
    }
}
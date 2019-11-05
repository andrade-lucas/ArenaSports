using System;
using System.Collections.Generic;
using System.Linq;
using Ren.Domain.Enums;
using Ren.Shared.Entities;

namespace Ren.Domain.Entities
{
    public class Project : Entity
    {
        private readonly IList<User> _members;

        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public User Owner { get; private set; }
        public IEnumerable<User> Members => _members.ToArray();
        public EProjectStatus Status { get; private set; }

        public Project(string title, string description, DateTime updatedAt, User owner, EProjectStatus status)
        {
            Title = title;
            Description = description;
            UpdatedAt = updatedAt;
            Owner = owner;
            _members = new List<User>();
            Status = status;
        }

        public Project(string title, string description, DateTime createdAt, DateTime updatedAt, User owner, EProjectStatus status)
        {
            Title = title;
            Description = description;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            Owner = owner;
            _members = new List<User>();
            Status = EProjectStatus.Created;
        }

        public void AddMember(User user)
        {
            if (user.Status == EUserStatus.Active)
                _members.Add(user);
        }

        public void RemoveMember(User user)
        {
            _members.Remove(user);
        }

        public void ChangeStatus(EProjectStatus status)
        {
            this.Status = status;
        }

        public override string ToString() => Title;
    }
}
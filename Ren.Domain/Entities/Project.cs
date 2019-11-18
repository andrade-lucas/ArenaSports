using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidator.Validation;
using Ren.Domain.Enums;
using Ren.Domain.Util;
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

            Validate();
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

            Validate();
        }

        public void AddMember(User user)
        {
            if (user.Status == EUserStatus.Active)
                _members.Add(user);
            else
                AddNotification("Member", MessagesUtil.UserInactive);
        }

        public void RemoveMember(User user)
        {
            _members.Remove(user);
        }

        public void ChangeStatus(EProjectStatus status)
        {
            if (status != EProjectStatus.Finished)
                this.Status = status;
            else
                AddNotification("Status", "O projeto já foi dado como finalizado e não permite mudanças");
        }

        private void Validate()
        {
            AddNotifications(new ValidationContract()
                .Requires()
                .IsNotNull(Owner, "Owner", MessagesUtil.InvalidProperty.Replace("{0}", "Responsável"))
                .HasMinLen(Title, 2, "Title", MessagesUtil.StringMinLength.Replace("{0}", "Título").Replace("{1}", "2"))
            );
        }

        public override string ToString() => Title;
    }
}
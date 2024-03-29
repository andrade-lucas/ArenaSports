using System;
using Ren.Domain.Enums;
using Ren.Domain.ValueObjects;
using Ren.Shared.Entities;

namespace Ren.Domain.Entities
{
    public class User : Entity
    {
        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public string Phone { get; private set; }
        public EUserStatus Status { get; private set; }
        public Email Email { get; private set; }
        public Password Password { get; private set; }
        public string Image { get; private set; }

        public User(Guid id, Name name, EUserStatus status) : base(id)
        {
            Name = name;
            Status = status;

            AddNotifications(Name.Notifications);
        }

        public User(Name name, Document document, string phone, Email email, Password password, string image)
        {
            Name = name;
            Document = document;
            Phone = phone;
            Status = EUserStatus.Active;
            Email = email;
            Password = password;
            Image = image;

            AddNotifications(Name.Notifications);
        }

        public void ChangeStatus(EUserStatus status)
        {
            Status = status;
        }

        public override string ToString() => Name.ToString();
    }
}
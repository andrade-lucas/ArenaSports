using System;
using FluentValidator.Validation;
using Ren.Domain.Enums;
using Ren.Domain.Util;
using Ren.Shared.Entities;

namespace Ren.Domain.Entities
{
    public class Heritage : Entity
    {
        public string Description { get; private set; }
        public DateTime PurchaseDate { get; private set; }
        public EHeritageStatus Status { get; private set; }
        public string BarCode { get; private set; }

        public Heritage(string description, DateTime purchaseDate, EHeritageStatus status, string barCode)
        {
            Description = description;
            PurchaseDate = purchaseDate;
            Status = status;
            BarCode = barCode;

            Validate();
        }

        public Heritage(Guid id, string description, DateTime purchaseDate, EHeritageStatus status, string barCode)
           : base(id)
        {
            Description = description;
            PurchaseDate = purchaseDate;
            Status = status;
            BarCode = barCode;

            Validate();
        }

        private void Validate()
        {
            AddNotifications(new ValidationContract()
                .Requires()
                .IsNotNull(Description, "Description", MessagesUtil.InvalidProperty.Replace("{0}", "Descrição"))
                .HasMinLen(Description, 2, "Description", MessagesUtil.StringMinLength)
            );
        }
    }
}
using System;
using Ren.Domain.Enums;
using Ren.Shared.Entities;

namespace Ren.Domain.Entities
{
    public class Heritage : Entity
    {
        public string Description { get; private set; }
        public DateTime PurchaseDate { get; private set; }
        public EHeritageStatus Status { get; private set; }
        public string CodeBar { get; private set; }
    }
}
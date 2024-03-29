using System;
using Ren.Domain.Enums;
using Ren.Shared.Commands;

namespace Ren.Domain.Commands.Inputs.Heritages
{
    public class EditHeritageCommand : ICommand
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime PurchaseDate { get; set; }
        public EHeritageStatus Status { get; set; }
        public string BarCode { get; set; }
    }
}
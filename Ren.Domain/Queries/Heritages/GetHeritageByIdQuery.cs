using System;
using Ren.Domain.Enums;

namespace Ren.Domain.Queries.Heritages
{
    public class GetHeritageByIdQuery
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime PurchaseDate { get; set; }
        public EHeritageStatus Status { get; set; }
        public string CodeBar { get; set; }
    }
}
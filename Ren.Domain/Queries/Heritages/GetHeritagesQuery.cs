using System;
using Ren.Domain.Enums;

namespace Ren.Domain.Queries.Heritages
{
    public class GetHeritagesQuery
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public EHeritageStatus Status { get; set; }
    }
}
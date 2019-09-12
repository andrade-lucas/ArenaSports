using System;
using Ren.Domain.Enums;

namespace Ren.Domain.Queries.Projects
{
    public class GetProjectByIdQuery
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid OwnerId { get; set; }
        public string OwnerName { get; set; }
        public EProjectStatus Status { get; set; }
    }
}
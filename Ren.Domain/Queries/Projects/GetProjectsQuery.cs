using System;
using Ren.Domain.Enums;

namespace Ren.Domain.Queries.Projects
{
    public class GetProjectsQuery
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Owner { get; set; }
        public EProjectStatus Status { get; set; }
    }
}
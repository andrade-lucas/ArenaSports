using System;
using Ren.Domain.Enums;

namespace Ren.Domain.Queries.Projects
{
    public class GetOwnerQuery
    {
        public Guid OwnerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public EUserStatus Status { get; set; }
    }
}
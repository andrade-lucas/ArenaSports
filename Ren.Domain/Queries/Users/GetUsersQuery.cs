using System;
using Ren.Domain.Enums;

namespace Ren.Domain.Queries.Users
{
    public class GetUsersQuery
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public EUserStatus Status { get; set; }
    }
}
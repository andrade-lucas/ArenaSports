using System;
using Ren.Domain.Enums;

namespace Ren.Domain.Queries.Users
{
    public class GetUserByIdQuery
    {
        public Guid ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public EUserStatus Status { get; set; }
        public string Image { get; set; }
    }
}
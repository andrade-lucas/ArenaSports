using System;

namespace Ren.Domain.Queries.Users
{
    public class AuthQuery
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
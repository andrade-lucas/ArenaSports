using System;
using System.Collections.Generic;
using Ren.Domain.Commands.Inputs.Users;
using Ren.Domain.Entities;
using Ren.Domain.Queries.Users;
using Ren.Domain.Repositories;

namespace Ren.Tests.Mocks.Repositories
{
    public class UserRepository : IUserRepository
    {
        public void Create(User user)
        {
            
        }

        public void Delete(Guid id)
        {
            
        }

        public void Edit(EditUserCommand command)
        {
            
        }

        public IEnumerable<GetUsersQuery> Get()
        {
            return null;
        }

        public GetUserByIdQuery GetById(Guid id)
        {
            return null;
        }

        public AuthQuery Login(AuthCommand command)
        {
            return null;
        }
    }
}
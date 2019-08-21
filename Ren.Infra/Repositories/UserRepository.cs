using System;
using System.Collections.Generic;
using Ren.Domain.Commands.Inputs.Users;
using Ren.Domain.Entities;
using Ren.Domain.Queries.Users;
using Ren.Domain.Repositories;
using Ren.Infra.Context;

namespace Ren.Infra.Repositories
{
    public class userRepository : IUserRepository
    {
        private readonly IDB _db;

        public userRepository(IDB db)
        {
            _db = db;
        }

        public void Create(User user)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Edit(EditUserCommand command)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GetUsersQuery> Get()
        {
            throw new NotImplementedException();
        }

        public GetUserByIdQuery GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public AuthQuery Login(AuthCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
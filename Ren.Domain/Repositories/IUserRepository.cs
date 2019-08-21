using System;
using System.Collections.Generic;
using Ren.Domain.Commands.Inputs.Users;
using Ren.Domain.Entities;
using Ren.Domain.Queries.Users;

namespace Ren.Domain.Repositories
{
    public interface IUserRepository
    {
        void Create(User user);
        void Edit(EditUserCommand command);
        GetUserByIdQuery GetById(Guid id);
        IEnumerable<GetUsersQuery> Get();
        AuthQuery Login(AuthCommand command);
        void Delete(Guid id);
    }
}
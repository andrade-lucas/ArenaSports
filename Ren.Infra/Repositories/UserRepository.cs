using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
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
            _db.Connection().Execute(
                "spCreateUser",
                new 
                {
                    id = user.Id,
                    firstName = user.Name.FirstName,
                    lastName = user.Name.LastName,
                    document = user.Document.Number,
                    phone = user.Phone,
                    status = user.Status,
                    email = user.Email.Address,
                    password = user.Password.Value,
                    image = user.Image
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public void Delete(Guid id)
        {
            _db.Connection().Execute(
                "spDeleteUser",
                new
                {
                    id = id
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public void Edit(EditUserCommand command)
        {
            _db.Connection().Execute(
                "spEditUser",
                new
                {
                    id = command.Id,
                    firstName = command.FirstName,
                    lastName = command.LastName,
                    phone = command.Phone,
                    email = command.Email,
                    password = command.Password,
                    image = command.Image
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public IEnumerable<GetUsersQuery> Get()
        {
            return _db.Connection().Query<GetUsersQuery>(
                "spGetUsers",
                null,
                commandType: CommandType.StoredProcedure
            ).ToList();
        }

        public GetUserByIdQuery GetById(Guid id)
        {
            return _db.Connection().Query<GetUserByIdQuery>(
                "spGetUserById",
                new
                {
                    id = id
                },
                commandType: CommandType.StoredProcedure
            ).FirstOrDefault();
        }

        public AuthQuery Login(AuthCommand command)
        {
            return _db.Connection().Query<AuthQuery>(
                "AuthQuery",
                new
                {
                    email = command.Email,
                    password = command.Password
                },
                commandType: CommandType.StoredProcedure
            ).FirstOrDefault();
        }
    }
}
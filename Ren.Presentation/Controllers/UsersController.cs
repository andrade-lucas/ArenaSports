using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Ren.Domain.Commands.Inputs.Users;
using Ren.Domain.Handlers;
using Ren.Domain.Queries.Users;
using Ren.Domain.Repositories;
using Ren.Shared.Commands;
using Microsoft.AspNetCore.Authorization;

namespace Ren.Presentation.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly IUserRepository _repository;
        private readonly UserHandler _handler;

        public UsersController(IUserRepository repository, UserHandler handler)
        {
            _repository = repository;
            _handler = new UserHandler(_repository);
        }

        [Route("v1/users")]
        public IEnumerable<GetUsersQuery> Get()
        {
            return _repository.Get();
        }

        [Route("v1/users/{id}")]
        public GetUserByIdQuery GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        [Route("v1/users")]
        public ICommandResult Post([FromBody]CreateUserCommand command)
        {
            return _handler.Handle(command);
        }

        [Route("v1/users")]
        public ICommandResult Put([FromBody]EditUserCommand command)
        {
            return _handler.Handle(command);
        }

        [Route("v1/users/{id}")]
        public ICommandResult Delete(DeleteUserCommand command)
        {
            return _handler.Handle(command);
        }
    }
}
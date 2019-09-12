using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ren.Domain.Commands.Inputs.Projects;
using Ren.Domain.Handlers;
using Ren.Domain.Queries.Projects;
using Ren.Domain.Repositories;
using Ren.Shared.Commands;

namespace Ren.Presentation.Controllers
{
    [Authorize("Bearer")]
    public class projectsController : Controller
    {
        private readonly IProjectRepository _repository;
        private readonly ProjectHandler _handler;

        public projectsController(IProjectRepository repository)
        {
            _repository = repository;
            _handler = new ProjectHandler(_repository);
        }

        [HttpGet]
        [Route("v1/projects")]
        public IEnumerable<GetProjectsQuery> Get()
        {
            return _repository.Get();
        }

        [HttpGet]
        [Route("v1/projects/{id}")]
        public GetProjectByIdQuery GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        [HttpPost]
        [Route("v1/projects")]
        public ICommandResult Post([FromBody]CreateProjectCommand command)
        {
            return _handler.Handle(command);
        }

        [HttpPut]
        [Route("v1/projects")]
        public ICommandResult Put([FromBody]EditProjectCommand command)
        {
            return _handler.Handle(command);
        }

        [HttpDelete]
        [Route("v1/projects/{id}")]
        public ICommandResult Delete(DeleteProjectCommand command)
        {
            return _handler.Handle(command);
        }
    }
}
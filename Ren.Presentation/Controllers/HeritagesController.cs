using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Ren.Domain.Commands.Inputs.Heritages;
using Ren.Domain.Handlers;
using Ren.Domain.Queries.Heritages;
using Ren.Domain.Repositories;
using Ren.Shared.Commands;

namespace Ren.Presentation.Controllers
{
    public class HeritagesController : Controller
    {
        private readonly IHeritageRepository _repository;
        private readonly HeritageHandler _handler;

        public HeritagesController(IHeritageRepository repository)
        {
            _repository = repository;
            _handler = new HeritageHandler(_repository);
        }

        [HttpGet]
        [Route("v1/heritages")]
        public IEnumerable<GetHeritagesQuery> Get()
        {
            return _repository.Get();
        }

        [HttpGet]
        [Route("v1/heritages/{id}")]
        public GetHeritageByIdQuery GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        [HttpPost]
        [Route("v1/heritages")]
        public ICommandResult Post([FromBody]CreateHeritageCommand command)
        {
            return _handler.Handle(command);
        }

        [HttpPut]
        [Route("v1/heritages")]
        public ICommandResult Put(EditHeritageCommand command)
        {
            return _handler.Handle(command);
        }

        [HttpDelete]
        [Route("v1/heritages/{id}")]
        public ICommandResult Delete(DeleteHeritageCommand command)
        {
            return _handler.Handle(command);
        }
    }
}
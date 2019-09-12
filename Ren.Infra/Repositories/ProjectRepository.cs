using System;
using System.Collections.Generic;
using Ren.Domain.Commands.Inputs.Projects;
using Ren.Domain.Entities;
using Ren.Domain.Queries.Projects;
using Ren.Domain.Repositories;

namespace Ren.Infra.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        public void Create(Project project)
        {
            throw new NotImplementedException();
        }

        public void Delete(DeleteProjectCommand command)
        {
            throw new NotImplementedException();
        }

        public void Edit(EditProjectCommand command)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GetProjectsQuery> Get()
        {
            throw new NotImplementedException();
        }

        public GetProjectByIdQuery GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public GetOwnerQuery GetOwner(Guid ownerId)
        {
            throw new NotImplementedException();
        }
    }
}
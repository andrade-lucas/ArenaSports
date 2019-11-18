using System;
using System.Collections.Generic;
using Ren.Domain.Commands.Inputs.Projects;
using Ren.Domain.Entities;
using Ren.Domain.Queries.Projects;
using Ren.Domain.Repositories;

namespace Ren.Tests.Mocks.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        public void Create(Project project)
        {
        }

        public void Delete(DeleteProjectCommand command)
        {
        }

        public void Edit(EditProjectCommand command)
        {
        }

        public IEnumerable<GetProjectsQuery> Get()
        {
            return null;
        }

        public GetProjectByIdQuery GetById(Guid id)
        {
            return null;
        }

        public GetOwnerQuery GetOwner(Guid ownerId)
        {
            return null;
        }
    }
}
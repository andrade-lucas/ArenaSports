using System;
using System.Collections.Generic;
using Ren.Domain.Commands.Inputs.Projects;
using Ren.Domain.Entities;
using Ren.Domain.Queries.Projects;

namespace Ren.Domain.Repositories
{
    public interface IProjectRepository
    {
        void Create(Project project);
        void Edit(EditProjectCommand command);
        GetOwnerQuery GetOwner(Guid ownerId);
        IEnumerable<GetProjectsQuery> Get();
        GetProjectByIdQuery GetById(Guid id);
        void Delete(DeleteProjectCommand command);
    }
}
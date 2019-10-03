using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Ren.Domain.Commands.Inputs.Projects;
using Ren.Domain.Entities;
using Ren.Domain.Queries.Projects;
using Ren.Domain.Repositories;
using Ren.Infra.Context;

namespace Ren.Infra.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly IDB _db;

        public ProjectRepository(IDB db)
        {
            _db = db;
        }

        public void Create(Project project)
        {
            _db.Connection().Execute(
                "spCreateProject",
                new
                {
                    id = project.Id,
                    title = project.Title,
                    description = project.Description,
                    ownerId = project.Owner.Id
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public void Delete(DeleteProjectCommand command)
        {
            _db.Connection().Execute(
                "spDeleteProject",
                new
                {
                    id = command.Id
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public void Edit(EditProjectCommand command)
        {
            _db.Connection().Execute(
                "spEditProject",
                new
                {
                    id = command.Id,
                    title = command.Title,
                    description = command.Description,
                    ownerId = command.OwnerId,
                    status = command.Status
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public IEnumerable<GetProjectsQuery> Get()
        {
            return _db.Connection().Query<GetProjectsQuery>(
                "spGetProjects",
                null,
                commandType: CommandType.StoredProcedure
            ).ToList();
        }

        public GetProjectByIdQuery GetById(Guid id)
        {
            return _db.Connection().Query<GetProjectByIdQuery>(
                "spGetProjectById",
                new
                {
                    id = id
                },
                commandType: CommandType.StoredProcedure
            ).FirstOrDefault();
        }

        public GetOwnerQuery GetOwner(Guid ownerId)
        {
            return _db.Connection().Query<GetOwnerQuery>(
                "spGetProjectOwner",
                new
                {
                    id = ownerId
                },
                commandType: CommandType.StoredProcedure
            ).FirstOrDefault();
        }
    }
}
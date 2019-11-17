using System;
using System.Collections.Generic;
using Ren.Domain.Commands.Inputs.Heritages;
using Ren.Domain.Entities;
using Ren.Domain.Queries.Heritages;
using Ren.Domain.Repositories;

namespace Ren.Tests.Mocks.Repositories
{
    public class HeritageRepository : IHeritageRepository
    {
        public void Book(Guid id)
        {
        }

        public void Create(Heritage heritage)
        {
        }

        public void Delete(DeleteHeritageCommand command)
        {
        }

        public void Edit(EditHeritageCommand command)
        {
        }

        public IEnumerable<GetHeritagesQuery> Get()
        {
            return null;
        }

        public GetHeritageByIdQuery GetById(Guid id)
        {
            return null;
        }

        public bool IsAvailable(Guid id)
        {
            return true;
        }
    }
}
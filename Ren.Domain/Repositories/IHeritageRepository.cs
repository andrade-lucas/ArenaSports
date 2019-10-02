using System;
using System.Collections.Generic;
using Ren.Domain.Commands.Inputs.Heritages;
using Ren.Domain.Entities;
using Ren.Domain.Queries.Heritages;

namespace Ren.Domain.Repositories
{
    public interface IHeritageRepository
    {
        void Create(Heritage heritage);
        void Edit(EditHeritageCommand command);
        bool IsAvailable(Guid id);
        void Book(Guid id);
        GetHeritageByIdQuery GetById(Guid id);
        IEnumerable<GetHeritagesQuery> Get();
        void Delete(DeleteHeritageCommand command);
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Ren.Domain.Commands.Inputs.Heritages;
using Ren.Domain.Entities;
using Ren.Domain.Queries.Heritages;
using Ren.Domain.Repositories;
using Ren.Infra.Context;

namespace Ren.Infra.Repositories
{
    public class HeritageRepository : IHeritageRepository
    {
        private readonly IDB _db;

        public HeritageRepository(IDB db)
        {
            _db = db;
        }

        public void Book(Guid id)
        {
            _db.Connection().Execute(
                "spBookHeritage",
                new
                {
                    id = id
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public void Create(Heritage heritage)
        {
            _db.Connection().Execute(
                "spCreateHeritage",
                new
                {
                    id = heritage.Id,
                    description = heritage.Description,
                    purchaseDate = heritage.PurchaseDate,
                    status = heritage.Status,
                    barCode = heritage.BarCode
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public void Delete(DeleteHeritageCommand command)
        {
            _db.Connection().Execute(
                "spDeleteHeritage",
                new
                {
                    id = command.Id
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public void Edit(EditHeritageCommand command)
        {
            _db.Connection().Execute(
                "spEditHeritage",
                new
                {
                    id = command.Id,
                    description = command.Description,
                    purchaseDate = command.PurchaseDate,
                    status = command.Status,
                    barCode = command.BarCode
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public IEnumerable<GetHeritagesQuery> Get()
        {
            return _db.Connection().Query<GetHeritagesQuery>(
                "spGetHeritages",
                null,
                commandType: CommandType.StoredProcedure
            ).ToList();
        }

        public GetHeritageByIdQuery GetById(Guid id)
        {
            return _db.Connection().Query(
                "spGetHeritageById",
                new
                {
                    id = id
                },
                commandType: CommandType.StoredProcedure
            ).FirstOrDefault();
        }

        public bool IsAvailable(Guid id)
        {
            return _db.Connection().Query(
                "spIsHeritageAvailable",
                new
                {
                    id = id
                },
                commandType: CommandType.StoredProcedure
            ).FirstOrDefault();
        }
    }
}
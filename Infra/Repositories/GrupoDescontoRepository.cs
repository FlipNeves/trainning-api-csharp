using Domain.Entities;
using Domain.Repositories;
using Infra.Context;
using Infra.Repositories.Generic;

namespace Infra.Repositories
{
    public class GrupoDescontoRepository : GenericRepository<GrupoDesconto>, IGrupoDescontoRepository
    {
        public GrupoDescontoRepository(SessionDbContext context) : base(context)
        {
        }
    }
}

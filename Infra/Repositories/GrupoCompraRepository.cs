using Domain.Entities;
using Domain.Repositories;
using Infra.Context;
using Infra.Repositories.Generic;

namespace Infra.Repositories
{
    public class GrupoCompraRepository : GenericRepository<GrupoCompra>, IGrupoCompraRepository
    {
        public GrupoCompraRepository(SessionDbContext context) : base(context)
        {
        }
    }
}

using Domain.Entities;
using Domain.Repositories;
using Infra.Context;
using Infra.Repositories.Generic;

namespace Infra.Repositories
{
    public class GrupoComissaoRepository : GenericRepository<GrupoComissao>, IGrupoComissaoRepository
    {
        public GrupoComissaoRepository(SessionDbContext context) : base(context)
        {
        }
    }
}

using Domain.Entities;

namespace Infra.Context
{
    public static class DbSeeder
    {
        public static void Seed(SessionDbContext context)
        {
            if (context.GruposComissao.Any()) return;

            context.GruposComissao.AddRange(
                new GrupoComissao("Comissão Padrão"),
                new GrupoComissao("Comissão Especial"));

            context.GruposCompra.AddRange(
                new GrupoCompra("Compra Direta"),
                new GrupoCompra("Compra Programada"));

            context.GruposDesconto.AddRange(
                new GrupoDesconto("Desconto Promocional"),
                new GrupoDesconto("Desconto Progressivo"));

            context.SaveChanges();
        }
    }
}

using Domain.Entities;

namespace Infra.Context
{
    public static class DbSeeder
    {
        public static void Seed(SessionDbContext context)
        {
            if (context.GruposComissao.Any()) return;

            var comissaoPadrao = new GrupoComissao("Comissão Padrão");
            comissaoPadrao.DefinirPercentual(5m);
            var comissaoEspecial = new GrupoComissao("Comissão Especial");
            comissaoEspecial.DefinirPercentual(10m);
            context.GruposComissao.AddRange(comissaoPadrao, comissaoEspecial);

            context.GruposCompra.AddRange(
                new GrupoCompra("Compra Direta"),
                new GrupoCompra("Compra Programada"));

            var descontoPromocional = new GrupoDesconto("Desconto Promocional");
            descontoPromocional.DefinirPercentual(8m);
            var descontoProgressivo = new GrupoDesconto("Desconto Progressivo");
            descontoProgressivo.DefinirPercentual(15m);
            context.GruposDesconto.AddRange(descontoPromocional, descontoProgressivo);

            context.SaveChanges();
        }
    }
}

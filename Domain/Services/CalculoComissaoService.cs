using Domain.Entities;
using Domain.Exceptions;

namespace Domain.Services
{
    public class CalculoComissaoService : ICalculoComissaoService
    {
        public (decimal ValorDesconto, decimal BaseComissionavel, decimal ValorComissao) Calcular(
            GrupoComissao grupoComissao, GrupoDesconto grupoDesconto, decimal valorVenda)
        {
            if (valorVenda <= 0)
                throw new DomainException("O valor da venda deve ser maior que zero.");

            if (grupoDesconto.Percentual > grupoComissao.Percentual * 2)
                throw new DomainException(
                    $"O desconto de {grupoDesconto.Percentual}% é incompatível com a comissão de {grupoComissao.Percentual}% deste grupo.");

            var valorDesconto = valorVenda * (grupoDesconto.Percentual / 100m);
            var baseComissionavel = valorVenda - valorDesconto;
            var valorComissao = baseComissionavel * (grupoComissao.Percentual / 100m);

            return (valorDesconto, baseComissionavel, valorComissao);
        }
    }
}

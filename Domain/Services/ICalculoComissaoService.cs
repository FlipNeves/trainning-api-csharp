using Domain.Entities;

namespace Domain.Services
{
    public interface ICalculoComissaoService
    {
        (decimal ValorDesconto, decimal BaseComissionavel, decimal ValorComissao) Calcular(
            GrupoComissao grupoComissao, GrupoDesconto grupoDesconto, decimal valorVenda);
    }
}

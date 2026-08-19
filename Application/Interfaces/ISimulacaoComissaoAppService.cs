using Application.DTOs;

namespace Application.Interfaces
{
    public interface ISimulacaoComissaoAppService
    {
        Task<RespostaDTO<SimulacaoComissaoDTO>> SimularAsync(int codigoGrupoComissao, int codigoGrupoDesconto, decimal valorVenda);
    }
}

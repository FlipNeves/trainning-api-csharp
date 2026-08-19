using Application.DTOs;
using Application.Interfaces;
using Domain.Repositories;
using Domain.Services;

namespace Application.Services
{
    public class SimulacaoComissaoAppService : ISimulacaoComissaoAppService
    {
        private readonly IGrupoComissaoRepository _grupoComissaoRepository;
        private readonly IGrupoDescontoRepository _grupoDescontoRepository;
        private readonly ICalculoComissaoService _calculoComissaoService;

        public SimulacaoComissaoAppService(
            IGrupoComissaoRepository grupoComissaoRepository,
            IGrupoDescontoRepository grupoDescontoRepository,
            ICalculoComissaoService calculoComissaoService)
        {
            _grupoComissaoRepository = grupoComissaoRepository;
            _grupoDescontoRepository = grupoDescontoRepository;
            _calculoComissaoService = calculoComissaoService;
        }

        public async Task<RespostaDTO<SimulacaoComissaoDTO>> SimularAsync(int codigoGrupoComissao, int codigoGrupoDesconto, decimal valorVenda)
        {
            var grupoComissao = await _grupoComissaoRepository.GetAsync(codigoGrupoComissao);
            if (grupoComissao == null)
                return RespostaDTO.NotFound<SimulacaoComissaoDTO>("Grupo de comissão não encontrado.");

            var grupoDesconto = await _grupoDescontoRepository.GetAsync(codigoGrupoDesconto);
            if (grupoDesconto == null)
                return RespostaDTO.NotFound<SimulacaoComissaoDTO>("Grupo de desconto não encontrado.");

            var (valorDesconto, baseComissionavel, valorComissao) =
                _calculoComissaoService.Calcular(grupoComissao, grupoDesconto, valorVenda);

            return RespostaDTO.Sucesso(new SimulacaoComissaoDTO
            {
                ValorVenda = valorVenda,
                ValorDesconto = valorDesconto,
                BaseComissionavel = baseComissionavel,
                ValorComissao = valorComissao
            });
        }
    }
}

using Application.DTOs;
using Application.Interfaces;
using Domain.Repositories;

namespace Application.Services
{
    public class ArvoreMercadologicaAppService : IArvoreMercadologicaAppService
    {
        private readonly IGrupoComissaoRepository _grupoComissaoRepository;
        private readonly IGrupoCompraRepository _grupoCompraRepository;
        private readonly IGrupoDescontoRepository _grupoDescontoRepository;

        public ArvoreMercadologicaAppService(
            IGrupoComissaoRepository grupoComissaoRepository,
            IGrupoCompraRepository grupoCompraRepository,
            IGrupoDescontoRepository grupoDescontoRepository)
        {
            _grupoComissaoRepository = grupoComissaoRepository;
            _grupoCompraRepository = grupoCompraRepository;
            _grupoDescontoRepository = grupoDescontoRepository;
        }

        public async Task<RespostaDTO<ArvoreMercadologicaDTO>> ListarTodosAsync()
            => RespostaDTO.Sucesso(new ArvoreMercadologicaDTO
            {
                GruposComissao = [.. (await _grupoComissaoRepository.ListarAsync()).Select(x => new GrupoComissaoDTO { Codigo = x.Codigo, Descricao = x.Descricao })],
                GruposCompra = [.. (await _grupoCompraRepository.ListarAsync()).Select(x => new GrupoCompraDTO { Codigo = x.Codigo, Descricao = x.Descricao })],
                GruposDesconto = [.. (await _grupoDescontoRepository.ListarAsync()).Select(x => new GrupoDescontoDTO { Codigo = x.Codigo, Descricao = x.Descricao })]
            });

        public Task<RespostaDTO<ArvoreMercadologicaDTO>> PesquisarAsync(string descricao)
        {
            if (string.IsNullOrWhiteSpace(descricao))
                return Task.FromResult(RespostaDTO.BadRequest<ArvoreMercadologicaDTO>("Descrição é obrigatória."));

            return Task.FromResult(RespostaDTO.Sucesso(new ArvoreMercadologicaDTO
            {
                GruposComissao = [.. _grupoComissaoRepository.Pesquisar(x => x.Descricao.Contains(descricao)).Select(x => new GrupoComissaoDTO { Codigo = x.Codigo, Descricao = x.Descricao })],
                GruposCompra = [.. _grupoCompraRepository.Pesquisar(x => x.Descricao.Contains(descricao)).Select(x => new GrupoCompraDTO { Codigo = x.Codigo, Descricao = x.Descricao })],
                GruposDesconto = [.. _grupoDescontoRepository.Pesquisar(x => x.Descricao.Contains(descricao)).Select(x => new GrupoDescontoDTO { Codigo = x.Codigo, Descricao = x.Descricao })]
            }));
        }
    }
}

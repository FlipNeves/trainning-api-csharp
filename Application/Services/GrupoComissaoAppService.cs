using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Services
{
    public class GrupoComissaoAppService : IGrupoComissaoAppService
    {
        private readonly IGrupoComissaoRepository _repository;

        public GrupoComissaoAppService(IGrupoComissaoRepository grupoComissaoRepository)
        {
            _repository = grupoComissaoRepository;
        }

        private static GrupoComissaoDTO MapToDTO(GrupoComissao x)
            => new() { Codigo = x.Codigo, Descricao = x.Descricao };

        public async Task<RespostaDTO<GrupoComissaoDTO>> GetByIdAsync(int codigo)
        {
            var grupo = await _repository.GetAsync(codigo);
            return grupo == null
                ? RespostaDTO.NotFound<GrupoComissaoDTO>()
                : RespostaDTO.Sucesso(MapToDTO(grupo));
        }

        public async Task<RespostaDTO<GrupoComissaoDTO>> NovoRegistroAsync(string descricao)
        {
            var novoGrupo = await _repository.AddAsync(new GrupoComissao(descricao));
            await _repository.SaveChangesAsync();
            return RespostaDTO.Created(MapToDTO(novoGrupo));
        }

        public async Task<RespostaDTO<GrupoComissaoDTO>> AlterarRegistroAsync(int codigo, string descricao)
        {
            var grupo = await _repository.GetAsync(codigo);
            if (grupo == null)
                return RespostaDTO.NotFound<GrupoComissaoDTO>();

            grupo.AlterarDescricao(descricao);
            _repository.Update(grupo);
            await _repository.SaveChangesAsync();
            return RespostaDTO.Sucesso(MapToDTO(grupo));
        }

        public async Task<RespostaDTO<List<GrupoComissaoDTO>>> ListarAsync()
            => RespostaDTO.Sucesso((await _repository.ListarAsync()).Select(MapToDTO).ToList());

        public async Task<RespostaDTO<bool>> DeletarRegistroAsync(int codigo)
        {
            if (!await _repository.DeleteAsync(codigo))
                return RespostaDTO.NotFound<bool>();

            await _repository.SaveChangesAsync();
            return RespostaDTO.Sucesso(true);
        }
    }
}

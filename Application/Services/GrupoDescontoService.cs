using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Services
{
    public class GrupoDescontoService : IGrupoDescontoService
    {
        private IGrupoDescontoRepository _repository;

        public GrupoDescontoService(IGrupoDescontoRepository grupoDescontoRepository)
        {
            _repository = grupoDescontoRepository;
        }

        private static GrupoDescontoDTO MapToDTO(GrupoDesconto x)
            => new GrupoDescontoDTO { Codigo = x.Codigo, Descricao = x.Descricao };

        public async Task<RespostaDTO<GrupoDescontoDTO>> GetByIdAsync(int codigo)
        {
            var grupo = await _repository.GetAsync(codigo);
            return grupo == null
                ? RespostaDTO.NotFound<GrupoDescontoDTO>()
                : RespostaDTO.Sucesso(MapToDTO(grupo));
        }

        public async Task<RespostaDTO<GrupoDescontoDTO>> NovoRegistroAsync(string descricao)
        {
            if (string.IsNullOrWhiteSpace(descricao))
                return RespostaDTO.BadRequest<GrupoDescontoDTO>("Descrição é obrigatória.");

            var novoGrupo = await _repository.AddAsync(new GrupoDesconto(descricao));
            await _repository.SaveChangesAsync();
            return RespostaDTO.Created(MapToDTO(novoGrupo));
        }

        public async Task<RespostaDTO<GrupoDescontoDTO>> AlterarRegistroAsync(int codigo, string descricao)
        {
            if (string.IsNullOrWhiteSpace(descricao))
                return RespostaDTO.BadRequest<GrupoDescontoDTO>("Descrição é obrigatória.");

            var grupo = await _repository.GetAsync(codigo);
            if (grupo == null)
                return RespostaDTO.NotFound<GrupoDescontoDTO>();

            grupo.Descricao = descricao;
            _repository.Update(grupo);
            await _repository.SaveChangesAsync();
            return RespostaDTO.Sucesso(MapToDTO(grupo));
        }

        public async Task<RespostaDTO<List<GrupoDescontoDTO>>> ListarAsync()
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

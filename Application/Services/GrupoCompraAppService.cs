using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Services
{
    public class GrupoCompraAppService : IGrupoCompraAppService
    {
        private readonly IGrupoCompraRepository _repository;

        public GrupoCompraAppService(IGrupoCompraRepository grupoCompraRepository)
        {
            _repository = grupoCompraRepository;
        }

        private static GrupoCompraDTO MapToDTO(GrupoCompra x)
            => new() { Codigo = x.Codigo, Descricao = x.Descricao };

        public async Task<RespostaDTO<GrupoCompraDTO>> GetByIdAsync(int codigo)
        {
            var grupo = await _repository.GetAsync(codigo);
            return grupo == null
                ? RespostaDTO.NotFound<GrupoCompraDTO>()
                : RespostaDTO.Sucesso(MapToDTO(grupo));
        }

        public async Task<RespostaDTO<GrupoCompraDTO>> NovoRegistroAsync(string descricao)
        {
            var novoGrupo = await _repository.AddAsync(new GrupoCompra(descricao));
            await _repository.SaveChangesAsync();
            return RespostaDTO.Created(MapToDTO(novoGrupo));
        }

        public async Task<RespostaDTO<GrupoCompraDTO>> AlterarRegistroAsync(int codigo, string descricao)
        {
            var grupo = await _repository.GetAsync(codigo);
            if (grupo == null)
                return RespostaDTO.NotFound<GrupoCompraDTO>();

            grupo.AlterarDescricao(descricao);
            _repository.Update(grupo);
            await _repository.SaveChangesAsync();
            return RespostaDTO.Sucesso(MapToDTO(grupo));
        }

        public async Task<RespostaDTO<List<GrupoCompraDTO>>> ListarAsync()
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

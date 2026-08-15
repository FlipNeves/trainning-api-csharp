using Application.DTOs;

namespace Application.Interfaces
{
    public interface IGrupoDescontoService
    {
        public Task<RespostaDTO<GrupoDescontoDTO>> GetByIdAsync(int codigo);
        public Task<RespostaDTO<GrupoDescontoDTO>> NovoRegistroAsync(string descricao);
        public Task<RespostaDTO<GrupoDescontoDTO>> AlterarRegistroAsync(int codigo, string descricao);
        public Task<RespostaDTO<List<GrupoDescontoDTO>>> ListarAsync();
        public Task<RespostaDTO<bool>> DeletarRegistroAsync(int codigo);
    }
}

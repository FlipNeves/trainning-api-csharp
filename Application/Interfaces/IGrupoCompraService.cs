using Application.DTOs;

namespace Application.Interfaces
{
    public interface IGrupoCompraService
    {
        public Task<RespostaDTO<GrupoCompraDTO>> GetByIdAsync(int codigo);
        public Task<RespostaDTO<GrupoCompraDTO>> NovoRegistroAsync(string descricao);
        public Task<RespostaDTO<GrupoCompraDTO>> AlterarRegistroAsync(int codigo, string descricao);
        public Task<RespostaDTO<List<GrupoCompraDTO>>> ListarAsync();
        public Task<RespostaDTO<bool>> DeletarRegistroAsync(int codigo);
    }
}

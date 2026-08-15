using Application.DTOs;

namespace Application.Interfaces
{
    public interface IGrupoComissaoService
    {
        public Task<RespostaDTO<GrupoComissaoDTO>> GetByIdAsync(int codigo);
        public Task<RespostaDTO<GrupoComissaoDTO>> NovoRegistroAsync(string descricao);
        public Task<RespostaDTO<GrupoComissaoDTO>> AlterarRegistroAsync(int codigo, string descricao);
        public Task<RespostaDTO<List<GrupoComissaoDTO>>> ListarAsync();
        public Task<RespostaDTO<bool>> DeletarRegistroAsync(int codigo);
    }
}

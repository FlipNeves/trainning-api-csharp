using Application.DTOs;

namespace Application.Interfaces
{
    public interface IArvoreMercadologicaAppService
    {
        public Task<RespostaDTO<ArvoreMercadologicaDTO>> ListarTodosAsync();
        public Task<RespostaDTO<ArvoreMercadologicaDTO>> PesquisarAsync(string descricao);
    }
}

using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace TreinamentoDEV.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ProducesResponseType(typeof(RespostaDTO<object>), StatusCodes.Status500InternalServerError)]
    public class SimulacaoController : ControllerBase
    {
        private readonly ISimulacaoComissaoAppService _simulacaoComissaoAppService;

        public SimulacaoController(ISimulacaoComissaoAppService simulacaoComissaoAppService)
        {
            _simulacaoComissaoAppService = simulacaoComissaoAppService;
        }

        private static ObjectResult Resultado<T>(RespostaDTO<T> resposta)
            => new(resposta) { StatusCode = resposta.StatusCode };

        [HttpGet("comissao")]
        [ProducesResponseType(typeof(RespostaDTO<SimulacaoComissaoDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RespostaDTO<SimulacaoComissaoDTO>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(RespostaDTO<SimulacaoComissaoDTO>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SimularComissao(int codigoGrupoComissao, int codigoGrupoDesconto, decimal valorVenda)
            => Resultado(await _simulacaoComissaoAppService.SimularAsync(codigoGrupoComissao, codigoGrupoDesconto, valorVenda));
    }
}

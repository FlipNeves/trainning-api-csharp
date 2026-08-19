using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace TreinamentoDEV.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ProducesResponseType(typeof(RespostaDTO<object>), StatusCodes.Status500InternalServerError)]
    public class ArvoreMercadologicaController : ControllerBase
    {
        private readonly IArvoreMercadologicaAppService _appService;
        private readonly IGrupoComissaoAppService _grupoComissaoAppService;
        private readonly IGrupoCompraAppService _grupoCompraAppService;
        private readonly IGrupoDescontoAppService _grupoDescontoAppService;

        public ArvoreMercadologicaController(
            IArvoreMercadologicaAppService appService,
            IGrupoComissaoAppService grupoComissaoAppService,
            IGrupoCompraAppService grupoCompraAppService,
            IGrupoDescontoAppService grupoDescontoAppService)
        {
            _appService = appService;
            _grupoComissaoAppService = grupoComissaoAppService;
            _grupoCompraAppService = grupoCompraAppService;
            _grupoDescontoAppService = grupoDescontoAppService;
        }

        private static ObjectResult Resultado<T>(RespostaDTO<T> resposta)
            => new(resposta) { StatusCode = resposta.StatusCode };

        [HttpGet]
        [ProducesResponseType(typeof(RespostaDTO<ArvoreMercadologicaDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ListarTodos()
            => Resultado(await _appService.ListarTodosAsync());

        [HttpGet("pesquisar")]
        [ProducesResponseType(typeof(RespostaDTO<ArvoreMercadologicaDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RespostaDTO<ArvoreMercadologicaDTO>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Pesquisar(string descricao)
            => Resultado(await _appService.PesquisarAsync(descricao));

        [HttpGet("grupo-comissao")]
        [ProducesResponseType(typeof(RespostaDTO<List<GrupoComissaoDTO>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ListarGrupoComissao()
            => Resultado(await _grupoComissaoAppService.ListarAsync());

        [HttpGet("grupo-comissao/{codigo}")]
        [ProducesResponseType(typeof(RespostaDTO<GrupoComissaoDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RespostaDTO<GrupoComissaoDTO>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdGrupoComissao(int codigo)
            => Resultado(await _grupoComissaoAppService.GetByIdAsync(codigo));

        [HttpPost("grupo-comissao")]
        [ProducesResponseType(typeof(RespostaDTO<GrupoComissaoDTO>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(RespostaDTO<GrupoComissaoDTO>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> NovoGrupoComissao(string descricao)
            => Resultado(await _grupoComissaoAppService.NovoRegistroAsync(descricao));

        [HttpPut("grupo-comissao/{codigo}")]
        [ProducesResponseType(typeof(RespostaDTO<GrupoComissaoDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RespostaDTO<GrupoComissaoDTO>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(RespostaDTO<GrupoComissaoDTO>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AlterarGrupoComissao(int codigo, string descricao)
            => Resultado(await _grupoComissaoAppService.AlterarRegistroAsync(codigo, descricao));

        [HttpDelete("grupo-comissao/{codigo}")]
        [ProducesResponseType(typeof(RespostaDTO<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RespostaDTO<bool>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletarGrupoComissao(int codigo)
            => Resultado(await _grupoComissaoAppService.DeletarRegistroAsync(codigo));

        [HttpGet("grupo-compra")]
        [ProducesResponseType(typeof(RespostaDTO<List<GrupoCompraDTO>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ListarGrupoCompra()
            => Resultado(await _grupoCompraAppService.ListarAsync());

        [HttpGet("grupo-compra/{codigo}")]
        [ProducesResponseType(typeof(RespostaDTO<GrupoCompraDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RespostaDTO<GrupoCompraDTO>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdGrupoCompra(int codigo)
            => Resultado(await _grupoCompraAppService.GetByIdAsync(codigo));

        [HttpPost("grupo-compra")]
        [ProducesResponseType(typeof(RespostaDTO<GrupoCompraDTO>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(RespostaDTO<GrupoCompraDTO>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> NovoGrupoCompra(string descricao)
            => Resultado(await _grupoCompraAppService.NovoRegistroAsync(descricao));

        [HttpPut("grupo-compra/{codigo}")]
        [ProducesResponseType(typeof(RespostaDTO<GrupoCompraDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RespostaDTO<GrupoCompraDTO>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(RespostaDTO<GrupoCompraDTO>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AlterarGrupoCompra(int codigo, string descricao)
            => Resultado(await _grupoCompraAppService.AlterarRegistroAsync(codigo, descricao));

        [HttpDelete("grupo-compra/{codigo}")]
        [ProducesResponseType(typeof(RespostaDTO<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RespostaDTO<bool>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletarGrupoCompra(int codigo)
            => Resultado(await _grupoCompraAppService.DeletarRegistroAsync(codigo));

        [HttpGet("grupo-desconto")]
        [ProducesResponseType(typeof(RespostaDTO<List<GrupoDescontoDTO>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ListarGrupoDesconto()
            => Resultado(await _grupoDescontoAppService.ListarAsync());

        [HttpGet("grupo-desconto/{codigo}")]
        [ProducesResponseType(typeof(RespostaDTO<GrupoDescontoDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RespostaDTO<GrupoDescontoDTO>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdGrupoDesconto(int codigo)
            => Resultado(await _grupoDescontoAppService.GetByIdAsync(codigo));

        [HttpPost("grupo-desconto")]
        [ProducesResponseType(typeof(RespostaDTO<GrupoDescontoDTO>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(RespostaDTO<GrupoDescontoDTO>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> NovoGrupoDesconto(string descricao)
            => Resultado(await _grupoDescontoAppService.NovoRegistroAsync(descricao));

        [HttpPut("grupo-desconto/{codigo}")]
        [ProducesResponseType(typeof(RespostaDTO<GrupoDescontoDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RespostaDTO<GrupoDescontoDTO>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(RespostaDTO<GrupoDescontoDTO>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AlterarGrupoDesconto(int codigo, string descricao)
            => Resultado(await _grupoDescontoAppService.AlterarRegistroAsync(codigo, descricao));

        [HttpDelete("grupo-desconto/{codigo}")]
        [ProducesResponseType(typeof(RespostaDTO<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RespostaDTO<bool>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletarGrupoDesconto(int codigo)
            => Resultado(await _grupoDescontoAppService.DeletarRegistroAsync(codigo));
    }
}

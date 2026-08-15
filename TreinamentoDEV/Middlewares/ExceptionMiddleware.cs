using Application.DTOs;

namespace TreinamentoDEV.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro não tratado na requisição {Path}", context.Request.Path);

                var resposta = RespostaDTO.Error<object>("Ocorreu um erro interno ao processar a requisição.");
                context.Response.StatusCode = resposta.StatusCode;
                await context.Response.WriteAsJsonAsync(resposta);
            }
        }
    }
}

namespace Application.DTOs
{
    public class RespostaDTO<T>
    {
        public bool Sucesso { get; set; }
        public int StatusCode { get; set; }
        public string Mensagem { get; set; } = string.Empty;
        public T? Value { get; set; }
    }

    public static class RespostaDTO
    {
        public static RespostaDTO<T> Sucesso<T>(T value)
            => new() { Sucesso = true, StatusCode = 200, Value = value };

        public static RespostaDTO<T> Created<T>(T value)
            => new() { Sucesso = true, StatusCode = 201, Value = value };

        public static RespostaDTO<T> NotFound<T>(string mensagem = "Registro não encontrado.")
            => new() { Sucesso = false, StatusCode = 404, Mensagem = mensagem };

        public static RespostaDTO<T> BadRequest<T>(string mensagem)
            => new() { Sucesso = false, StatusCode = 400, Mensagem = mensagem };

        public static RespostaDTO<T> Error<T>(string mensagem)
            => new() { Sucesso = false, StatusCode = 500, Mensagem = mensagem };
    }
}

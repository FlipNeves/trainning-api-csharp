using Domain.Exceptions;

namespace Domain.Entities
{
    public class GrupoCompra
    {
        public GrupoCompra(string descricao)
        {
            AlterarDescricao(descricao);
        }

        public int Codigo { get; private set; }
        public int CdEmpresa { get; private set; } = 1;
        public string Descricao { get; private set; } = string.Empty;

        public void AlterarDescricao(string descricao)
        {
            if (string.IsNullOrWhiteSpace(descricao))
                throw new DomainException("Descrição é obrigatória.");

            Descricao = descricao.Trim();
        }
    }
}

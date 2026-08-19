using Domain.Exceptions;

namespace Domain.Entities
{
    public class GrupoComissao
    {
        public GrupoComissao(string descricao)
        {
            AlterarDescricao(descricao);
        }

        public int Codigo { get; private set; }
        public int CdEmpresa { get; private set; } = 1;
        public string Descricao { get; private set; } = string.Empty;
        public decimal Percentual { get; private set; }

        public void AlterarDescricao(string descricao)
        {
            if (string.IsNullOrWhiteSpace(descricao))
                throw new DomainException("Descrição é obrigatória.");

            Descricao = descricao.Trim();
        }

        public void DefinirPercentual(decimal percentual)
        {
            if (percentual < 0 || percentual > 100)
                throw new DomainException("Percentual deve estar entre 0 e 100.");

            Percentual = percentual;
        }
    }
}

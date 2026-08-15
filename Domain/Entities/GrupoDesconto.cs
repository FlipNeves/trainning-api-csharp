namespace Domain.Entities
{
    public class GrupoDesconto
    {
        public GrupoDesconto(string descricao)
        {
            Descricao = descricao;
        }

        public int Codigo { get; set; }
        public int CdEmpresa { get; set; } = 1;
        public string Descricao { get; set; } = string.Empty;
    }
}

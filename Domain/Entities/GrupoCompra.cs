namespace Domain.Entities
{
    public class GrupoCompra
    {
        public GrupoCompra(string descricao)
        {
            Descricao = descricao;
        }

        public int Codigo { get; set; }
        public int CdEmpresa { get; set; } = 1;
        public string Descricao { get; set; } = string.Empty;
    }
}

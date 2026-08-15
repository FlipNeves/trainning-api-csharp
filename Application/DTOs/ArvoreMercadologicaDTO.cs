namespace Application.DTOs
{
    public class ArvoreMercadologicaDTO
    {
        public List<GrupoComissaoDTO> GruposComissao { get; set; } = [];
        public List<GrupoCompraDTO> GruposCompra { get; set; } = [];
        public List<GrupoDescontoDTO> GruposDesconto { get; set; } = [];
    }
}

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using QuickCompare.Domain.Entity;
using QuickCompare.Domain.Enum;

namespace QuickCompare.Application.Dto
{
    public class NotebookDto
    {
        public string Processador { get; set; }
        public string PlacaDeVideo { get; set; }
        public int QuantidadePortasUsb20 { get; set; }
        public int QuantidadePortasUsb32 { get; set; }
        public bool EntradaC { get; set; }
        public bool MemoriaRamExpansivel { get; set; }
        public bool CapacidadeArmazenamentoExpansivel { get; set; }
        public bool WebCam { get; set; }
        public GeracaoMemoriaRam GeracaoMemoriaRam { get; set; }
        public FrequenciaMemoriaRam FrequenciaMemoriaRam { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public decimal? Espessura { get; set; }
        public decimal? Peso { get; set; }
        public int? Mah { get; set; }
        public int? DuracaoBateriaAproximada { get; set; }
        public CapacidadeArmazenamento CapacidadeArmazenamento { get; set; }
        public MemoriaRam MemoriaRam { get; set; }
        public TipoAparelho TipoAparelho { get; set; }
        public TelaEntity Tela { get; set; }
    }
}
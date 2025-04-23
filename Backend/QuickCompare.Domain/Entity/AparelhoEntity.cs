
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using QuickCompare.Domain.Enum;

namespace QuickCompare.Domain.Entity

{
    public abstract class AparelhoEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "É obrigatório o preenchimento do campo marca")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "É obrigatório o preenchimento do campo modelo")]
        public string Modelo { get; set; }

        public int? Espessura { get; set; }
        public int? Peso { get; set; }

        public int? mAh { get; set; }
        public int? DuracaoBateriaAproximada { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public CapacidadeArmazenamento CapacidadeArmazenamento { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public MemoriaRam MemoriaRam { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TipoAparelho TipoAparelho { get; set; }

        public TelaEntity Tela { get; set; }

    }
}
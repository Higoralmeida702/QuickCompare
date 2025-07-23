
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using QuickCompare.Domain.Enum;
using QuickCompare.Domain.Validations;

namespace QuickCompare.Domain.Entity

{
    public abstract class AparelhoEntity
    {
        public int Id { get; private set; }

        [Required(ErrorMessage = "É obrigatório o preenchimento do campo marca")]
        public string Marca { get; private set; }

        [Required(ErrorMessage = "É obrigatório o preenchimento do campo modelo")]
        public string Modelo { get; private set; }

        [Column(TypeName = "decimal(8,2)")]
        public decimal? Espessura { get; private set; }

        [Column(TypeName = "decimal(8,2)")]
        public decimal? Peso { get; private set; }

        public int? Mah { get; private set; }
        public int? DuracaoBateriaAproximada { get; private set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        [Required(ErrorMessage = "É obrigatório o preenchimento informando a capacidade de armazenamento")]
        public CapacidadeArmazenamento CapacidadeArmazenamento { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        [Required(ErrorMessage = "É obrigatório o preenchimento informando a capacidade da memoria ram")]
        public MemoriaRam MemoriaRam { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        [Required(ErrorMessage = "É obrigatório o preenchimento informando o tipo de aparelho")]
        public TipoAparelho TipoAparelho { get; set; }

        [Required(ErrorMessage = "É obrigatório o preenchimento das informações do campo tela")]
        public TelaEntity Tela { get; set; }

        protected AparelhoEntity(string marca, string modelo, decimal? espessura, decimal? peso, int? mah, int? duracaoBateriaAproximada, CapacidadeArmazenamento capacidadeArmazenamento, MemoriaRam memoriaRam, TipoAparelho tipoAparelho, TelaEntity tela)
        {
            ValidateDomain(marca, modelo, espessura, peso, mah, duracaoBateriaAproximada, capacidadeArmazenamento, memoriaRam, tipoAparelho, tela);
        }

        public void ValidateDomain(string marca, string modelo, decimal? espessura, decimal? peso, int? mah, int? duracaoBateriaAproximada, CapacidadeArmazenamento capacidadeArmazenamento, MemoriaRam memoriaRam, TipoAparelho tipoAparelho, TelaEntity tela)
        {
            DomainValidationExceptions.When(!System.Enum.IsDefined(typeof(CapacidadeArmazenamento), capacidadeArmazenamento), "Capacidade de armazenamento inválida. Valores aceitos (somente numero): " + string.Join(",", System.Enum.GetNames(typeof(CapacidadeArmazenamento))));
            DomainValidationExceptions.When(!System.Enum.IsDefined(typeof(MemoriaRam), memoriaRam), "Memória RAM inválida. Valores aceitos (somente numero): " + string.Join(",", System.Enum.GetNames(typeof(MemoriaRam))));
            DomainValidationExceptions.When(!System.Enum.IsDefined(typeof(TipoAparelho), tipoAparelho), "Tipo de aparelho inválido. Valores aceitos (somente numero): " + string.Join(",", System.Enum.GetNames(typeof(TipoAparelho))));

            DomainValidationExceptions.When(espessura <= 0, "Não é valido que o valor de espessura seja igual ou menor que zero");
            DomainValidationExceptions.When(peso <= 0, "Não é valido que o valor do peso seja igual ou menor que zero");
            DomainValidationExceptions.When(mah <= 0, "Não é valido que o valor de Mah seja igual ou menor que zero");
            DomainValidationExceptions.When(duracaoBateriaAproximada <= 0, "Não é valido que o valor DuracaoBateriaAproximada seja igual ou menor que zero");

            Marca = marca;
            Modelo = modelo;
            Espessura = espessura;
            Peso = peso;
            Mah = mah;
            DuracaoBateriaAproximada = duracaoBateriaAproximada;
            CapacidadeArmazenamento = capacidadeArmazenamento;
            MemoriaRam = memoriaRam;
            TipoAparelho = tipoAparelho;
            Tela = tela;
        }

        public void Update(string marca, string modelo, decimal? espessura, decimal? peso, int? mah, int? duracaoBateriaAproximada, CapacidadeArmazenamento capacidadeArmazenamento, MemoriaRam memoriaRam, TipoAparelho tipoAparelho, TelaEntity tela)
        {
            ValidateDomain(marca, modelo, espessura, peso, mah, duracaoBateriaAproximada, capacidadeArmazenamento, memoriaRam, tipoAparelho, tela);
        }

        protected AparelhoEntity() { }


    }
}
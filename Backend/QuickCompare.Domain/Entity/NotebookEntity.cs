
using System.ComponentModel.DataAnnotations;
using QuickCompare.Domain.Enum;

namespace QuickCompare.Domain.Entity
{
    public class NotebookEntity : AparelhoEntity
    {
        [Required(ErrorMessage = "É obrigatório o preenchimento do campo informando Largura do dispositivo")]
        public string Processador { get; private set; }
        [Required(ErrorMessage = "É obrigatório o preenchimento do campo informando Largura do dispositivo")]
        public string PlacaDeVideo { get; private set; }
        [Required(ErrorMessage = "É obrigatório o preenchimento do campo informando Largura do dispositivo")]
        public int QuantidadePortasUsb20 { get; private set; }
        [Required(ErrorMessage = "É obrigatório o preenchimento do campo informando Largura do dispositivo")]
        public int QuantidadePortasUsb32 { get; private set; }
        [Required(ErrorMessage = "É obrigatório o preenchimento do campo informando Largura do dispositivo")]
        public bool EntradaC { get; private set; }
        [Required(ErrorMessage = "É obrigatório o preenchimento do campo informando Largura do dispositivo")]
        public bool MemoriaRamExpansivel { get; private set; }
        [Required(ErrorMessage = "É obrigatório o preenchimento do campo informando Largura do dispositivo")]
        public bool CapacidadeArmazenamentoExpansivel { get; private set; }
        [Required(ErrorMessage = "É obrigatório o preenchimento do campo informando Largura do dispositivo")]
        public bool WebCam { get; private set; }
        [Required(ErrorMessage = "É obrigatório o preenchimento do campo informando Largura do dispositivo")]
        public GeracaoMemoriaRam GeracaoMemoriaRam { get; set; }
        [Required(ErrorMessage = "É obrigatório o preenchimento do campo informando Largura do dispositivo")]
        public FrequenciaMemoriaRam FrequenciaMemoriaRam { get; set; }

        public NotebookEntity(string marca, string modelo, decimal? espessura, decimal? peso, int? mah, int? duracaoBateriaAproximada, CapacidadeArmazenamento capacidadeArmazenamento,
         MemoriaRam memoriaRam, TipoAparelho tipoAparelho, TelaEntity tela, string processador, string placaDeVideo, int quantidadePortasUsb20, int quantidadePortasUsb32, bool entradaC,
        bool memoriaRamExpansivel, bool capacidadeArmazenamentoExpansivel, bool webCam, GeracaoMemoriaRam geracaoMemoriaRam,
         FrequenciaMemoriaRam frequenciaMemoriaRam) : base(marca, modelo, espessura, peso, mah, duracaoBateriaAproximada, capacidadeArmazenamento, memoriaRam, tipoAparelho, tela)
        {
            ValidateDomain(processador, placaDeVideo, quantidadePortasUsb20, quantidadePortasUsb32, entradaC, memoriaRamExpansivel, capacidadeArmazenamentoExpansivel, webCam, geracaoMemoriaRam, frequenciaMemoriaRam);
        }


        public void ValidateDomain(string processador, string placaDeVideo, int quantidadePortasUsb20, int quantidadePortasUsb32, bool entradaC, bool memoriaRamExpansivel,
        bool capacidadeArmazenamentoExpansivel, bool webCam, GeracaoMemoriaRam geracaoMemoriaRam, FrequenciaMemoriaRam frequenciaMemoriaRam)
        {
            Processador = processador;
            PlacaDeVideo = placaDeVideo;
            QuantidadePortasUsb20 = quantidadePortasUsb20;
            QuantidadePortasUsb32 = quantidadePortasUsb32;
            EntradaC = entradaC;
            MemoriaRamExpansivel = memoriaRamExpansivel;
            CapacidadeArmazenamentoExpansivel = capacidadeArmazenamentoExpansivel;
            WebCam = webCam;
            GeracaoMemoriaRam = geracaoMemoriaRam;
            FrequenciaMemoriaRam = frequenciaMemoriaRam;
        }

        public void Update(string marca, string modelo, decimal? espessura, decimal? peso, int? mah, int? duracaoBateriaAproximada, CapacidadeArmazenamento capacidadeArmazenamento, MemoriaRam memoriaRam,
        TipoAparelho tipoAparelho, TelaEntity tela, string processador, string placaDeVideo, int quantidadePortasUsb20, int quantidadePortasUsb32, bool entradaC, bool memoriaRamExpansivel,
        bool capacidadeArmazenamentoExpansivel, bool webCam, GeracaoMemoriaRam geracaoMemoriaRam, FrequenciaMemoriaRam frequenciaMemoriaRam)
        {
            base.ValidateDomain(marca, modelo, espessura, peso, mah, duracaoBateriaAproximada, capacidadeArmazenamento, memoriaRam, tipoAparelho, tela);
            Processador = processador;
            PlacaDeVideo = placaDeVideo;
            QuantidadePortasUsb20 = quantidadePortasUsb20;
            QuantidadePortasUsb32 = quantidadePortasUsb32;
            EntradaC = entradaC;
            MemoriaRamExpansivel = memoriaRamExpansivel;
            CapacidadeArmazenamentoExpansivel = capacidadeArmazenamentoExpansivel;
            WebCam = webCam;
            GeracaoMemoriaRam = geracaoMemoriaRam;
            FrequenciaMemoriaRam = frequenciaMemoriaRam;
        }
        protected NotebookEntity() : base() { }
    }
}
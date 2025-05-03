using System.ComponentModel.DataAnnotations;
using QuickCompare.Domain.Entity;
using QuickCompare.Domain.Enum;

namespace QuickCompare.Application.Dto
{
    public class CelularDto
    {
        public string Marca { get; set; }

        public string Modelo { get; set; }

        public int? Espessura { get; set; }
        public int? Peso { get; set; }
        public int? Mah { get; set; }

        public int? DuracaoAproximadaBateria { get; set; }

        [Required(ErrorMessage = "Capacidade de armazenamento é obrigatória")]
        public CapacidadeArmazenamento CapacidadeArmazenamento { get; set; }

        [Required(ErrorMessage = "Memória RAM é obrigatória")]
        public MemoriaRam MemoriaRam { get; set; }

        [Required(ErrorMessage = "Tipo de aparelho é obrigatório")]
        public TipoAparelho TipoAparelho { get; set; }

        public TelaEntity Tela { get; set; }

        public bool ExpansaoMicroSd { get; set; }
        public bool DualSim { get; set; }
        public bool Has5G { get; set; }
        public int ComprimentoCelular { get; set; }
        public int LarguraCelular { get; set; }
    }
}

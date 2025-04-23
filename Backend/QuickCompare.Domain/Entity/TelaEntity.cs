using QuickCompare.Domain.Enum;

namespace QuickCompare.Domain.Entity
{
    public class TelaEntity
    {
        public int Largura { get; set; }
        public int Altura { get; set; }
        public int Polegadas { get; set; }
        public int? Nits { get; set; }
        public AtualizacaoTela AtualizacaoTela { get; set; }
        public QualidadeResolucao QualidadeResolucao { get; set; }
        public TipoTela TipoTela { get; set; }
        public ProtecaoTela? ProtecaoTela { get; set; }
    }
}
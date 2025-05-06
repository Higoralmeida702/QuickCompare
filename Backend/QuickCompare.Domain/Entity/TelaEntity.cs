using QuickCompare.Domain.Enum;

namespace QuickCompare.Domain.Entity
{
    public class TelaEntity
    {
        public int Largura { get; private set; }
        public int Altura { get; private set; }
        public int Polegadas { get; private set; }
        public int? Nits { get; private set; }
        public AtualizacaoTela AtualizacaoTela { get; set; }
        public QualidadeResolucao QualidadeResolucao { get; set; }
        public TipoTela TipoTela { get; set; }
        public ProtecaoTela? ProtecaoTela { get; set; }

        public TelaEntity(int largura, int altura, int polegadas, int? nits, AtualizacaoTela atualizacaoTela, QualidadeResolucao qualidadeResolucao, TipoTela tipoTela, ProtecaoTela? protecaoTela)
        {
            ValidateDomain(largura, altura, polegadas, nits, atualizacaoTela, qualidadeResolucao, tipoTela, protecaoTela);
        }

        public void ValidateDomain(int largura, int altura, int polegadas, int? nits, AtualizacaoTela atualizacaoTela, QualidadeResolucao qualidadeResolucao, TipoTela tipoTela, ProtecaoTela? protecaoTela)
        {
            Largura = largura;
            Altura = altura;
            Polegadas = polegadas;
            Nits = nits;
            AtualizacaoTela = atualizacaoTela;
            QualidadeResolucao = qualidadeResolucao;
            TipoTela = tipoTela;
            ProtecaoTela = protecaoTela;
        }
    }
}
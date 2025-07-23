using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using QuickCompare.Domain.Enum;
using QuickCompare.Domain.Validations;

namespace QuickCompare.Domain.Entity
{
    public class TelaEntity
    {
        [Required(ErrorMessage = "É obrigatório o preenchimento do campo informando Largura do dispositivo")]
        [Column(TypeName = "decimal(8,2)")]
        public decimal Largura { get; private set; }

        [Required(ErrorMessage = "É obrigatório o preenchimento do campo informando Altura do dispositivo")]
        [Column(TypeName = "decimal(8,2)")]
        public decimal Altura { get; private set; }

        [Required(ErrorMessage = "É obrigatório o preenchimento do campo informando Polegadas do dispositivo")]
        [Column(TypeName = "decimal(8,2)")]
        public decimal Polegadas { get; private set; }

        public int? Nits { get; private set; }

        [Required(ErrorMessage = "É obrigatório o preenchimento do campo informando a Atualização de tela do dispositivo")]
        public AtualizacaoTela AtualizacaoTela { get; set; }

        [Required(ErrorMessage = "É obrigatório o preenchimento do campo informando a Qualidade da resolução  do dispositivo")]
        public QualidadeResolucao QualidadeResolucao { get; set; }

        [Required(ErrorMessage = "É obrigatório o preenchimento do campo informando o tipo de Tela do dispositivo")]
        public TipoTela TipoTela { get; set; }

        public ProtecaoTela? ProtecaoTela { get; set; }

        public TelaEntity(decimal largura, decimal altura, decimal polegadas, int? nits, AtualizacaoTela atualizacaoTela, QualidadeResolucao qualidadeResolucao, TipoTela tipoTela, ProtecaoTela? protecaoTela)
        {
            ValidateDomain(largura, altura, polegadas, nits, atualizacaoTela, qualidadeResolucao, tipoTela, protecaoTela);
        }

        public void ValidateDomain(decimal largura, decimal altura, decimal polegadas, int? nits, AtualizacaoTela atualizacaoTela, QualidadeResolucao qualidadeResolucao, TipoTela tipoTela, ProtecaoTela? protecaoTela)
        {
            DomainValidationExceptions.When(largura <= 0, "Não é válido o número ser igual ou menor que zero");
            DomainValidationExceptions.When(altura <= 0, "Não é válido o número ser igual ou menor que zero");
            DomainValidationExceptions.When(polegadas <= 0, "Não é válido o número ser igual ou menor que zero");
            DomainValidationExceptions.When(nits <= 0, "Não é válido o número ser igual ou menor que zero");


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
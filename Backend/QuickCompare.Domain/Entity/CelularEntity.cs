using QuickCompare.Domain.Enum;
using QuickCompare.Domain.Validations;

namespace QuickCompare.Domain.Entity
{
    public class CelularEntity : AparelhoEntity
    {
        public bool ExpansaoMicroSd { get; private set; }
        public bool DualSim { get; private set; }
        public bool Has5G { get; private set; }
        public decimal ComprimentoCelular { get; private set; }
        public decimal LarguraCelular { get; private set; }

        public CelularEntity(
            string marca,
            string modelo,
            decimal? espessura,
            decimal? peso,
            int? mah,
            int? duracaoBateriaAproximada,
            CapacidadeArmazenamento capacidadeArmazenamento,
            MemoriaRam memoriaRam,
            TipoAparelho tipoAparelho,
            TelaEntity tela,
            bool expansaoMicroSd,
            bool dualSim,
            bool has5G,
            decimal comprimentoCelular,
            decimal larguraCelular
        ) : base(
            marca, modelo, espessura, peso, mah, duracaoBateriaAproximada,
            capacidadeArmazenamento, memoriaRam, tipoAparelho, tela)
        {
            ValidateDomain(expansaoMicroSd, dualSim, has5G, comprimentoCelular, larguraCelular);
        }

        public void Update(
        string marca, string modelo, decimal? espessura, decimal? peso, int? mah,
        int? duracaoBateriaAproximada, CapacidadeArmazenamento capacidadeArmazenamento,
        MemoriaRam memoriaRam, TipoAparelho tipoAparelho, TelaEntity tela,
        bool expansaoMicroSd, bool dualSim, bool has5G, decimal comprimentoCelular, decimal larguraCelular)
        {
            base.Update(marca, modelo, espessura, peso, mah, duracaoBateriaAproximada, capacidadeArmazenamento, memoriaRam, tipoAparelho, tela);
            ValidateDomain(expansaoMicroSd, dualSim, has5G, comprimentoCelular, larguraCelular);
        }

        public void ValidateDomain(bool expansaoMicroSd, bool dualSim, bool has5G, decimal comprimentoCelular, decimal larguraCelular)
        {
            DomainValidationExceptions.When(comprimentoCelular <= 0, "Comprimento do celular não pode ser igual ou menor que zero.");
            DomainValidationExceptions.When(larguraCelular <= 0, "Largura do celular não pode ser igual ou menor que zero.");

            ExpansaoMicroSd = expansaoMicroSd;
            DualSim = dualSim;
            Has5G = has5G;
            ComprimentoCelular = comprimentoCelular;
            LarguraCelular = larguraCelular;
        }

        protected CelularEntity() : base() { }

    }
}

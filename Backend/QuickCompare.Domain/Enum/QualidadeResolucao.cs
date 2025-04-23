using System.ComponentModel.DataAnnotations;

namespace QuickCompare.Domain.Enum
{
    public enum QualidadeResolucao
    {
        [Display (Name = "Resolução HD")]
        HD = 1,

        [Display (Name = "Resolução FullHd")]
        FullHD = 2, 

        [Display (Name = "Resolução QuadHd")]
        QuadHD = 3,
    }
}
using System.ComponentModel.DataAnnotations;

namespace QuickCompare.Domain.Enum
{
    public enum  GeracaoMemoriaRam
    {
        [Display(Name = "DDR3")]
        DDR3,

        [Display(Name = "DDR4")]
        DDR4,

        [Display(Name = "DDR5")]
        DDR5
    }
}
using System.ComponentModel.DataAnnotations;

namespace QuickCompare.Domain.Enum
{
    public enum AtualizacaoTela
    {
        [Display (Name = "60 Hertz ")]
        Hz60 = 60,

        [Display (Name = "75 Hertz ")]
        Hz75 = 75,
        
        [Display (Name = "100 Hertz ")]
        Hz100 = 100,
        
        [Display (Name = "120 Hertz ")]
        Hz120 = 120,
 
        [Display (Name = "144 Hertz ")]
        Hz144 = 144
    }
}
using System.ComponentModel.DataAnnotations;

namespace QuickCompare.Domain.Enum
{
    public enum TipoTela
    {
        [Display(Name = "IPS LCD")]
        IPSLCD = 1,

        [Display(Name = "OLED")]
        OLED = 2,

        [Display(Name = "AMOLED")]
        AMOLED = 3,

        [Display(Name = "Super AMOLED")]
        SuperAMOLED = 4,

        [Display(Name = "Dynamic AMOLED")]
        DynamicAMOLED = 5,

        [Display(Name = "LTPO AMOLED")]
        LTPOAMOLED = 6,

        [Display(Name = "P-OLED")]
        POLED = 7,

        [Display(Name = "Mini LED")]
        MiniLED = 8,

        [Display(Name = "VA")]
        VA = 9,

        [Display(Name = "TN")]
        TN = 10,
    }
}
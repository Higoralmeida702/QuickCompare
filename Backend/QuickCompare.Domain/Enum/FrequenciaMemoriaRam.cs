using System.ComponentModel.DataAnnotations;

namespace QuickCompare.Domain.Enum
{
    public enum FrequenciaMemoriaRam
    {
        //DDR3
        [Display(Name = "1333 Mhz")]
        MHz1333 = 1333,

        [Display(Name = "1600 Mhz")]
        MHz1600 = 1600,

        //DRR4
        [Display(Name = "2133 Mhz")]
        MHz2133 = 2133, 

        [Display(Name = "2400 Mhz")]
        MHz2400 = 2400,

        [Display(Name = "2666 Mhz")]
        MHz2666 = 2666,

        [Display(Name = "2933 Mhz")]
        MHz2933 = 2933,

        [Display(Name = "3200 Mhz")]
        MHz3200 = 3200,

        //DDR5

        [Display(Name = "4800 Mhz")]
        MHz4800 = 4800, 

        [Display(Name = "5200 Mhz")]
        MHz5200 = 5200,

        [Display(Name = "5600 Mhz")]
        MHz5600 = 5600,

        [Display(Name = "6000 Mhz")]
        MHz6000 = 6000,

    }
}
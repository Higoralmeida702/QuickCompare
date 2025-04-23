using System.ComponentModel.DataAnnotations;

namespace QuickCompare.Domain.Enum
{
    public enum MemoriaRam
    {
        [Display(Name = "2 GB")]
        MemoriaRam2GB = 2,

        [Display(Name = "4 GB")]
        MemoriaRam4GB = 4,

        [Display(Name = "6 GB")]
        MemoriaRam6GB = 6,

        [Display(Name = "8 GB")]
        MemoriaRam8GB = 8,

        [Display(Name = "12 GB")]
        MemoriaRam12GB = 12,

        [Display(Name = "16 GB")]
        MemoriaRam16GB = 16,

        [Display(Name = "32 GB")]
        MemoriaRam32GB = 32,

        [Display(Name = "64 GB")]
        MemoriaRam64GB = 64
    }
}

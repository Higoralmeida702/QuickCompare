using System.ComponentModel.DataAnnotations;

namespace QuickCompare.Domain.Enum
{
    public enum CapacidadeArmazenamento
    {
        [Display(Name = "32 GB")]
        Armazenamento32GB = 32,

        [Display(Name = "64GB")]
        Armazenamento64GB = 64,

        [Display(Name = "128 GB")]
        Armazenamento128GB = 128,

        [Display(Name = "256 GB")]
        Armazenamento256GB = 256,

        [Display(Name = "480 GB")]
        Armazenamento480GB = 480,

        [Display(Name = "512 GB")]
        Armazenamento512GB = 512,

        [Display(Name = "1 TB")]
        Armazenamento1TB = 1000,

    }
}
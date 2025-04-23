using System.ComponentModel.DataAnnotations;

namespace QuickCompare.Domain.Enum
{
    public enum ProtecaoTela
    {
        [Display(Name = "Sem proteção específica")]
        Nenhuma = 0,

        [Display(Name = "Gorilla Glass 3")]
        GorillaGlass3 = 1,

        [Display(Name = "Gorilla Glass 5")]
        GorillaGlass5 = 2,

        [Display(Name = "Gorilla Glass 6")]
        GorillaGlass6 = 3,

        [Display(Name = "Gorilla Glass Victus")]
        GorillaGlassVictus = 4,

        [Display(Name = "Gorilla Glass Victus+")]
        GorillaGlassVictusPlus = 5,

        [Display(Name = "Gorilla Glass Victus 2")]
        GorillaGlassVictus2 = 6,

        [Display(Name = "Gorilla Glass Armor")]
        GorillaGlassArmor = 7,

        [Display(Name = "Dragontrail")]
        Dragontrail = 8,

        [Display(Name = "Panda Glass")]
        PandaGlass = 9,

        [Display(Name = "Sapphire Glass")]
        SapphireGlass = 10
    }
}

using System.ComponentModel.DataAnnotations;

namespace QuickCompare.Domain.Enum
{
    public enum TipoAparelho
    {
        [Display(Name = "Notebook")]
        Notebook = 1,

        [Display(Name = "Celular")]
        Celular = 2,

        [Display(Name = "Tablet")]
        Tablet = 3
    }
}
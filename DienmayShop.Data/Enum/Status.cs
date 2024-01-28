using System.ComponentModel.DataAnnotations;

namespace DienmayShop.Data.Enum
{
    public enum Status
    {
        [Display(Name = "Not active")]
        InActive,
        [Display(Name = "Active")]
        Active
    }
}

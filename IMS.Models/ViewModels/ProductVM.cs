using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IMS.Models.ViewModels
{
    public class ProductVM
    {
        public Product Product { get; set; } = new Product();

        [ValidateNever]
        public IEnumerable<SelectListItem> CategoryList { get; set; } = new List<SelectListItem>();

        [ValidateNever]
        public IEnumerable<SelectListItem> UnitList { get; set; } = new List<SelectListItem>();
    }
}

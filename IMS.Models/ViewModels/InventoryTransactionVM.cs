using IMS.Utility.Enums;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace IMS.Models.ViewModels
{
    public class InventoryTransactionVM
    {
        [Required]
        [Display(Name = "Product")]
        public int ProductId { get; set; }

        [Required]
        [Display(Name="Store")]
        public int StoreId { get; set; }

        [Required]
        [Display(Name = "Transaction Type")]
        public TransactionType TransactionType { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        public int Quantity { get; set; }

        public string? Note { get; set; }

        [Display(Name = "Performed By")]
        public string? PerformedBy { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> Products { get; set; } = new List<SelectListItem>();

        [ValidateNever]
        public IEnumerable<SelectListItem> Stores { get; set; } = new List<SelectListItem>();

        [ValidateNever]
        public IEnumerable<SelectListItem> TransactionTypes { get; set; } = new List<SelectListItem>();
    }
}

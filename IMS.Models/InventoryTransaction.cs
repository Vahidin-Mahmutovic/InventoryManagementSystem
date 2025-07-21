using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IMS.Utility.Enums;

namespace IMS.Models
{
   public class InventoryTransaction
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Transaction Date")]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Transaction Type")]
        public TransactionType TransactionType { get; set; }

        [Required]
        [Display(Name = "Product")]
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        [Required]
        [Display(Name = "Store")]
        public int StoreId { get; set; }

        [ForeignKey("StoreId")]
        public Store Store { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [StringLength(1000)]
        [Display(Name = "Note")]
        public string? Note { get; set; }

        [StringLength(100)]
        [Display(Name = "Performed By")]
        public string? PerformedBy { get; set; }
    }
}
